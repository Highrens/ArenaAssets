using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject[] roomPrefabs; // Array of room prefabs to choose from
    public int numRooms;
    public GameObject startingRoom;
    public float DungeonSize;
    public List<GameObject> spawnedRooms = new List<GameObject>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        // Spawn the first room at the origin
        spawnedRooms.Add(startingRoom);


        for (int i = 0; i < numRooms; i++)
        {
            GameObject room = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], Vector3.zero, Quaternion.identity);
            float x = Random.Range(-DungeonSize, DungeonSize);
            float z = Random.Range(-DungeonSize, DungeonSize);
            room.transform.position = new Vector3(x, 0, z);
            for (int j = 0; j < spawnedRooms.Count; j++)
            {
                if (room.GetComponentInChildren<BoxCollider>().bounds.Intersects(spawnedRooms[j].GetComponentInChildren<BoxCollider>().bounds) )
                {
                    Debug.Log("HIT");
                   Destroy(room);
                } else
                {
                    spawnedRooms.Add(room);
                }
            }    
        }
    }

}