using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    public int keys;
    public int Health_Potion;
    public int Stamina_Potion;
    public int Coins;

    public Text Keys_txt;
    public Text Health_Potion_txt;
    public Text Stamina_Potion_txt;
    public Text Coins_text;

    private void Update()
    {
        if (Keys_txt != null)
        {
            Keys_txt.text = keys.ToString();
        }
        if (Health_Potion_txt != null)
        {
            Health_Potion_txt.text = Health_Potion.ToString();
        }
        if (Stamina_Potion_txt != null)
        {
            Stamina_Potion_txt.text = Stamina_Potion.ToString();
        }
        if (Coins_text != null)
        {
            Coins_text.text = Coins.ToString();
        }
    }
}