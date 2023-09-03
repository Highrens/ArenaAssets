using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMoreBullet : MonoBehaviour
{
    public Sprite icon;
    void Start()
    {

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();

            weapon.ammo_max++;
            weapon.ammo++;
        }
        Destroy(gameObject);
    }
}
