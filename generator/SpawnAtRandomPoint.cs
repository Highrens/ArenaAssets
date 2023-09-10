using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtRandomPoint : MonoBehaviour
{
    public string spawnName = "¬ведите им€ спауна";
    public GameObject ObjectToSpawn;
    List<GameObject> filtredObj = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.name == spawnName)
            {
                filtredObj.Add(obj);
            }
        }
        int index = Random.Range(0, filtredObj.Count);
        Instantiate(ObjectToSpawn, filtredObj[index].transform.position, filtredObj[index].transform.rotation, filtredObj[index].transform);
    }
}
