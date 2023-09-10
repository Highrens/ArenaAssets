using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOntouch : MonoBehaviour
{
    public GameObject explode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 10) return;
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
