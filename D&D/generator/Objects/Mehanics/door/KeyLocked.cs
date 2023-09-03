using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLocked : MonoBehaviour
{
    public GameObject lockedObj;

    public int KeyCode;
    public AudioClip wrong;
    public AudioClip accept;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    public void CheckKey(int key)
    {
        if (key == KeyCode)
        {
            if (lockedObj.GetComponent<doors>()) lockedObj.GetComponent<doors>().door_is_locked = false;
            if (lockedObj.GetComponent<MouseOpen>()) lockedObj.GetComponent<MouseOpen>().locked = false;
            if (GetComponentInChildren<LightWay>()) GetComponentInChildren<LightWay>().state = true;

            if (!AS) return;
            AS.clip = accept;
            AS.Play();
        }
        else
        {
            if (!AS) return;
            AS.clip = wrong;
            AS.Play();
        }
    }
}
