using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZONE : MonoBehaviour
{
    public float movespeed;
    float t;
    public float DamageTickRate;

    GameObject player;
    public GameObject ZoneDamageUi;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(movespeed, 0, 0);
        movespeed += 0.000003f;
        t += Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == 8)
        {
            player = other.gameObject;
            if ( t >= DamageTickRate)
            {
                GiveDamage();
                t = 0;
            }
            ZoneDamageUi.SetActive(true);
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        ZoneDamageUi.SetActive(false);
    }
    void GiveDamage()
    {
        player.transform.gameObject.GetComponentInParent<Health>().Player_health -= 1;
    }
}
