using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drones_boss : MonoBehaviour
{

    public GameObject[] lazers;
    Animator Anim;
    public float t;
    public float time_to_attack = 5f;
    public bool IsAttacking = false;
    public GameObject head_real;
    public GameObject head_render;



    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Boss_health_bar>().Start_fight) 
        {
            head_render.SetActive(false);
            head_real.SetActive(true);
            Anim.speed = 1;
            t += Time.deltaTime;
        }

        if (t >= time_to_attack && !IsAttacking)
        {
            int r = Random.Range(0, 3);
            if (r == 0)
            {
                IsAttacking = true;
                Anim.SetTrigger("horiz");
                StartCoroutine(Horizon());
            }
            else
            {
                Anim.SetTrigger("drones_down");
                if (r == 1)
                {
                    IsAttacking = true;
                    StartCoroutine(Drones_down_attack());
                }
                else
                {
                    IsAttacking = true;
                    StartCoroutine(Drones_down_cage());
                }
            }
        }
    }


    IEnumerator Horizon()
    {


        yield return new WaitForSeconds(2);
        for (int i = 0; i < lazers.Length; i++)
        {
            lazers[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.25f);
        Anim.SetTrigger("horiz_attack");

        yield return new WaitForSeconds(2);

        if (Random.Range(0, 2) == 0)
        {
            for (int i = 0; i < lazers.Length; i++)
            {
                lazers[i].SetActive(false);
            }
            Anim.SetTrigger("horiz");
            t = 0;
            IsAttacking = false;
        }
        else
        {
            Debug.Log("once more");
            StartCoroutine(Horizon());
        }
    }

    IEnumerator Drones_down_attack()
    {
        yield return new WaitForSeconds(2.25f);
        for (int i = 0; i < lazers.Length; i++)
        {
            lazers[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.25f);
        Anim.SetTrigger("down_attack");

        yield return new WaitForSeconds(2.25f);

        if (Random.Range(0, 2) == 0)
        {
            for (int i = 0; i < lazers.Length; i++)
            {
                lazers[i].SetActive(false);
            }
            Anim.SetTrigger("drones_down");
            t = 0;
            IsAttacking = false;
        }
        else
        {
            Debug.Log("once more");
            StartCoroutine(Drones_down_attack());
        }
    }

    IEnumerator Drones_down_cage()
    {
        yield return new WaitForSeconds(2.25f);
        for (int i = 0; i < lazers.Length; i++)
        {
            lazers[i].SetActive(true);

        }
        yield return new WaitForSeconds(3);
        for (int i = 0; i < lazers.Length; i++)
        {
            lazers[i].SetActive(false);
        }
        Anim.SetTrigger("drones_down");
        t = 0;
        IsAttacking = false;
    }

}