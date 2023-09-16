using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_health_bar : MonoBehaviour
{
    public bool Start_fight = false;
    public Slider BossHealth_slider;
    public Enemy_Health health;
    public GameObject health_obj;
    bool maximize_health = true;
    public GameObject player;
    public int NumberAchivement;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (!health) return;
        if (maximize_health == true)
        {
            health.Enemys_health = health.Enemys_Max_health;

        }

        if (Start_fight == true)
        {
            maximize_health = false;
            health_obj.SetActive(true);
            BossHealth_slider.value = health.Enemys_health / health.Enemys_Max_health;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            player = other.gameObject;
            Start_fight = true;
        }
    }
    public void TakeAchivement()
    {
        player.GetComponentInChildren<SimpleAchivement>().ShowAndSaveAchivement(NumberAchivement);
    }
}

