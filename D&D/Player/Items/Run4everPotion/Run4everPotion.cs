using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run4everPotion : MonoBehaviour
{
    public Sprite icon;
    void Start()
    {
        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GetComponentInParent<Health>().stamina_cost = 0;
        Destroy(gameObject);
    }
}
