using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWithChance : MonoBehaviour
{
    [Range(0,1)]
    public float Chance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.value > Chance) Destroy(gameObject);
    }
}
