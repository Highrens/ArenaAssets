using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;

    public bool followPlayer;
    public GameObject Target;
    public float rotateSpeed;
    public float walkSpeed;
    float t = 0;
   // public Transform RayPoint;
   // public float SizeOfRay;
   // RaycastHit Hit;
   public  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     //   anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target && followPlayer)
        {
            //Quaternion rot = Quaternion.LookRotation(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z) - transform.position);
            //transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotateSpeed * Time.deltaTime);
            agent.destination = Target.transform.position;
            t += Time.deltaTime;
        }
       // Physics.Raycast(RayPoint.position, RayPoint.forward, out Hit, SizeOfRay);
        /*if (Hit.transform != null && Hit.transform.gameObject.layer == 8)
        {
            anim.SetTrigger("attack");
        }
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Boxing")
        {
            agent.speed = 0;
        } else {
            agent.speed = walkSpeed;
        }*/

        if (agent.velocity.magnitude > 0)
        {
            anim.SetBool("walk", true);
        } else
        {
            anim.SetBool("walk", false);
        }
        
}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Target = other.gameObject;
        }
    }
}
