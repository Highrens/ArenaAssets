using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_in_Room : MonoBehaviour
{
    public GameObject[] enemys;
    GameObject player;
    public int signals;
    public int signals_to_spawn = 1;
    private void FixedUpdate()
    {
       if (signals >= signals_to_spawn)
        {
            StartCoroutine(Spawn());
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            StartCoroutine(Spawn());
            player = other.gameObject;
        }
    
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i] !=null)
            {
                if (enemys[i].GetComponentInChildren<Zombie>() != null)
                {
                    enemys[i].GetComponentInChildren<Zombie>().Target = player;
                }
              
                enemys[i].SetActive(true);
              

            }
            yield return new WaitForSeconds(0.4f);
        }
    }
}
