using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    public int GameComplite = 0;

    public void Start () {
        if (GetComponentInChildren<Pickups>()) {
            LoadGame(gameObject);
        } else {
            LoadGame();
        }
        
    }

    public void SaveGame(GameObject Player = null)
    {
        PlayerPrefs.SetInt("SavedInteger", GameComplite);
        if (Player)
        {
            Pickups inv = Player.GetComponentInChildren<Pickups>();
            GunSwitch guns = Player.GetComponentInChildren<GunSwitch>();
            Health health = Player.GetComponentInChildren<Health>();

            PlayerPrefs.SetInt("Cards", inv.keys);
            PlayerPrefs.SetInt("HealthPotions", inv.Health_Potion);
            PlayerPrefs.SetInt("StaminaPotions", inv.Stamina_Potion);
            PlayerPrefs.SetInt("coins", inv.Coins);
            PlayerPrefs.SetInt("FirstWeapon", guns.currentWeapons[0].GetComponentInChildren<pistol_n>().item.GetComponentInChildren<Gun_container>().gun);
            if (guns.currentWeapons[1]) PlayerPrefs.SetInt("SecondWeapon", guns.currentWeapons[1].GetComponentInChildren<pistol_n>().item.GetComponentInChildren<Gun_container>().gun);
            //    if (guns.currentWeapons[2]) PlayerPrefs.SetInt("ThirdWeapon", guns.currentWeapons[2].GetComponentInChildren<pistol_n>().item.GetComponentInChildren<Gun_container>().gun);
            PlayerPrefs.SetFloat("PlayerHealth", health.Player_health);
            PlayerPrefs.SetInt("PlayerArmor", health.armor);
        }

        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    public void LoadGame(GameObject Player = null)
    {
       // if (PlayerPrefs.HasKey("SavedInteger"))
       // {
            GameComplite = PlayerPrefs.GetInt("SavedInteger");
            if (Player)
            {
                GunSwitch guns = Player.GetComponentInChildren<GunSwitch>();
                Pickups inv = Player.GetComponentInChildren<Pickups>();
                inv.keys = PlayerPrefs.GetInt("Cards");
                inv.Health_Potion = PlayerPrefs.GetInt("HealthPotions");
                inv.Stamina_Potion = PlayerPrefs.GetInt("StaminaPotions");
                inv.Coins = PlayerPrefs.GetInt("coins");
                for (int i = 0; i < guns.allWeapons.Length; i++)
                {
                    guns.allWeapons[i].SetActive(false);
                }
                guns.currentWeapons[0] = guns.allWeapons[PlayerPrefs.GetInt("FirstWeapon")];
                guns.currentWeapons[0].SetActive(true);
                if (PlayerPrefs.HasKey("SecondWeapon")) guns.currentWeapons[1] = guns.allWeapons[PlayerPrefs.GetInt("SecondWeapon")];
                // guns.currentWeapons[2] = guns.allWeapons[PlayerPrefs.GetInt("ThirdWeapon")];
            }
      //  }
      //  else
      //      Debug.Log("There is no save data!");
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        GameComplite = 0;
        if (GetComponent<Main_menu>()) {
            GetComponent<Main_menu>().ResetWeapons();
        }
        Debug.Log("Data reset complete");
    }
}
