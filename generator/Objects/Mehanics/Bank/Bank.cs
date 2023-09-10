using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    public int MoneyInBank;
    public TextMeshPro MoneyInBank_text;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MoneyInBank"))
        {
            MoneyInBank = PlayerPrefs.GetInt("MoneyInBank");
            MoneyInBank_text.text = MoneyInBank.ToString();
        }
    }
    // Update is called once per frame
    public void AddMoneyInBank()
    {
        MoneyInBank++;
        MoneyInBank_text.text = MoneyInBank.ToString();
        PlayerPrefs.SetInt("MoneyInBank", MoneyInBank);
    }

    public bool TakeMoneyFromBank()
    {
        if (MoneyInBank > 0)
        {
            MoneyInBank--;
            MoneyInBank_text.text = MoneyInBank.ToString();
            PlayerPrefs.SetInt("MoneyInBank", MoneyInBank);
            return true;
        }   else {
            return false;
        }
    }

}
