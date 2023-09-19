using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCar : MonoBehaviour
{

    float Shot_timer;
    public float Time_Until_next_shot;
    public float Time_Until_next_shot_Rage;
    public int Chosen_attack;

    public Transform Lazer_shot_spawn;
    public Transform[] BFA_spawn;

    public GameObject Lazer_Proj;
    public GameObject LazerBeam;
    public GameObject Bomb;
    public GameObject Mine;
    public ParticleSystem BSRS;

    Enemy_Health enemy_Health;
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        enemy_Health = GetComponent<Enemy_Health>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!GetComponent<Boss_health_bar>().Start_fight) return;

        Shot_timer += Time.deltaTime;

        if (enemy_Health.Enemys_health <= enemy_Health.Enemys_Max_health / 8)
        {
            Time_Until_next_shot = Time_Until_next_shot_Rage;
        }

        if (Shot_timer >= Time_Until_next_shot)
        {
            Chosen_attack = Random.Range(1, 4);

            if (Chosen_attack == 1)
            {

                StartCoroutine(Lazer_shot());
                Shot_timer = 0;
            }
            else
            {
                if (Chosen_attack == 2)
                {
                    StartCoroutine(Bombs_from_above());
                    Shot_timer = 0;
                }
                else
                {
                    StartCoroutine(Lazer_beam());
                    Shot_timer = 0;
                }
            }
            Instantiate(Mine, Anim.transform.position, Anim.transform.rotation);
        }


    }


    public IEnumerator Lazer_shot()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Lazer_Proj, Lazer_shot_spawn.position,
                Lazer_shot_spawn.transform.rotation * Quaternion.Euler(new Vector3(0, 15f * i - 15f, 0)));
            yield return new WaitForSeconds(0.3f);
        }

    }
    public IEnumerator Bombs_from_above()
    {

        Anim.SetBool("Roof", true);
        yield return new WaitForSeconds(1);
        BSRS.Play();
        for (int i = 0; i < BFA_spawn.Length; i++)
        {
            Instantiate(Bomb, BFA_spawn[i].transform.position, transform.rotation);

        }
        yield return new WaitForSeconds(1);
        Anim.SetBool("Roof", false);
    }
    public IEnumerator Lazer_beam()
    {
        Anim.SetBool("Door", true);
        yield return new WaitForSeconds(1);
        LazerBeam.SetActive(true);
        yield return new WaitForSeconds(3);
        LazerBeam.SetActive(false);
        Anim.SetBool("Door", false);
    }
}
