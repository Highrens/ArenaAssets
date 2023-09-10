using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class ForwardArena : MonoBehaviour
{
    public GameObject[] ArenaPrefabs;
    public GameObject[] ShopPrefabs;
    public GameObject[] BossesPrefabs;
    public GameObject[] PrizePrefabs;
    int prizenumber;
    public GameObject previosArena;
    public GameObject nextArena;
    public List<GameObject> spawnedEnemys = new List<GameObject>();
    public Lever lever;

    private void Start()
    {
        prizenumber = Random.Range(1, 10);
        if (prizenumber % 5 == 0)
        {
            prizenumber--;
        }
    }

    public void FDArenaStart()
    {
        ForwardArena_Room curretArena = nextArena.GetComponent<ForwardArena_Room>();

        int ArenaNum;
        GameObject Arena;
        Debug.Log(curretArena.id % 5);

        if (curretArena.id + 1 == prizenumber)
        {
            ArenaNum = Random.Range(0, PrizePrefabs.Length);
            Arena = Instantiate(PrizePrefabs[ArenaNum],
                curretArena.EnterToNewArena.position,
                transform.rotation);
        }
        else if (curretArena.id % 5 == 0 && curretArena.id != 0)
        {
            ArenaNum = Random.Range(0, ShopPrefabs.Length);
            Arena = Instantiate(ShopPrefabs[ArenaNum],
                curretArena.EnterToNewArena.position,
                transform.rotation);
        }
        else if (curretArena.id % 11 == 0 && curretArena.id != 0)
        {
            ArenaNum = Random.Range(0, BossesPrefabs.Length);
            Arena = Instantiate(BossesPrefabs[ArenaNum],
                curretArena.EnterToNewArena.position,
                transform.rotation);
        }
        else
        {
            ArenaNum = Random.Range(0, ArenaPrefabs.Length);
            Arena = Instantiate(ArenaPrefabs[ArenaNum],
                curretArena.EnterToNewArena.position,
                transform.rotation);
        }

        Destroy(previosArena);
        previosArena = nextArena;
        nextArena = Arena;

        ForwardArena_Room FDprevRoom = previosArena.GetComponent<ForwardArena_Room>();
        ForwardArena_Room FDNextRoom = Arena.GetComponent<ForwardArena_Room>();

        FDprevRoom.back.SetActive(true);
        FDprevRoom.front.SetActive(false);

        FDNextRoom.back.SetActive(false);
        FDNextRoom.front.SetActive(true);
        FDNextRoom.id = FDprevRoom.id + 1;
        FDNextRoom.lever.Target[^1] = gameObject;
        
    }
}
