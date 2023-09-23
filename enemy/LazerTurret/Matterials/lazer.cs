using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public bool Y_shot;
    public GameObject Progectile;
    public float rotateSpeed;
    public float TimeToShot;
    public float Spread;
    public Transform ShotPoint;
    public bool shotAndRotate;
    public bool forget = true;
    bool move = true;
           bool lookatplayer = false; //Does we look at player?
           float timer; 
           Quaternion BaseRot;
           Transform Target;
           float Y_shot_vector;
    public float Shot_distance = 15f;


    // Start is called before the first frame update
    void Start()
    {
        BaseRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Y_shot == true)
        { 
            if (Target != null) Y_shot_vector = Target.transform.position.y;
        }
        else
        {
            Y_shot_vector = transform.position.y;
        }

        timer += Time.deltaTime;
        if (!shotAndRotate || move)
        {
            if (lookatplayer == true)

            {
                Quaternion rot = Quaternion.LookRotation(new Vector3(Target.transform.position.x, Y_shot_vector, Target.transform.position.z) - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotateSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, BaseRot, Time.deltaTime);
            }
        }
      

        RaycastHit hit;
        Debug.DrawRay(ShotPoint.position, transform.TransformDirection(Vector3.forward) * Shot_distance, Color.yellow);
        if (!Progectile) return;
        if (timer > TimeToShot)
        {
            move = true;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Shot_distance) && hit.transform.gameObject.layer == 8)
            {
                
               // AS.Play();
                Shot();
                timer = 0;
                move = false;
            }
        }
    }
    void Shot()
    {

        Instantiate(Progectile,
                    ShotPoint.position,
                    transform.rotation * Quaternion.Euler(new Vector3(Random.Range(-Spread, Spread), Random.Range(-Spread, Spread), 0)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Target = other.gameObject.transform;
            lookatplayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 && forget == true) lookatplayer = false;

    }
}
