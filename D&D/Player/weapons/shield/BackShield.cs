using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackShield : MonoBehaviour
{
    public Sprite icon;

    public GameObject backShield;
    public int itemNumber;
    GunSwitch GunSwitch;
    ItemsIcons items;
    void Start()
    {
        items = gameObject.transform.root.GetComponentInChildren<ItemsIcons>();
        itemNumber = items.itemsCount;

        items.AddItem(icon);

        GunSwitch = gameObject.transform.parent.GetComponentInChildren<GunSwitch>();
      
       // Destroy(gameObject);
    }

    private void Update()
    {
        if (GunSwitch.currentWeapons[GunSwitch.currentWeapon].name != "shield")
        {

            backShield.SetActive(true);
        }
        else
        {
            backShield.SetActive(false);
        } 
        if (GunSwitch.currentWeapons[0].name == "shield") return;
        if (GunSwitch.currentWeapons[1].name == "shield") return;
        if (GunSwitch.currentWeapons[2].name == "shield") return;
        items.DeleteReorganizeItemIcons(itemNumber);
        backShield.SetActive(false);
        Destroy(gameObject);
    }
}
