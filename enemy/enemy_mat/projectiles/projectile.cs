using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float Speed = 15;
    public int Damage = 10;
    Health Health_player;
    public bool destroyByWalls;
    public float armor_penetration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 8 && other.gameObject.GetComponent<Health>() != null)
        {
            Health_player = other.gameObject.GetComponent<Health>();
            if (Health_player.armor > 0)
            {
                Health_player.TakeDamage((int)(Damage * armor_penetration));
                Health_player.armor -= Damage;
            }
            else
            {
                Health_player.TakeDamage(Damage);
            }

            Destroy(gameObject);
        }
        else
        {
            if (other.transform.gameObject.layer == 11 || other.transform.gameObject.layer == 10) { }
            else
            {
                if (destroyByWalls) Destroy(gameObject);
            }
            
        }

    }
}
