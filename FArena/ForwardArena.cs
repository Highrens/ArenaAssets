using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class ForwardArena : MonoBehaviour
{
    public GameObject[] ArenaPrefabs;
    public GameObject[] ShopPrefabs;
    public GameObject[] BossesPrefabs;
    public GameObject[] PrizePrefabs;
    [Range(0, 1)]
    public float unicRoomChance;
    public GameObject[] unicPrefabs;
    public GameObject Finish;
    int unicNumber = 0;
    int prizeNumber;
    int shopNumber;
    public GameObject previosArena;
    public GameObject nextArena;
    //public Lever lever;
    public int roomAmount;
    int RealRoomAmount;
    private void Start()
    {
        bool willUnicRoomSpawn = unicRoomChance >= Random.value;

        RealRoomAmount = roomAmount + 4; // add space for Prize, Shop, Boss and Finish;
        if (willUnicRoomSpawn) RealRoomAmount++; // add space for Unic room;

        List<int> uniqueNumbers = new();
        int maxAttempts = 500;
        int attempts = 0;

        while (uniqueNumbers.Count < 4 && attempts < maxAttempts)
        {
            int randomNumber = Random.Range(1, RealRoomAmount - 2);

            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
            }

            attempts++;
        }
        prizeNumber = uniqueNumbers[0];
        shopNumber = uniqueNumbers[1];
        if (willUnicRoomSpawn) unicNumber = uniqueNumbers[2]; ; // -2 cause last 2 room always Boss and Finish;

        for (int i = 0; i < RealRoomAmount; i++)
        {
            FDArenaStart();
        }

    }

    async public void FDArenaStart()
    {

        GameObject Arena = ChooseAndSpawnNextRoom();

        //Destroy(previosArena);
        previosArena.GetComponentInChildren<NavMeshSurface>().RemoveData();
        nextArena.GetComponentInChildren<NavMeshSurface>().RemoveData();

        previosArena = nextArena;
        nextArena = Arena;

        ForwardArena_Room FDprevRoom = previosArena.GetComponent<ForwardArena_Room>();
        ForwardArena_Room FDNextRoom = Arena.GetComponent<ForwardArena_Room>();

        //FDprevRoom.back.SetActive(true);
        FDprevRoom.front.SetActive(false);

        FDNextRoom.back.SetActive(false);
        FDNextRoom.front.SetActive(true);
        FDNextRoom.id = FDprevRoom.id + 1;
        //FDNextRoom.lever.Target[^1] = gameObject;
        previosArena.GetComponentInChildren<NavMeshSurface>().RemoveData();

        await Task.Delay(100);
        if (FDNextRoom.id == roomAmount) nextArena.GetComponentInChildren<NavMeshSurface>().BuildNavMesh();
    }

    GameObject ChooseAndSpawnNextRoom()
    {
        ForwardArena_Room curretArena = nextArena.GetComponent<ForwardArena_Room>();

        Vector3 pos = curretArena.EnterToNewArena.position;
        Quaternion rot = transform.rotation;

        GameObject Arena;
        int id = curretArena.id + 1;

        if (id == prizeNumber)
        {
            Arena = PrizePrefabs[Random.Range(0, PrizePrefabs.Length)];
        }
        else if (id == shopNumber)
        {
            Arena = ShopPrefabs[Random.Range(0, ShopPrefabs.Length)];
        }
        else if (id == unicNumber)
        {
            Arena = unicPrefabs[Random.Range(0, unicPrefabs.Length)];
        }
        else if (id == RealRoomAmount - 1)
        {
            Arena = BossesPrefabs[Random.Range(0, BossesPrefabs.Length)];
        }
        else if (id == RealRoomAmount)
        {
            Arena = Finish;
        }
        else
        {
            Arena = ArenaPrefabs[Random.Range(0, ArenaPrefabs.Length)];
        }

        GameObject SpawnedArena = Instantiate(Arena, pos, rot);
        return SpawnedArena;
    }
}
