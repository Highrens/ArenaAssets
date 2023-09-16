using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interact : MonoBehaviour
{
    public float SizeOfRay;
    int layerMask = 1 << 8;
    public RaycastHit Hit;
    public Transform RayPoint;
    public GameObject InteractSing;
    public GameObject holdObject = null;
    public Message message;
    public Achivements ach;
    Pickups inv;
    AmmoScript ammo;
    public void Start()
    {
        inv = GetComponent<Pickups>();
        ammo = GetComponent<AmmoScript>();
    }
    void Update()
    {
        layerMask = ~layerMask;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Physics.Raycast(RayPoint.position, fwd, out Hit, SizeOfRay);

        if (Hit.transform != null && Hit.transform.gameObject.layer == 7)
        {
            InteractSing.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                Interact();
            }

        }
        else
        {
            InteractSing.SetActive(false);
            if (holdObject != null)
            {
                ReleaseObject();

            }
        }

    }
    void Interact()
    {
        if (holdObject != null)
        {
            ReleaseObject();
        }
        else
        {
            if (Hit.transform.GetComponentInParent<doors>() != null)
            {
                doors door = Hit.transform.GetComponentInParent<doors>();
                if (door.door_is_locked == true && inv.keys > 0)
                {
                    inv.keys -= 1;
                    door.door_is_locked = false;
                    door.ChangeState();
                }
                else
                {
                    door.ChangeState();
                }
            }
            if (Hit.transform.GetComponentInParent<Pickups>() != null)
            {
                Pickups pickups = Hit.transform.GetComponent<Pickups>();
                inv.keys += pickups.keys;
                inv.Health_Potion += pickups.Health_Potion;
                inv.Stamina_Potion += pickups.Stamina_Potion;
                inv.Coins += pickups.Coins;
                Destroy(Hit.transform.gameObject);
            }
            if (Hit.transform.GetComponentInParent<AmmoScript>() != null)
            {
                var floorAmmo = Hit.transform.GetComponentInParent<AmmoScript>();
                ammo.pistolAmmo += floorAmmo.pistolAmmo;
                ammo.mediumAmmo += floorAmmo.mediumAmmo;
                ammo.bigAmmo += floorAmmo.bigAmmo;
                ammo.shotgunAmmo += floorAmmo.shotgunAmmo;
                ammo.specialAmmo += floorAmmo.specialAmmo;

                Destroy(Hit.transform.gameObject);
            }
            Hit.transform.GetComponent<Lever>()?.Interact_with_taget();
            if (Hit.transform.GetComponentInParent<Gun_container>() != null)
            {
                GunSwitch gun = GetComponentInChildren<GunSwitch>();
                Gun_container newGun = Hit.transform.GetComponentInParent<Gun_container>();
                gun.currentWeapons[gun.currentWeapon].SetActive(false);

                if (gun.allWeapons[newGun.gun].GetComponent<pistol_n>().type.Contains("pistol"))
                {
                    var oldGun = Instantiate(gun.currentWeapons[0].GetComponentInChildren<pistol_n>().item, Hit.transform.position, Hit.transform.rotation);
                    oldGun.transform.parent = Hit.transform.parent;
                    gun.currentWeapons[0] = gun.allWeapons[newGun.gun];

                    message.ShowMessage(newGun.GunName, newGun.GunDiscription);
                    gun.currentWeapons[0].SetActive(true);
                    Destroy(Hit.transform.gameObject);
                    return;
                }
                else if (gun.currentWeapons[1] == null)
                {
                    gun.currentWeapons[1] = gun.allWeapons[newGun.gun];
                    gun.ChooseWeapon(1);
                }
                else
                {
                    var oldGun = Instantiate(gun.currentWeapons[gun.currentWeapon].GetComponentInChildren<pistol_n>().item, Hit.transform.position, Hit.transform.rotation);
                    oldGun.transform.parent = Hit.transform.parent;
                    gun.currentWeapons[gun.currentWeapon] = gun.allWeapons[newGun.gun];
                }
                message.ShowMessage(newGun.GunName, newGun.GunDiscription);
                gun.currentWeapons[gun.currentWeapon].SetActive(true);
                Destroy(Hit.transform.gameObject);

            }
            if (Hit.transform.GetComponent<Vending>() != null)
            {
                if (inv.Coins >= Hit.transform.GetComponentInParent<Vending>().button_number)
                {
                    inv.Coins -= Hit.transform.GetComponentInParent<Vending>().button_number;
                    StartCoroutine(Hit.transform.GetComponent<Vending>().Buy());
                }

            }
            if (Hit.transform.GetComponentInParent<Moveable>() != null)
            {

                holdObject = Hit.transform.gameObject;

                holdObject.GetComponent<Rigidbody>().useGravity = false;
                Hit.transform.SetParent(gameObject.transform);

                //  Hit.transform.GetComponentInParent<Moveable>().StartMove(Hit.transform.position);
                //   Hit.transform.gameObject.transform.position = Hit.transform.position;

            }
            if (Hit.transform.GetComponentInParent<ShopCell>() != null)
            {
                ShopCell Cell = Hit.transform.GetComponentInParent<ShopCell>();
                if (inv.Coins >= Cell.price)
                {
                    inv.Coins -= Cell.price;
                    Cell.Sold();
                }
            }
            if (Hit.transform.GetComponent<CollectableItem>() != null)
            {
                Collectible coll = GetComponent<Collectible>();
                CollectableItem item = Hit.transform.GetComponentInParent<CollectableItem>();
                ach.GetAchivements();
                if (ach.achiv[item.AchivementNumber, 1] == "no" && !PlayerPrefs.HasKey(item.CollectableNumber + " " + item.id))
                {
                    coll.Collectibles[item.CollectableNumber, 0]++;
                    if (coll.Collectibles[item.CollectableNumber, 0] >= coll.Collectibles[item.CollectableNumber, 1])
                    {
                        ach.transform.gameObject.GetComponent<SimpleAchivement>().ShowAndSaveAchivement(item.AchivementNumber);
                        ach.achiv[item.AchivementNumber, 1] = "yes";
                    }
                    message.ShowMessage(coll.Collectibles[item.CollectableNumber, 0] + " / " + coll.Collectibles[item.CollectableNumber, 1]
                        , ach.achiv[item.AchivementNumber, 0]);
                    PlayerPrefs.SetInt(item.CollectableNumber + " " + item.id, 0);
                }
                Destroy(Hit.transform.gameObject);
            }
            if (Hit.transform.GetComponent<ItemScriptHandler>())
            {
                ItemScriptHandler item = Hit.transform.GetComponent<ItemScriptHandler>();
                item.ItemUse(transform);
                message.ShowMessage(item.itemName, item.Discription);
                Destroy(Hit.transform.gameObject);
            }
            if (Hit.transform.GetComponentInParent<shield>())
            {
                GetComponentInParent<Health>().AddShield(Hit.transform.GetComponentInParent<shield>().armor);
                Destroy(Hit.transform.gameObject);
            }
            if (Hit.transform.GetComponent<Price>())
            {
                int price = Hit.transform.GetComponent<Price>().price;
                Hit.transform.GetComponentInParent<TimeBomb>()?.InsertNumber(price);

                if (Hit.transform.GetComponentInParent<Bank>())
                {
                    if (price > 0)
                    {
                        if (inv.Coins > 0)
                        {
                            Hit.transform.GetComponentInParent<Bank>().AddMoneyInBank();
                            inv.Coins--;
                        }
                    }
                    else
                    {
                        if (Hit.transform.GetComponentInParent<Bank>().TakeMoneyFromBank())
                        {
                            inv.Coins++;
                        }
                    }

                }
            }
            if (Hit.transform.GetComponent<Switchbox>())
            {
                Switchbox switchbox = Hit.transform.GetComponent<Switchbox>();
                switchbox.ChangeLight();
            }
            if (Hit.transform.GetComponent<MouseOpen>())
            {
                MouseOpen obj = Hit.transform.GetComponent<MouseOpen>();
                if (obj.open)
                {
                    obj.dir = 1;
                }
                else
                {
                    obj.dir = -1;
                }
            }
            if (Hit.transform.GetComponent<moveBox>() != null)
            {
                Hit.transform.GetComponent<moveBox>().opened = !Hit.transform.GetComponent<moveBox>().opened;
            }
        }

    }
    void ReleaseObject()
    {
        holdObject.GetComponent<Rigidbody>().useGravity = true;
        holdObject.transform.parent = null;
        holdObject = null;
    }
}
