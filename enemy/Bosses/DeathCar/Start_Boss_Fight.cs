using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Boss_Fight : MonoBehaviour
{
    public GameObject Boss;

    Quaternion startRot;
    public float angle;
    public Vector3 Rot_vector;
    float t = 0;
    int StayOrGo;
    float time_to_change;
    bool Rage = false;
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Boss == null) return;

        if (GetComponent<Boss_health_bar>().Start_fight == false) return;



        if (!Rage)
        {
            t += Time.deltaTime;
            if (t >= time_to_change)
            {
                t = 0f;
                StayOrGo = Random.Range(0, 20);
            }

            if (StayOrGo >= 5)
            {
                angle++;
                Quaternion rot_algY = Quaternion.AngleAxis(angle, Rot_vector.y * new Vector3(0, 1, 0));
                transform.rotation = startRot * rot_algY;
                time_to_change = Random.Range(2, 5);  // Случайное время до смены режима        
            }
            else
            {
                time_to_change = Random.Range(1, 3);  // Случайное время до смены режима        
            }
        }
        else
        {
            angle += 1.5f;
            Quaternion rot_algY = Quaternion.AngleAxis(angle, Rot_vector.y * new Vector3(0, 1, 0));
            transform.rotation = startRot * rot_algY;
        }

        if (GetComponent<Enemy_Health>().Enemys_health <= GetComponent<Enemy_Health>().Enemys_Max_health / 8)
        {
            Rage = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (Boss != null)
            {
                GetComponent<Boss_health_bar>().Start_fight = true;
                Destroy(GetComponent<Collider>());
            }


        }
    }
}
