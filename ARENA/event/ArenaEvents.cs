using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArenaEvents : MonoBehaviour
{
    public int lavaOffset = -10;
    public GameObject lava;
    public GameObject smoke;
    public GameObject TimeBomb;
    Transform[] spawns;
    public GameObject LastEventLava;
    int curretGun;
    Switchbox switchbox;

    public void Start()
    {
        spawns = GetComponent<Arena>().spawns;
        switchbox = GameObject.FindObjectOfType<Switchbox>();
    }

    public void LavaUp(int waveNumber)
    {
        var lavaObj = Instantiate(lava, transform.position + new Vector3(0, lavaOffset, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
        lavaObj.transform.SetParent(gameObject.transform);
        lavaObj.GetComponent<LavaEvent>().wave = waveNumber;
    }

    public void LastEvent () {
        LavaUp(20);
        Destroy(LastEventLava);
    }
    public void Smoke(int waveNumber)
    {
        
        for (int i = 0; i < 5; i++)
        {
           int spawnNumber = Random.Range(0, spawns.Length);
           var smokeObj = Instantiate(smoke, spawns[spawnNumber].position, spawns[spawnNumber].rotation);
           smokeObj.transform.SetParent(gameObject.transform);
           smokeObj.GetComponent<SmokeEvent>().wave = waveNumber;
        }
    }
    public void GunGame()
    {

        GunSwitch guns = GetComponent<Arena>().player.GetComponentInChildren<GunSwitch>();

        guns.currentWeapons[0] = guns.allWeapons[Random.Range(0, guns.allWeapons.Length)];
        curretGun = guns.GetComponentInChildren<pistol_n>().item.GetComponentInChildren<Gun_container>().gun;
        guns.currentWeapons[0] = guns.allWeapons[curretGun];
    }
    public void TimeBombEventStart()
    {
        var BombObj = Instantiate(TimeBomb, spawns[Random.Range(0, spawns.Length)].position, transform.rotation);
        var Bomb = BombObj.GetComponent<TimeBomb>();

        var CodePaper = Instantiate(
            Bomb.CodePaper,
            spawns[Random.Range(0, spawns.Length)].position + Vector3.up * 0.01f,
            spawns[Random.Range(0, spawns.Length)].transform.rotation,
            BombObj.transform);
        CodePaper.GetComponentInChildren<TextMeshPro>().text = Bomb.code.ToString();
        
    }
    public void Darkness(){
        switchbox.isDark = true;
        switchbox.ChangeLight();
    }
}
