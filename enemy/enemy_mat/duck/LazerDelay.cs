using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDelay : MonoBehaviour
{
    public float delay;
    public GameObject lazer;
    void Start()
    {
        StartCoroutine(LazerStart());
    }

    public IEnumerator LazerStart()
    {
        
        yield return new WaitForSeconds(delay);
        Instantiate(lazer, transform.position, transform.rotation);
    }
}
