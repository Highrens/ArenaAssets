using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Achivements))]
public class CollectableItem : MonoBehaviour
{
    public int AchivementNumber;
    public int CollectableNumber;
    public int id;
    public void Start()
    {
        if (PlayerPrefs.HasKey(CollectableNumber + " " + id))
        {
            Destroy(gameObject);
        }
    }
}
