using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JetBrains.Annotations;
using TMPro;

public class MM_GunButton : MonoBehaviour
{
    public int weaponid;

    public bool first;
    public GameObject lockedBadge;
    public Image image;
    public Main_menu main_Menu;


    GunSwitch Guns;

    public int price;
    public TextMeshProUGUI price_text;
    public Button BuyButton;
    void Start()
    {
        Guns = main_Menu.gameObject.GetComponentInChildren<GunSwitch>();
        GameObject Gun = Guns.allWeapons[weaponid];
        Button btn = GetComponent<Button>();

        image.sprite = Gun.GetComponentInChildren<pistol_n>().icon;

        GetComponentInChildren<Text>().text = Gun.name;

        first = Gun.GetComponent<pistol_n>().ammoType == "";

        if (Gun
        .GetComponentInChildren<pistol_n>()
        .item.GetComponent<Gun_container>()
        .ReturnIsGunAlreadyUnlock()
        )
        {
            lockedBadge.SetActive(false);

            btn.onClick.AddListener(TaskOnClick);
        }
        if (PlayerPrefs.HasKey("weapon buyed" + weaponid) && BuyButton) {
            BuyButton.gameObject.SetActive(false);
        }
             
        if (BuyButton) {
            price_text.text = price.ToString();
            BuyButton.onClick.AddListener(Buy);
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        if (first)
        {
            main_Menu.SetFirstWeapon(weaponid);
        }
        else
        {
            main_Menu.SetSecondWeapon(weaponid);
        }

    }

    void Buy() {

        if (main_Menu.MoneyInBank < price) return;

        main_Menu.MoneyInBank -= price;
        main_Menu.MoneyInBank_text.text = main_Menu.MoneyInBank.ToString();
        PlayerPrefs.SetInt("MoneyInBank", main_Menu.MoneyInBank);
        PlayerPrefs.SetInt("weapon buyed" + weaponid, weaponid);
        BuyButton.gameObject.SetActive(false);
    }
    
}
