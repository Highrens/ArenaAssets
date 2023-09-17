using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sniper : MonoBehaviour
{
    public Transform[] way;
    public Transform target;
    public GameObject spoted;
    public float time_to_next_point;
    public float time_to_shot;
    public float accruacy;
    public GameObject Hit_ps;
    public Transform Shot_point;
    public GameObject[] teammates;
    public int Damage = 50;
    public float armor_penetration = 0.4f;
           float t;  
           NavMeshAgent agent;
           int x = 0;
           int x_max; 
           Vector3 rot;
           AudioSource AS;
  
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        x_max = way.Length;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t >= time_to_next_point && target == null)
        {
            if (x == x_max-1)
            {
                x = 0; 
            }
            else
            {
                x++;
            }          
            t = 0;
            agent.destination = way[x].position;
        }
        if (target != null)
        {
            agent.destination = target.position;
            if (t >= time_to_shot)
            {
                Shot();
            }
        }



    }
    void OnTriggerStay(Collider other)
    {
        rot =  other.transform.position - transform.position;
        RaycastHit hit;
        Debug.DrawRay(transform.position,rot , Color.white);
        Physics.Raycast(transform.position, rot, out hit, 300);
        if (hit.transform.gameObject.layer == 8)
        {
            spoted.SetActive(true);
            target = hit.transform;
            for (int i = 0; i <= teammates.Length-1; i++)
            {
                if (teammates[i] != null && teammates[i].GetComponentInChildren<sniper>() != null)
                {
                    teammates[i].GetComponentInChildren<sniper>().target = other.gameObject.transform;
                }   
           
            }
        }

    }
    public void Shot()
    {
        AS.Play();


        RaycastHit hit;
        float x = Random.Range(-accruacy, accruacy);
        Physics.Raycast(Shot_point.position, rot + new Vector3(x, x, 0), out hit, 300);
        Instantiate(Hit_ps, hit.point, transform.rotation);

        if (hit.transform.gameObject.layer == 8 && target.gameObject.GetComponent<Health>() != null)
        {
            Health Health_player = target.gameObject.GetComponent<Health>();

            if (Health_player.armor > 0)
            {
                Health_player.Player_health -= (float)(Damage * armor_penetration);
                Health_player.armor -= (int)(Damage * armor_penetration);
            }
            else
            {
                Health_player.TakeDamage(Damage);
            }
        }
        t = 0;
    }
}
