using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;


public class GunsInv : MonoBehaviour
{
    public GameObject menu;
    GunSwitch guns;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
      guns = transform.root.GetComponentInChildren<GunSwitch>();
    }

    public void Give(){
        string input = inputField.text;
        string pattern = @"^Give\s.*$"; // ���������� ���������
      
        bool isMatch = Regex.IsMatch(input, pattern);

        if (Regex.IsMatch(input, @"^Give\s.*$")) {
            Debug.Log("match!");
            for (int i = 0; i < guns.allWeapons.Length; i++)
            {
              if ("give " + guns.allWeapons[i].name.ToLower() == inputField.text.ToLower()){
                guns.currentWeapons[guns.currentWeapon] = guns.allWeapons[i];
                guns.allWeapons[i].SetActive(true);
              }
              else {
                guns.allWeapons[i].SetActive(false);
              }
              
            }
        }

        if (Regex.IsMatch(input, @"^Money (\d+)$")) {

            int number = int.Parse(input[(input.IndexOf(' ') + 1)..]);
            PlayerPrefs.SetInt("MoneyInBank", number);
        }
        if (Regex.IsMatch(input, @"^Coins (\d+)$")) {

            int number = int.Parse(input[(input.IndexOf(' ') + 1)..]);
            transform.root.GetComponentInChildren<Pickups>().Coins = number;
        }
        if (Regex.IsMatch(input, @"^Hpotion (\d+)$")) {

            int number = int.Parse(input[(input.IndexOf(' ') + 1)..]);
            transform.root.GetComponentInChildren<Pickups>().Health_Potion = number;
        }
        inputField.text = "";

    }

    private void Update() {
      if (Input.GetKeyDown(KeyCode.BackQuote)){
          menu.SetActive(!menu.activeInHierarchy);
      }
    }
}
