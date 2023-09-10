using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLeverDoor : MonoBehaviour
{
    public int signals;
    public int Levers;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (signals == Levers)
        {
            GetComponentInParent<Animator>().SetBool("Open", true);
        }
        else
        {
            GetComponentInParent<Animator>().SetBool("Open", false);

        }
        
    }
    public void ChangeState()
    {
        /*
        if (GetComponentInParent<Animator>().GetBool("Open"))
        {
            GetComponentInParent<Animator>().SetBool("Open", false);
        }
        else
        {
            GetComponentInParent<Animator>().SetBool("Open", true);
        }
        */
    }
}
