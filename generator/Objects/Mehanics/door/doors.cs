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
        if (door_is_locked) return;
        Debug.Log("open") ;  
            if (GetComponent<Animator>().GetBool("Open"))
            {
                GetComponent<Animator>().SetBool("Open", false);
            } 
            else
            {
                GetComponent<Animator>().SetBool("Open", true);
            }   
    }
}
