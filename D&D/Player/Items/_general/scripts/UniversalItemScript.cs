using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalItemScript : MonoBehaviour
{
    public Sprite icon;
    public int Health_max;
    public int Health;
    public float stamina_cost;
    public float jumpSpeed;
    public float gravity;
    public float recoilX = 1;
    public float recoilY = 1;
    
    public int damage;
    public int mobility;
    public float spread = 1;
    public float time_to_shot = 1;
    public int ammoMax;

    void Start()
    {
        if (transform.root.gameObject.name != "FPSPlayer") return;

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;

        Health heal = GetComponentInParent<Health>();
        heal.Health_max += Health_max;
        heal.Player_health += Health;
        heal.stamina_cost += stamina_cost;

        SC_FPSController FPSController = GetComponentInParent<SC_FPSController>();
        FPSController.jumpSpeed += jumpSpeed;
        FPSController.gravity += gravity;
        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            weapon.damage += damage;
            weapon.mobility += mobility;
            weapon.accuracy *= spread;
            weapon.time_to_shot *= time_to_shot;
            weapon.ammo_max += ammoMax;
            Recoil weaponRecoil = weapons[i].GetComponentInChildren<Recoil>();
            weaponRecoil.rotationX *= recoilX;
            weaponRecoil.rotationY *= recoilY;
        }
        Destroy(gameObject);
    }
}
