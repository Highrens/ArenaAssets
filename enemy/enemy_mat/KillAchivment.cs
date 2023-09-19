using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAchivment : MonoBehaviour
{
    public int AchivementNumber;
    public int AchivementAmount;
    int CurretProgress;
    bool taken = false;

    private void Start() {
        
        if (PlayerPrefs.HasKey("Achievement " + AchivementNumber + " Progress")) {
            CurretProgress = PlayerPrefs.GetInt("Achievement " + AchivementNumber + " Progress");
        }
        if (CurretProgress == AchivementAmount) taken = true;
    }

    public void Check(GameObject Player)
    {
        
        Debug.Log("s");
        if (taken) return;
        if (PlayerPrefs.HasKey("Achievement " + AchivementNumber + " Progress")) {
            CurretProgress = PlayerPrefs.GetInt("Achievement " + AchivementNumber + " Progress");
        }
        CurretProgress++;
        if (CurretProgress == AchivementAmount) {
            Player.GetComponentInChildren<SimpleAchivement>().ShowAndSaveAchivement(AchivementNumber);
        } else {

        }
        PlayerPrefs.SetInt("Achievement " + AchivementNumber + " Progress", CurretProgress);
    }
}
