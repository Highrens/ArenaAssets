using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    public GameObject render;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 1f)
        {
            render.SetActive(true);
            if (t >= 1.5f) GetComponentInChildren<Animator>().SetTrigger("down");
        }
    }
}
