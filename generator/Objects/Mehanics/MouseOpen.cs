using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOpen : MonoBehaviour
{
    public bool open;
    public bool locked;
    public float speed;
    public Vector3 rotateVector;
    public float t = 0;
    public float dir = 0;
    public float openTime;
    // Update is called once per frame
    void Update()
    {
        if (dir == 0) return;
        if (locked) return;
        t += Time.deltaTime;

        transform.Rotate(rotateVector, dir  * speed * Time.deltaTime * 100f);
        if (t > openTime) {
            dir = 0;
            t = 0;
            open = !open;
        }
    }
}
