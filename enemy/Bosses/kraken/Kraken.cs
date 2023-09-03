using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : MonoBehaviour
{
    public GameObject Pierce_obj;
    public GameObject Wave_obj;
    public GameObject Smash_obj;
    public Transform wave;
    public float t = 0;
    int Time_to_attack = 5;
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Boss_health_bar>().Start_fight == true) t += Time.deltaTime;

        if (t > Time_to_attack)
        {
            int r = Random.Range(0, 3);
           if (r == 0)
            {
                Smash();
            }
            else
            {
                
                if (r == 1)
                {
                    Wave();
                }
                else
                {
                    StartCoroutine(Pierce());
                }
            }        
            t = 0;
        }
        if (GetComponent<Boss_health_bar>().health.Enemys_health < GetComponent<Boss_health_bar>().health.Enemys_Max_health / 2)
        {
            Time_to_attack = 3;
        }
        if (GetComponent<Boss_health_bar>().health.Enemys_health < GetComponent<Boss_health_bar>().health.Enemys_Max_health / 4)
        {
            Time_to_attack = 1;
        }
    }

    IEnumerator Pierce()
    {
        for (int i = 0; i < 8; i++)
        {
            var wave_Ins = Instantiate(Pierce_obj, transform.position + new Vector3(Random.Range(-15,15), -1, Random.Range(-15, 15)), transform.rotation * Quaternion.Euler(0, Random.Range(0, 360), 0));
            wave_Ins.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Wave()
    {
        int p = Random.Range(0, 5);
            var wave_Ins = Instantiate(Wave_obj, wave.position , wave.rotation * Quaternion.Euler(0, 90 * p, 0), transform);
            wave_Ins.transform.parent = gameObject.transform;
    }

    void Smash()
    {
        

        var wave_Ins = Instantiate(Smash_obj, GetComponent<Boss_health_bar>().player.transform.position + Vector3.down, transform.rotation);
        wave_Ins.transform.parent = gameObject.transform;
    }
}
