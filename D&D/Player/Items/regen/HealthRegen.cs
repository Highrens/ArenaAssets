using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public Sprite icon;
    Health Health;
    float t;
    void Start()
    {
        gameObject.transform.root.GetComponentInChildren<ItemsIcons>().AddItem(icon);
        Health = GetComponentInParent<Health>();
    }
    private void Update()
    {   
        if(Health.Player_health < 40)
        {
            t += Time.deltaTime;
            if (t > 2)
            {
                Health.Player_health += 1;
                t = 0;
            }
        }
        
    }
}
