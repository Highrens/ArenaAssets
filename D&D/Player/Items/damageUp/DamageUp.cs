using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    public Sprite icon;
    void Start()
    {
        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {

            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            weapon.damage += 10;
        }
        Destroy(gameObject);
    }
}
