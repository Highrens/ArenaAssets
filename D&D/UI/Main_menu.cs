using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_menu : MonoBehaviour
{
    public int PlayScene;
    public int TestScene;

    public int FirstWeapon;
    public int SecondWeapon;

    public Image curretFirstWeapon;
    public Image curretSecondWeapon;

    GunSwitch gunSwitch;

    public int MoneyInBank;
    public TextMeshProUGUI MoneyInBank_text;
    // Update is called once per frame

    private void Start()
    {
        if (PlayerPrefs.HasKey("MoneyInBank"))
        {
            MoneyInBank = PlayerPrefs.GetInt("MoneyInBank");
            MoneyInBank_text.text = MoneyInBank.ToString();
        }


        gunSwitch = GetComponentInChildren<GunSwitch>();
        Time.timeScale = 1;
        if (PlayerPrefs.HasKey("FirstWeapon"))
        {
            FirstWeapon = PlayerPrefs.GetInt("FirstWeapon");
        }
        if (PlayerPrefs.HasKey("SecondWeapon"))
        {
            SecondWeapon = PlayerPrefs.GetInt("SecondWeapon");
        }
        curretFirstWeapon.sprite = gunSwitch.allWeapons[FirstWeapon].GetComponent<pistol_n>().icon;
        curretSecondWeapon.sprite = gunSwitch.allWeapons[SecondWeapon].GetComponent<pistol_n>().icon;
    }

    public void SetFirstWeapon(int number)
    {
        PlayerPrefs.SetInt("FirstWeapon", number);
        curretFirstWeapon.sprite = gunSwitch.allWeapons[number].GetComponent<pistol_n>().icon;
    }

    public void SetSecondWeapon(int number)
    {
        PlayerPrefs.SetInt("SecondWeapon", number);
        curretSecondWeapon.sprite = gunSwitch.allWeapons[number].GetComponent<pistol_n>().icon;
    }

    public void ResetWeapons()
    {
        PlayerPrefs.SetInt("FirstWeapon", 0);
        //PlayerPrefs.SetInt("SecondWeapon", 3);
        curretSecondWeapon.sprite = gunSwitch.allWeapons[3].GetComponent<pistol_n>().icon;
        curretFirstWeapon.sprite = gunSwitch.allWeapons[0].GetComponent<pistol_n>().icon;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void PlayGame()
    {
        SceneManager.LoadScene(PlayScene);
    }
    public void PlayTest()
    {
        SceneManager.LoadScene(TestScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
