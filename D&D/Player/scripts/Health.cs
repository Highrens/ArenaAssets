
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    //obj
    public GameObject DeadPlayer;
    public GameObject Cam;
    //Ui
    public Slider[] bars;
    public TextMeshProUGUI health_txt;
    public GameObject damageScreen;
    //Stats
    public float Player_health = 100;
    public float Health_max = 100;
    public float stamina_cost = 0.25f;
    public float stamina = 100;
    public float stamina_max = 100;
    float t = 0;
    float damageTimer = 0;
    public int armor;
    public int armor_max = 100;
    public bool isRunning;
    
    public void FixedUpdate()
    {
        bars[0].value = Player_health / Health_max;
        health_txt.text = Player_health.ToString();
        bars[1].value = stamina / 100f;
        bars[2].value = armor / 100f;

        if (stamina >= 100) { bars[1].gameObject.SetActive(false); }
        else { bars[1].gameObject.SetActive(true); }
        if (armor <= 0) { bars[2].gameObject.SetActive(false); }
        else { bars[2].gameObject.SetActive(true); }
    }

    void Update()
    {
        t += Time.deltaTime;
        damageTimer += Time.deltaTime;

        if (damageTimer > .3f)
        {
            damageScreen.SetActive(false);
            damageTimer = 0f;
        }

        if (Player_health <= 0) Death();

        if (Input.GetButton("Sprint")
        && stamina > 0
        && Input.GetAxis("Vertical") > 0
            && gameObject.GetComponent<CharacterController>() != null)
        {
            if (GetComponentInChildren<pistol_n>())
            {
                GetComponentInChildren<pistol_n>().zoom = false;
                if (!GetComponentInChildren<pistol_n>().reloading) Dash();
            }
            else
            {
                Dash();
            }
        }
        else
        {
            isRunning = false;
        }

        if (stamina < 100 && t > 3f)
        {
            stamina += 3 * Time.deltaTime;

        }
    }

    public void TakeDamage(int damage)
    {
        Player_health -= damage;
        damageScreen.SetActive(true);
    }

    void Death()
    {
        damageScreen.SetActive(false);
        Destroy(gameObject.GetComponent<SC_FPSController>());
        Destroy(gameObject.GetComponent<CharacterController>());
        Destroy(Cam);
        DeadPlayer.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Dash()
    {
        isRunning = true;
        stamina -= stamina_cost;
        t = 0;
    }
    public void AddShield(int ArmorAmount)
    {
        armor += ArmorAmount;
        if (armor > armor_max) armor_max = armor;
    }
}
