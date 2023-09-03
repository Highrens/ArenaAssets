using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoChildDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {   
            if(GetComponentInParent<Animator>()) GetComponentInParent<Animator>().SetTrigger("change");
            Destroy(gameObject);
        }
    }
}
