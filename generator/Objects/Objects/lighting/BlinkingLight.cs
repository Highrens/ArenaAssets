using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public float MaxPeriod;
    
    public GameObject obj;
    float curretPeriod = 0;
    float t;

    // Update is called once per frame
    void Update()
    {
        if (!obj) return;
       
        if (t >= curretPeriod) {
            t = 0;
            curretPeriod = Random.Range(0, MaxPeriod);
            obj.SetActive(!obj.activeInHierarchy);
        }
        t += Time.deltaTime;
        
    }
}
