using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Arena : MonoBehaviour
{
    public int waveNumber;
    public GameObject player;
    
    public bool waveProcessed = false;

    public GameObject[] enemys;
    public Transform[] spawns;
    public GameObject[] Bosses;
     public GameObject Finish;
    public List<GameObject> spawnedEnemys = new List<GameObject>();

    public GameObject shopWall;
    public GameObject prizeWall;
    public GameObject bossWall;
    public GameObject shop;

    public int eventBaseChance = 2;
    public int startSpawn = 0;
    public int bossWave = 20;
    public int maxEnemys = 15;


    TextMeshPro board;
    int curretEvent = -1;
    GameObject spawnedShop;
    ArenaEvents events;
    Message message;
    bool allDead;

    // Start is called before the first frame update
    private void Start()
    {
        //findPlayer
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.name == "FPSPlayer")
            {
                player = obj;
            }
        }
        board = GetComponentInChildren<TextMeshPro>();
        events = GetComponent<ArenaEvents>();
        message = player.GetComponentInChildren<Message>();
    }
    // Update is called once per frame
    public void ArenaStart()
    {
        if (waveProcessed) return;

        ShopLogic(false);
        waveProcessed = true;

        bool isEvent = Random.Range(0, 101) <  (waveNumber * eventBaseChance) + waveNumber;

        if (isEvent || waveNumber == bossWave)
        {
            Event();
        }
        else
        {
            message.ShowMessage("Волна " + waveNumber.ToString(), "");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: none";
            SpawnEnemy();
        }

        prizeWall.SetActive(true);
    }
    public void ArenaStop()
    {
        if (waveNumber != bossWave) // % 5 == 0) //> 0)
        {
            message.ShowMessage("Волна " + waveNumber.ToString() + " пройдена!", "Магазины открыты");
            ShopLogic(true);

        }
        prizeWall.SetActive(false);
        waveNumber++;
        GetComponent<Lever>().Interact_with_taget();
        waveProcessed = false;
        curretEvent = -1;
    }
    public void IsAllEnemyDeadCheck()
    {
        allDead = spawnedEnemys.TrueForAll(x => x == null);
        if (allDead == true)
        {
            ArenaStop();
        }
    }
    public void ShopLogic(bool shopExist)
    {
        if (shopExist)
        {

            shopWall.SetActive(false);
            spawnedShop = Instantiate(shop, shopWall.transform.position, shopWall.transform.rotation);

            if (waveNumber >= 10)
            {
                ShopCell[] Reward = spawnedShop.GetComponentsInChildren<ShopCell>();
                foreach (ShopCell reward in Reward)
                {
                    reward.price += (waveNumber / 10);
                }
            }
        }
        else
        {
            shopWall.SetActive(true);
            if (spawnedShop) Destroy(spawnedShop);
        }

    }
    public void SpawnEnemy()
    {
        spawnedEnemys.Clear();
        int maxEnemy = waveNumber + startSpawn + 2;
        if (maxEnemy > maxEnemys) maxEnemy = maxEnemys;

        for (int i = startSpawn; i < maxEnemy; i++)
        {

            //Выбираем спавн для него либо по очереди, либо, если спавны кончились, случайный
            Transform spawn;
            if (i + 3 >= spawns.Length)
            {
                spawn = spawns[Random.Range(startSpawn, spawns.Length)];
            }
            else
            {
                spawn = spawns[Random.Range(startSpawn, spawns.Length)];
                //spawn = spawns[Random.Range(i, i + 3)];
            }
            // Настраиваем нашего парня // Берем случайного противника
            var enemy = Instantiate(enemys[GetRandomEnemy()], spawn.transform.position, spawn.transform.rotation);
            Enemy_Health enemyHealth = enemy.GetComponentInChildren<Enemy_Health>();
            if (curretEvent == 2) enemyHealth.Enemys_health *= 2;
            enemyHealth.arena = gameObject;
            enemyHealth.arena_number = i - startSpawn;
            if (enemy.GetComponentInChildren<Zombie>()) enemy.GetComponentInChildren<Zombie>().Target = player;
            if (enemy.GetComponentInChildren<AI>()) enemy.GetComponentInChildren<AI>().Target = player;
            //Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
            spawnedEnemys.Add(enemy);
        }
        startSpawn = 0;
        allDead = false;
    }
    private int GetRandomEnemy()
    {
        List<float> chances = new List<float>();

        //текущие максимальные противники
        int curretEnemys = (int)Mathf.Ceil(waveNumber / 3);
        if (curretEnemys >= enemys.Length) curretEnemys = enemys.Length - 1;

        //отсекаем первых противников
        int firstEnemys = curretEnemys - 4;
        if (firstEnemys <= 0) firstEnemys = 0;
        Debug.Log(firstEnemys);

        for (int x = firstEnemys; x <= curretEnemys; x++)
        {
            chances.Add(enemys[x].GetComponent<Chance>().chance);
        }

        float value = Random.Range(0, chances.Sum());

        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];

            if (value < sum)
            {
                return i + firstEnemys; // RoomPrefabs[i];
            }

        }
        return 0;
    }
    public void Event()
    {
        int eventNumber = -1;
        if (waveNumber == bossWave)
        {
            eventNumber = 0;
        }
        else
        {
            eventNumber = Random.Range(1, 6);
        }
        
        //The Last Event
        if (eventNumber == 0)
        {
            bossWall.SetActive(false);
            var boss = Bosses[Random.Range(0, Bosses.Length)];
            var bossRoom = Instantiate(boss, bossWall.transform.position, Quaternion.Euler(0, -90, 0));
            Transform finishPos = bossRoom.GetComponent<Room>().Enter_to_new_room;
            Instantiate(Finish, finishPos.position, Quaternion.Euler(0, -90, 0));
            message.ShowMessage("Волна " + waveNumber.ToString(), "Ты мне надоел.");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: Boss";
            ArenaStop();
        }
        //Lava
        if (eventNumber == 1)
        {
            startSpawn = 9;
            SpawnEnemy();
            message.ShowMessage("Волна " + waveNumber.ToString(), "Уровень кислоты растет!");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: Toxin";
            events.LavaUp(waveNumber);
        }

        // x2 Health
        if (eventNumber == 2)
        {
            curretEvent = 2;
            SpawnEnemy();
            message.ShowMessage("Волна " + waveNumber.ToString(), "Двойное здоровье! Но не у тебя...");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: X2 Health";
        }
        //BetterEnemys
        if (eventNumber == 3)
        {
            spawnedEnemys.Clear();
            for (int i = startSpawn; i < (waveNumber / 5) + 1; i++)
            {

                //Выбираем спавн для него либо по очереди, либо, если спавны кончились, случайный
                Transform spawn;
                if (i >= spawns.Length)
                {
                    spawn = spawns[Random.Range(startSpawn, spawns.Length)];
                }
                else
                {
                    spawn = spawns[i];
                }
                // Настраиваем нашего парня // Берем финальных противников
                int EventEnemy = Random.Range(5, 10);
                var enemy = Instantiate(enemys[EventEnemy], spawn.transform.position, spawn.transform.rotation);
                Enemy_Health enemyHealth = enemy.GetComponentInChildren<Enemy_Health>();
                enemyHealth.arena = gameObject;
                enemyHealth.arena_number = i - startSpawn;
                if (enemy.GetComponentInChildren<Zombie>()) enemy.GetComponentInChildren<Zombie>().Target = player;
                if (enemy.GetComponentInChildren<AI>()) enemy.GetComponentInChildren<AI>().Target = player;
                //Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
                spawnedEnemys.Add(enemy);
            }
            startSpawn = 0;
            allDead = false;
            message.ShowMessage("Волна " + waveNumber.ToString(), "Они идут за тобой...");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: They.";
        }
        //Bomb
        if (eventNumber == 4)
        {
            SpawnEnemy();
            message.ShowMessage("Волна " + waveNumber.ToString(), "Бомба!");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: TimeBomb";
            events.TimeBombEventStart();
        }
        //Smoke
        if (eventNumber == -1)
        {
            SpawnEnemy();
            message.ShowMessage("Волна " + waveNumber.ToString(), "Задымление! Обзор ограничен");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: Smoke";
            events.Smoke(waveNumber);
        }
        //Darkness
        if (eventNumber == 5) {
            SpawnEnemy();
            message.ShowMessage("Волна " + waveNumber.ToString(), "Тьма");
            board.text = "Wave #" + waveNumber.ToString() + "\nEvent: Darkness";
            events.Darkness();
        }
    }
}
 