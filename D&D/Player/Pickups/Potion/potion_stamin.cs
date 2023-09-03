using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potion_stamin : MonoBehaviour
{
    public Text Stamina_amount_txt;

    public float Time_toDrink; //Things to use
    public Slider Use_Slider;
    public float Use_timer;

    public Health PH;
    public Animator AC;
    Pickups Inv;

    bool Isdrinking = false;
    void Start()
    {
        Inv = GetComponentInParent<Pickups>();
        PH = GetComponentInParent<Health>();
        AC = GetComponent<Animator>();
    }
    private void Update()
    {

        // Stamina_Potion =Inv.Stamina_Potion;

        Stamina_amount_txt.text = Inv.Stamina_Potion.ToString();
        Use_Slider.value = Use_timer / Time_toDrink;
        if (Inv.Stamina_Potion == 0)
        {
            gameObject.SetActive(false);
        }


        if (Input.GetButtonDown("Fire1") && Inv.Stamina_Potion > 0 && Isdrinking == false)
        {
            AC.SetTrigger("drink");
            Use_Slider.gameObject.SetActive(true);
            Isdrinking = true;
        }
        if (Input.GetButton("Fire1") && Inv.Stamina_Potion > 0 && Isdrinking == true)
        {

            Use_timer += Time.deltaTime;

            if (Use_timer >= Time_toDrink)
            {
                PH.stamina += 50;
                if (PH.stamina > PH.stamina_max) PH.stamina = 100;
                Use_timer = 0;
                Use_Slider.gameObject.SetActive(false);
                Inv.Stamina_Potion--;
                Isdrinking = false;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Use_Slider.gameObject.SetActive(false);

            Use_timer = 0;
            if (Isdrinking == true)
            {
                AC.SetTrigger("stop");

            }
            Isdrinking = false;
        }
    }
}