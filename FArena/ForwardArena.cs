using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardArena : MonoBehaviour
{
    public GameObject back;
    public GameObject front;
    public GameObject[] ArenaPrefabs;

    public Vector3 offset;

    bool allDead;
    public List<GameObject> spawnedEnemys = new List<GameObject>();

    // Start is called before the first frame update
    public void FDArenaStart()
    {
        back.SetActive(true);

        GameObject Arena = ArenaPrefabs[Random.Range(0, ArenaPrefabs.Length - 1)];

        while (Arena.name == gameObject.name)
        {
            Arena = ArenaPrefabs[Random.Range(0, ArenaPrefabs.Length - 1)];
        }
        
        Instantiate(Arena, gameObject.transform.position + offset, transform.rotation);

        front.SetActive(false);
    }

    public void IsAllEnemyDeadCheck()
    {
        allDead = spawnedEnemys.TrueForAll(x => x == null);
        if (allDead == true)
        {
            UnlockNextStage();
        }
    }
    
    public void UnlockNextStage () {

    }
}
