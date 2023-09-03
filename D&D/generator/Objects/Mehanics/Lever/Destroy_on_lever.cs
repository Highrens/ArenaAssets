using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_on_lever : MonoBehaviour
{
    public int signals;
    public int signal_to_destroy;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (signals >= signal_to_destroy)
        {
            Destroy(gameObject);
        }

    }
}
