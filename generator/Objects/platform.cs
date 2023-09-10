using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
   float t = 0;
    public float AmpX = 0.25f;
    public float AmpY = 0.25f;
    public float AmpZ = 0.25f;
    public float Freq = 2;
    float OffsetX = 0;
    float OffsetY = 0;
    float OffsetZ = 0;
    public Vector3 StartPos;
    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
      
        t += Time.deltaTime;
        OffsetX = AmpX * Mathf.Sin(t * Freq);
        OffsetY = AmpY * Mathf.Sin(t * Freq);
        OffsetZ = AmpZ * Mathf.Sin(t * Freq);


        transform.position = StartPos + new Vector3(OffsetX, OffsetY, OffsetZ);

       // transform.Rotate(new Vector3(0.5f, 0, 0));
    }
}
