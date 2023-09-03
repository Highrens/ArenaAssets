using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сapacitor : MonoBehaviour
{
    public Sprite icon;

    void Start()
    {
        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);

        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            if (weapon.lazerType)
            {
                weapon.damage += 20;
                weapon.time_to_shot *= 0.85f;
            }
        }
        Destroy(gameObject);
    }
}
