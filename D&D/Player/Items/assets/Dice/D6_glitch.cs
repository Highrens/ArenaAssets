using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6_glitch : MonoBehaviour
{
    public Sprite icon;

    void Start()
    {
        if (transform.root.gameObject.name != "FPSPlayer") return;

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;

        Health heal = GetComponentInParent<Health>();
        int luck = Random.Range(1, 7);

        int health = luck * 25 - 75;
        heal.Health_max += health;

        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            luck = Random.Range(1, 7);
            weapon.damage += luck * 10 - 20;
            luck = Random.Range(1, 7);
            weapon.mobility += luck * 10 - 50;
            luck = Random.Range(1, 7);
            weapon.accuracy += luck * 10 - 50;
        }
        Destroy(gameObject);
    }
}
