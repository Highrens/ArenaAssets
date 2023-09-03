using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform sphere_;
    bool explode = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down * speed);
    }

    // Update is called once per frame
    void Update()
    {
     if (explode == true)
        {
            if (sphere_.localScale.x <= 10)
            {
                sphere_.localScale *= (1.1f + Time.deltaTime);
            }
            if (sphere_.localScale.x >= 10)
            {
                Destroy(gameObject);
            }
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(GetComponent<Rigidbody>());
        explode = true;
    }   
}
