using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int[,] Collectibles =
    {
       {0, 5},          //5 - "You not suppose to be here!"  PlayerPrefs.HasKey(CollectableNumber + " " + id)
    };
    private void Awake()
    {
        for (int i = 0; i < Collectibles.Length - 1; i++) // номер достижения
        {
            for (int x = 0; x <= Collectibles[i, 1]; x++) // id собранных
            {
                if (PlayerPrefs.HasKey(i + " " + x))
                {
                    Collectibles[i, 0]++;                  
                }
            }           
        }
    }
}
