using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullets : MonoBehaviour
{
    public Sprite icon;
    void Start()
    {

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            weapon.shotAmount *= 3;
            weapon.Spread = (weapon.Spread + 0.03f) * 2;
            weapon.time_to_shot *= 1.3f;
        }
        Destroy(gameObject);
    }
}
