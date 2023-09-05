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

        if (isMatch) {
            Debug.Log("match!");
            for (int i = 0; i < guns.transform.childCount; i++)
            {
              if ("give " + guns.transform.GetChild(i).name.ToLower() == inputField.text.ToLower()){
                guns.transform.GetChild(i).gameObject.SetActive(true);
              }
              else {
                guns.transform.GetChild(i).gameObject.SetActive(false);
              }
              
            }
        }
        inputField.text = "";

    }

    private void Update() {
      if (Input.GetKeyDown(KeyCode.BackQuote)){
          menu.SetActive(!menu.activeInHierarchy);
      }
    }
}
