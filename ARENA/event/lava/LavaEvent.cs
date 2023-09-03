using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEvent : MonoBehaviour
{
    Arena arena;
    float t = 0;
    public int wave;
    void Start()
    {
        arena = GetComponentInParent<Arena>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arena.waveNumber > wave)
        {
            GetComponent<Animator>().SetTrigger("down");
            t += Time.deltaTime;
            if (t > 5) Destroy(gameObject);
        }
    }
}
