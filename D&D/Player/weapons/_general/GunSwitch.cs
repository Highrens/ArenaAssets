using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public int currentWeapon;
    public GameObject[] currentWeapons;
    public GameObject[] allWeapons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseWeapon(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentWeapons[1] != null)
        {
           ChooseWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && GetComponentInParent<Pickups>().Health_Potion != 0)
        {
            ChooseWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GetComponentInParent<Pickups>().Stamina_Potion != 0)
        {
            ChooseWeapon(3);
        }


    }

    public void ChooseWeapon (int Weapon)
    {
        if (currentWeapons[Weapon] != null && currentWeapon != Weapon)
        {
            for (int i = 0; i < currentWeapons.Length; i++)
            {
                if (currentWeapons[i] != null && currentWeapons[i].GetComponentInChildren<pistol_n>() != null)
                {
                    currentWeapons[i].GetComponentInChildren<pistol_n>().reloading = false;
                    currentWeapons[i].GetComponentInChildren<pistol_n>().zoom = false;
                }
            }
            SwitchWeapon(Weapon);
        }
    }

    void SwitchWeapon(int num)
    {
        currentWeapon = num;
        
        for (int i = 0; i < currentWeapons.Length; i++)
        {
            if (i == num)
            {
                 currentWeapons[i].SetActive(true);

            }
            else
            {
                currentWeapons[i]?.SetActive(false);                 
            }
        }
    }
}