using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    public float timeToExplode;
           float timer = 0;
           bool  onTimer = false;
    public GameObject explodeObject;

    void Update()
    {
        if (onTimer == true)
        {
            timer += Time.deltaTime;
            if(timer >= timeToExplode)
            {
                Explode();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.layer == 8)
        {
            onTimer = true;
        }
        
    }
    void Explode()
    {
        Instantiate(explodeObject);
        Destroy(gameObject);
    }
}
