using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaAchivements : MonoBehaviour
{
    Arena arena;
    
    // Start is called before the first frame update
    void Start()
    {
        arena = GetComponent<Arena>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arena.waveNumber == 10)
        {
            arena.player.GetComponentInChildren<SimpleAchivement>().ShowAndSaveAchivement(7);
        }
        if (arena.waveNumber == 20)
        {
            arena.player.GetComponentInChildren<SimpleAchivement>().ShowAndSaveAchivement(8);
        }
    }
}
