using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartGun : MonoBehaviour
{
    public GameObject[] StartGuns;
    GunSwitch gunsScript;
    // Start is called before the first frame update
    void Start()
    {
        gunsScript = GetComponent<GunSwitch>();
        int randomPistol = Random.Range(0, StartGuns.Length);
        gunsScript.currentWeapons[0] = StartGuns[randomPistol];
        gunsScript.currentWeapons[0].SetActive(true);
    }
}
