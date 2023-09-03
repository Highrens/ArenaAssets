using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    public Sprite icon;
    public GameObject projectile;
    public GameObject lazerPsObj;
    void Start()
    {

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            if (!weapon.lazerType)
            {
                weapon.lazerType = true;
                if (weapon.projectile == null)
                {
                    weapon.projectile = projectile;
                }
                weapon.PS_obj = lazerPsObj;
            }
           


        }
        Destroy(gameObject);
    }
}
