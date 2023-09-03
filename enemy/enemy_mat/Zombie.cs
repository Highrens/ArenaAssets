using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject Target;
    public NavMeshAgent agent;
    public bool forget = true;
    Vector3 Start_pos;


    void Start()
    {
        Start_pos = transform.position;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Target != null)
        {
                agent.destination = Target.transform.position;
        }



    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Target = other.gameObject;
        }
       
    }

    void OnTriggerExit(Collider other)
    {
        if (forget == true)
        {
            if (other.gameObject.layer == 8)
            {
                agent.destination = Start_pos;
                Target = null;
            }
        }
    }
}
