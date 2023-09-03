using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessRecoilProcess : MonoBehaviour
{
    public Sprite icon;
    void Start()
    {

        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;
        for (int i = 0; i < weapons.Length; i++)
        {
            Recoil weapon = weapons[i].GetComponentInChildren<Recoil>();
            weapon.rotationX *= 0.8f;
            weapon.rotationY *= 0.8f;
        }
        Destroy(gameObject);
    }
}
