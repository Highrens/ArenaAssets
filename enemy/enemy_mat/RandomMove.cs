using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    public GameObject Target;
    public NavMeshAgent agent;
    public GameObject projectile;
    Vector3 Start_pos;
    public Transform Shot_rot;

    float t = 0;
    float m = 0;
    public float time_to_shot;
    public float time_to_move;
    public float Max_move_distance;
    Vector3 Move_pos;
    AudioSource AS;


    void Start()
    {
        AS = GetComponent<AudioSource>();
        m = time_to_move;
        Start_pos = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        m += Time.deltaTime;
        if (t >= time_to_shot && Shot_rot != null)
        {
            StartCoroutine(Shot());
            t = 0;
          
        }
        if (m >= time_to_move)
        {
            Move_pos = Start_pos + new Vector3(Random.Range(-Max_move_distance, Max_move_distance), 0, Random.Range(-Max_move_distance, Max_move_distance));
            m = 0;
        }

        agent.destination = Move_pos;



    }

    public IEnumerator Shot()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Shot_rot != null)
            {
                Instantiate(projectile, transform.position + new Vector3(0, 1.25f,0), Shot_rot.rotation);
                AS.Play();
            }
           

            yield return new WaitForSeconds(0.1f);

        }
    
    }
}