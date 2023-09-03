using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAdd50 : MonoBehaviour
{
    public Sprite icon;
    void Start()
    {

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GetComponentInParent<Health>().Health_max += 50;
        Destroy(gameObject);
    }
}
