using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivements : MonoBehaviour
{
   public string[,] achiv =
    {
       {"First Shot (Unlocks: Ak)" , "no"},          //0
       {"Beat Game! (Unlock: Dash)", "no"},     //1
       {"Beat DeathCar! (Unlock: Right glock)", "no"},//2
       {"Beat Kraken! (Unlocks: AUG)", "no"},        //3     +
       {"Beat Drones! (Unlocks: Volcano)", "no"},  //4       +    
       {"You not suppose to be here! (Unlocks: AutoPistol)" , "no"},       //5
       {"Beat Jsab! (Unlocks: Hyperion)", "no"},  //6        +
       {"Brake 20 hemlets (Unlocks: Shield)", "no"},  //7
       {"Beat 10 Snipers (Unlocks: Deagle)", "no"},  //8
       {"Big Money! (Unlocks: Dimplomat)", "no"},  //9
    };
    public void Awake ()
     {
        GetAchivements();
    }
    public void SaveAchivements()
    {
        for (int i = 0; i < achiv.Length - 1; i++)
        {
            if (i % 2 != 0 && i != 0 && i != achiv.Length - 1) { }
            else
            {
                PlayerPrefs.SetString(achiv[i / 2, 0], achiv[i / 2, 1]);
             //   Debug.Log(achiv[i / 2, 0] + " " + achiv[i / 2, 1]);
                PlayerPrefs.Save();
            }
        }
        
    }   
    public void GetAchivements()
    {
        for (int i = 0; i < achiv.Length - 1; i++)
        {
            if (i % 2 != 0 && i != 0 && i != achiv.Length - 1) { }
            else
            {
                if (PlayerPrefs.HasKey(achiv[i / 2, 0])) {
                    achiv[i / 2, 1] = PlayerPrefs.GetString(achiv[i / 2, 0], achiv[i / 2, 1]);
                } else {
                    achiv[i / 2, 1] = "no";
                }
            }
          //  Debug.Log(achiv[i / 2, 0] + " " + achiv[i / 2, 1]);
        }
    }
 }