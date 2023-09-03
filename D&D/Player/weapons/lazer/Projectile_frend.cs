using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_frend : MonoBehaviour
{

    public float Speed = 15;
    public int Damage = 10;
    public Vector3 dir;
    public bool destroyByEnemyTouch = true;
    public bool destroyByObstacles = true;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = dir * Speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 11 && other.gameObject.GetComponentInParent<Enemy_Health>() != null)
        {
            other.gameObject.GetComponentInParent<Enemy_Health>().Enemys_health -= Damage;
            if (destroyByEnemyTouch)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (destroyByObstacles == false) return;
            if (other.transform.gameObject.layer == 9 ||
                other.transform.gameObject.layer == 10 ||
                other.transform.gameObject.layer == 8) { }
            else Destroy(gameObject);

        }
    }
}
