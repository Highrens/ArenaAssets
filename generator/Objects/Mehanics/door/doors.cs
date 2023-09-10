using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour
{
    public bool door_is_locked = false;
    public GameObject locked_simbol;
    
    
    private void Start()
    {
        if (door_is_locked) locked_simbol.SetActive(true);
    }
    
    // Update is called once per frame
    public void ChangeState()
    {
        
            if (GetComponentInParent<Animator>().GetBool("Open"))
            {
                GetComponentInParent<Animator>().SetBool("Open", false);
            } 
            else
            {
                GetComponentInParent<Animator>().SetBool("Open", true);
            }   
    }
}
