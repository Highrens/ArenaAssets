using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilencerProcess : MonoBehaviour
{
    public Sprite icon;

    public string silentType = "middleSilencer";

    public GameObject silencer;
    public GameObject silentPS;
    void Start()
    {
        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);

        GameObject[] weapons = gameObject.transform.parent.GetComponentInChildren<GunSwitch>().allWeapons;

        for (int i = 0; i < weapons.Length; i++)
        {
            pistol_n weapon = weapons[i].GetComponentInChildren<pistol_n>();
            if (weapon.type.Contains(silentType) && !weapon.lazerType)
            {
                var silencerObj = Instantiate(silencer, weapon.shot_dot);
                silencerObj.transform.localPosition = Vector3.zero;
                silencerObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
                weapon.shot_dot = silencerObj.transform.GetChild(0);
                weapon.PS_obj = silentPS;
                weapon.accuracy *= 1.1f;
                Recoil weaponRecoil = weapons[i].GetComponentInChildren<Recoil>();
                weaponRecoil.rotationX *= 0.9f;
                weaponRecoil.rotationY *= 0.9f;
            }
        }
        Destroy(gameObject);
    }
}
