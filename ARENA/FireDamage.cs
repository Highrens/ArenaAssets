using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public int damage;
    public float time;
    float t;
    public GameObject target;
    public GameObject dmg;

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;
        if (t >= 1)
        {
            Instantiate(dmg, transform.position, transform.rotation, transform);
            t = 0;
        }

    }
    
    void DealDamage()
    {
        if (!target) return;
        if (target.layer == 8 && target.GetComponent<Health>() != null)
        {
            Health Health_player = target.GetComponent<Health>();
            Health_player.TakeDamage(damage);
        }
        if (target.layer == 11 && target.GetComponentInParent<Enemy_Health>() != null)
        {
            target.GetComponentInParent<Enemy_Health>().Enemys_health -= damage;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        target = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        // if (target == other.gameObject)
        // {
        //     target = null;
        // }
    }
}
