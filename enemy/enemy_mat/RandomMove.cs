using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    public NavMeshAgent agent;
    Vector3 Start_pos;

    float m = 0;
    public float time_to_move;
    public float Max_move_distance;
    Vector3 Move_pos;


    void Start()
    {
        m = time_to_move;
        Start_pos = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        m += Time.deltaTime;
        if (m >= time_to_move)
        {
            Move_pos = Start_pos + new Vector3(Random.Range(-Max_move_distance, Max_move_distance), 0, Random.Range(-Max_move_distance, Max_move_distance));
            m = 0;
        }

        agent.destination = Move_pos;
    }
}