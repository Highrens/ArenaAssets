using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int KeyCode;
    public bool isCard;
    public GameObject keyObj;
    public GameObject cardObj;
    Animator anim;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isCard = KeyCode >= 50;
        cardObj.SetActive(isCard);
        keyObj.SetActive(!isCard);
        hit = GetComponentInParent<interact>().Hit;
        if (hit.transform != null && hit.transform.GetComponentInParent<KeyLocked>() != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Open());

            }
            
        }

    }
    IEnumerator Open()
    {
        if (isCard)
        {
            anim.SetTrigger("UseCard");
        }
        else
        {
            anim.SetTrigger("UseKey");
        }
        float time = isCard ? 1 : 2;
        yield return new WaitForSeconds(time);
        if (hit.transform.GetComponentInParent<KeyLocked>()){
            hit.transform.GetComponentInParent<KeyLocked>().CheckKey(KeyCode);
        }
    }
}
