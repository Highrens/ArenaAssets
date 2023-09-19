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
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = dir * Speed;

        if (GetComponent<ExplodeOntouch>()?.gameObject.GetComponent<Projectile_frend>())
        {
            GetComponent<ExplodeOntouch>().gameObject.GetComponent<Projectile_frend>().Player = Player;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 11 && other.gameObject.GetComponentInParent<Enemy_Health>() != null)
        {
            Enemy_Health enemy_Health = other.gameObject.GetComponentInParent<Enemy_Health>();
            enemy_Health.Enemys_health -= Damage;
            enemy_Health.Player = Player;
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
