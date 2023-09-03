using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_until : MonoBehaviour
{
    public bool IsRandom;
    public int count_to_leave = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (IsRandom == true)
        {
            count_to_leave = Random.Range(0, count_to_leave);
        }
        while (transform.childCount > count_to_leave)
        {
            Transform childToDestroy = transform.GetChild(Random.Range(0, transform.childCount));
            DestroyImmediate(childToDestroy.gameObject);
        }
    }
}
