using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6_item : MonoBehaviour
{
    public Sprite[] icons;

    void Start()
    {
        if (transform.root.gameObject.name != "FPSPlayer") return;
        int luck = Random.Range(1, 7);
        Debug.Log(luck);


        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icons[luck - 1]);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;

        Health heal = GetComponentInParent<Health>();
        int health = luck * 25 - 75;
        heal.Health_max += health; // -50 -25 0 +25 +50 +75 Hp
        int damage = luck * 10 - 20; // -10 0 10 20 30 40
        int mobility = luck * 10 - 40; // -30 -20 -10 0 10 20
        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            weapon.damage += damage;
            weapon.mobility += mobility;
            weapon.accuracy += mobility;
        }
        Destroy(gameObject);
    }
}


// 100 0
//