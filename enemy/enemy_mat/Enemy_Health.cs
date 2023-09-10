using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public float Enemys_health = 100;
    public GameObject[] controlled_Door;
    public float Enemys_Max_health;
    public GameObject Explode;

    public GameObject Loot;
    [Range(0, 1)]
    public float Chance_no_drop = 0.5f;
    public GameObject arena;
    public int arena_number;
    // public Slider health_sl;
    private void Start()
    {
        Enemys_Max_health = Enemys_health;
    }
    void FixedUpdate()
    {

       // health_sl.value = Enemys_health / 100f;
        if (Enemys_health <= 0)
        {
            for (int i = 0; i < controlled_Door.Length; i++)
                {
                    if (controlled_Door[i] != null)
                    {
                        
                        MultiLeverDoor MLD  = controlled_Door[i].GetComponent<MultiLeverDoor>();
                        MLD.GetComponent<MultiLeverDoor>().signals += 1;
                        MLD.ChangeState();
                    }                
                }
            if (Loot != null && Random.value > Chance_no_drop) Instantiate(Loot, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
            if (arena)
            {
               // Debug.Log("I was arena-enemy");
                arena.GetComponent<Arena>().spawnedEnemys[arena_number] = null;
                arena.GetComponent<Arena>().IsAllEnemyDeadCheck();
            }
            if (Explode != null)
            {
                Instantiate(Explode, transform.position, transform.rotation);
            }
            GetComponentInParent<Boss_health_bar>()?.TakeAchivement();
            Destroy(gameObject);
        }
    }
    
}
