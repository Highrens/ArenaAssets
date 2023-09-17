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
            if (weapon.ammoType != "")
            {
                weapon.ammoType = "specialAmmo";
            }

        }
        AmmoScript ammoScript = gameObject.transform.root.GetComponentInChildren<AmmoScript>();

        ammoScript.specialAmmo = (ammoScript.specialAmmo + ammoScript.shotgunAmmo + ammoScript.bigAmmo + ammoScript.mediumAmmo + ammoScript.pistolAmmo) / 2;
        Destroy(gameObject);
    }
}
