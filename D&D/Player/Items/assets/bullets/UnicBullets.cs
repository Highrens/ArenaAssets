using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicBullets : MonoBehaviour
{
    public Sprite icon;
    public GameObject newHit;
    public int Damage;
    public float time_to_shot;
    public int shotAmount;
    public GameObject projectile;
    void Start()
    {
        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);

        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            weapon.damage += Damage;
            weapon.Hit_ps = newHit;
        }
    }
}
