using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    Animator anim;
    float t;
    public Vector3 start_pos;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.Translate(new Vector3(0, 0, -1) * 12 * Time.deltaTime, Space.Self);
        if (t > 1.25f)
        {
            anim.SetTrigger("down");
        }
    }
}
