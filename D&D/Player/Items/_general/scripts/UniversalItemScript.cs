using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalItemScript : MonoBehaviour
{
    public Sprite icon;

    public float recoilX = 1;
    public float recoilY = 1;

    public int damage;
    public int mobility;
    public float spread;
    public float time_to_shot = 1;
    public int ammoMax;

    void Start()
    {

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            weapon.damage += damage;
            weapon.mobility += mobility;
            weapon.Spread *= spread;
            weapon.time_to_shot *= time_to_shot;
            weapon.ammo_max += ammoMax;
            Recoil weaponRecoil = weapons[i].GetComponentInChildren<Recoil>();
            weaponRecoil.rotationX *= recoilX;
            weaponRecoil.rotationY *= recoilY;
        }
        Destroy(gameObject);
    }
}
