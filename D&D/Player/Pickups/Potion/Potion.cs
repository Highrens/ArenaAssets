using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public string potionToUseType;
    public string potionType;
    public string potionTypeMax;
    public float potionEffect;
    public Text Potion_amount_txt;

    public float Time_toDrink; //Things to use
    public Slider Use_Slider;
    public float Use_timer;

    Health PH;
    Animator AC;
    Pickups Inv;
    AudioSource AS;

    bool Isdrinking = false;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        Inv = GetComponentInParent<Pickups>();
        PH = GetComponentInParent<Health>();
        AC = GetComponent<Animator>();
    }
    private void Update()
    {
        int potionCount = (int)(typeof(Pickups).GetField(potionToUseType)).GetValue(Inv);

        Potion_amount_txt.text = potionCount.ToString();

        Use_Slider.value = Use_timer / Time_toDrink;
        if (potionCount == 0)
        {
            gameObject.SetActive(false);
        }


        if (Input.GetButtonDown("Fire1") && potionCount > 0 && Isdrinking == false)
        {
            AS.Play();
            AC.SetTrigger("drink");
            Use_Slider.gameObject.SetActive(true);
            Isdrinking = true;
        }
        if (Input.GetButton("Fire1") && potionCount > 0 && Isdrinking == true)
        {
                Use_timer += Time.deltaTime;

                if (Use_timer >= Time_toDrink)
                    {
                        //Забираем одно зелье 
                    var potionToUseCount = typeof(Pickups).GetField(potionToUseType);  
                    if (potionToUseCount != null)
                        {
                            int curretPotion = (int)potionToUseCount.GetValue(Inv);
                            potionToUseCount.SetValue(Inv, curretPotion - 1);
                        }

                    var potionStat = typeof(Health).GetField(potionType);  
                    if (potionStat != null)
                        {
                            float curretStat = (float)potionStat.GetValue(PH);
                            potionStat.SetValue(PH, curretStat + potionEffect);
                            if ((float)potionStat.GetValue(PH) > (float)typeof(Health).GetField(potionTypeMax).GetValue(PH)){
                                potionStat.SetValue(PH, (float)typeof(Health).GetField(potionTypeMax).GetValue(PH));
                            }
                        }

                    //PH.Player_health += 50;
                    //if (PH.Player_health > PH.Health_max) PH.Player_health = PH.Health_max;
                    Use_timer = 0;
                    Use_Slider.gameObject.SetActive(false);
                    Isdrinking = false;
                   }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Use_Slider.gameObject.SetActive(false);
            AS.Stop();
            Use_timer = 0;
            if (Isdrinking == true)
            {
                AC.SetTrigger("stop");
                
            }
            Isdrinking = false;
        }
    }
}
