using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak_platform : MonoBehaviour
{
     float t = 0;
    public float DestroyTime = 3f;
    public Vector3 StartPos;
    private void Start()
    {
        StartPos = transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        t += Time.deltaTime;
        if (t > DestroyTime)
        {
            Destroy(gameObject);
        }
        transform.position = StartPos + new Vector3(0, 0.05f * Mathf.Sin(t * 10f), 0);

    }
}
