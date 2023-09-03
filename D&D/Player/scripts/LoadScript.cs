using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Achivements))]

public class LoadScript : MonoBehaviour
{
    public int AchivementNumber;
    public string[,] achiv;

    void Start()
    {
        achiv = GetComponent<Achivements>().achiv;
        if (achiv[AchivementNumber, 1] != "yes")
        {
            Destroy(gameObject);
        }
    }

}
