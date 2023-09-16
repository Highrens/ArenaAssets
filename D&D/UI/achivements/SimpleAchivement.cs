using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Achivements))]
public class SimpleAchivement : MonoBehaviour
{
    Animator Anim;
    public Text AchivementText;
    public string[,] achiv;
    // Start is called before the first frame update
    void Start()
    {
        achiv = GetComponent<Achivements>().achiv;
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponentInParent<InterFace>().gameIsPaused) return;

        if (Input.GetButtonDown("Fire1") && achiv[0, 1] != "yes")
        {
            ShowAndSaveAchivement(0);
        }
        if (transform.root.GetComponentInChildren<Pickups>() && 
            transform.root.GetComponentInChildren<Pickups>().Coins >= 50 && achiv[9, 1] != "yes") {
            ShowAndSaveAchivement(9);
        }
    }
    public void ShowAndSaveAchivement(int AchivementNumber)
    {
        if (achiv[AchivementNumber, 1] != "yes")
        {
            AchivementText.text = achiv[AchivementNumber, 0];
            Anim.SetTrigger("Achivement");
            achiv[AchivementNumber, 1] = "yes";
            GetComponent<Achivements>().SaveAchivements();
            GetComponent<Achivements>().GetAchivements();
           // achiv = GetComponent<Achivements>().achiv;
        }
       
    }
}
