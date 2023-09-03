using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsab_projectile : MonoBehaviour
{
    public float stopTime;
    float t = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
        t += Time.deltaTime;
        if (t > stopTime)
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.zero);
        }
    }
}
