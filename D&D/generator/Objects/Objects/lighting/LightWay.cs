using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWay : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public bool state = false;

    // Update is called once per frame
    void Update()
    {
        if (state)  {
            on.SetActive(true);
            off.SetActive(false);
        } else {
            on.SetActive(false);
            off.SetActive(true);
        }
    }
}
