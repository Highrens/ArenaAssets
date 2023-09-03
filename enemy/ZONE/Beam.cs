using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float BeamDamage = 5;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 && other.transform.gameObject.GetComponent<Health>() != null)
        {
            other.transform.gameObject.GetComponent<Health>().TakeDamage((int)BeamDamage);
        
        }
    }
}
