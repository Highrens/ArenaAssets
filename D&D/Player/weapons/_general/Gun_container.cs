using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Achivements))]
public class Gun_container : MonoBehaviour
{ 
    public int gun;
    public int unlockAchivenentNumber;
    public bool needToUnlock;
    public string GunName = "Missing Name";
    public string GunDiscription = "Missing Discripton";
    public bool ReturnIsGunAlreadyUnlock()
    {
        GetComponent<Achivements>().GetAchivements();
        if ( needToUnlock == true && GetComponent<Achivements>().achiv[unlockAchivenentNumber, 1] == "no")
        {
            return false;
        }
        return true;
    }
}