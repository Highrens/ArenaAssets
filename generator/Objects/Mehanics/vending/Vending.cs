using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vending : MonoBehaviour
{
    Animator anim;
    public int button_number;
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    // Update is called once per frame

  public IEnumerator Buy ()
    {
     
        for (int i = 0; i < button_number; i++)
        {
            anim.SetTrigger("coin");
            yield return new WaitForSeconds(1);
        }
        
        anim.SetInteger("way", button_number);
        yield return new WaitForSeconds(2);
        anim.SetInteger("way", 0);
    }
}
