using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 8 && other.transform.gameObject.GetComponent<Health>() != null)
        {
            other.transform.gameObject.GetComponent<Health>().Player_health -= 100;
        }
    }
}
