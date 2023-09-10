using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{

    public float Time_to_destroy = 3;
   public float t = 0;
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= Time_to_destroy) Destroy(gameObject);
    }
}
