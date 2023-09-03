using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBox : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public bool opened = false;
    public float openSlow = 1;
    public float t = 0;
    float direction;
    // Start is called before the first frame update
    public void FixedUpdate()
    {
        t = Mathf.Clamp01(t);
        if (opened)
        {
            t += Time.deltaTime / openSlow;
        } else
        {
            t -= Time.deltaTime / openSlow;
        }
        direction = endPos.x; // endPos - startPos; 
        transform.localPosition = new Vector3(direction * t, startPos.y, startPos.z);
    }
}
