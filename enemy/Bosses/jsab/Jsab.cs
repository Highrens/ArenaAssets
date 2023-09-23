using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jsab : MonoBehaviour
{
    float Shot_timer = -6;

    public float Time_Until_next_shot;
    public GameObject lazer;
    public Transform Lazer_shot_spawn;
    public GameObject wave;
    public Transform wavet_spawn;
    public GameObject beamSphere;
    public GameObject lastStand;
    public GameObject SDAF;
    public GameObject jsab_render;
    Animator Anim;
    public Boss_health_bar boosHealth;
    int attack = 0;
    // Start is called before the first frame update
    void Start()
    {
        // boosHealth = GetComponent<Boss_health_bar>();
        Anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!boosHealth.Start_fight) return;
        if (boosHealth.health.Enemys_health > 500)
        {
            Anim.SetTrigger("start");
            Shot_timer += Time.deltaTime;
            if (Shot_timer >= Time_Until_next_shot)
            {
                Shot_timer = 0;
                if (attack == 0)
                {
                    attack = Random.Range(0, 3);
                    if (attack == 0) attack = 1;
                    StartCoroutine(Jump());
                }
                else if (attack == 1)
                {
                    attack = Random.Range(0, 3);
                    if (attack == 1) attack = 2;
                    StartCoroutine(Lazer_shot());
                }
                else
                {

                    attack = Random.Range(0, 3);
                    if (attack == 2) attack = 0;
                    StartCoroutine(Attack());
                }
            }
            // if (boosHealth.health.Enemys_health < boosHealth.health.Enemys_Max_health / 3)
            // {
            //     lastStand.SetActive(true);
            // }
        } else {
            lastStand.SetActive(false);
            SDAF?.SetActive(true);
        }


    }
    public IEnumerator Lazer_shot()
    {
        Anim.SetBool("scope", true);
        yield return new WaitForSeconds(0.5f);
        float j = Random.Range(-5, 5);
        for (int x = 0; x < 18; x++)
        {
            transform.Rotate(0, 20, 0);
            Anim.SetTrigger("shot");
            Instantiate(lazer, Lazer_shot_spawn.position, Lazer_shot_spawn.transform.rotation);
            yield return new WaitForSeconds(0.3f);
            Shot_timer = 0;
        }
        Anim.SetBool("scope", false);
    }
    public IEnumerator Jump()
    {
        for (int i = 0; i < 3; i++)
        {
            Shot_timer = 0;
            Anim.SetTrigger("jump");
            yield return new WaitForSeconds(0.5f);
            Instantiate(wave, wavet_spawn.position, wavet_spawn.transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }


    }
    public IEnumerator Attack()
    {
        Shot_timer = -5f;
        Anim.SetTrigger("bigAttack");
        int count = Random.Range(0, 4);
        transform.Rotate(0, 90 * count, 0);
        beamSphere.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        Instantiate(wave, wavet_spawn.position, wavet_spawn.transform.rotation);
        beamSphere.SetActive(false);
    }
}
