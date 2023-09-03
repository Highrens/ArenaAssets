using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeReload : MonoBehaviour
{
    pistol_n pistol_N;
    float timer;
    public float periond;

    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        pistol_N = GetComponent<pistol_n>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= periond)
        {
            pistol_N.ammo += amount;
            timer = 0;
        }
    }
}
