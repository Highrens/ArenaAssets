using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWay : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public bool state;


   public void ChangeState()
    {
        state = !state;
        if (on) on.SetActive(state);
        if (off) off.SetActive(!state);
    }

}
