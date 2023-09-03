using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage_proj : MonoBehaviour
{
    public GameObject Cage;
    public float Speed = 15;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 8 && other.gameObject.GetComponent<Health>() != null)
        {
            Instantiate(Cage, other.gameObject.transform.position, Quaternion.Euler(0,0,0));
            Destroy(gameObject);
        }
        else
        {
            if (other.transform.gameObject.layer == 9 || other.transform.gameObject.layer == 11 || other.transform.gameObject.layer == 10) { }
            else Destroy(gameObject);

        }
    }

}
