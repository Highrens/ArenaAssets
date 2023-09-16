using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLeverDoor : MonoBehaviour
{
    public int signals;
    public int Levers;

    public void ChangeState()
    {
        GetComponentInParent<Animator>()?.SetBool("Open", signals == Levers);
        if (signals == Levers) {
            if (GetComponent<AudioSource>()) {
                GetComponent<AudioSource>().Play();
            }
        }
        
    }
}
