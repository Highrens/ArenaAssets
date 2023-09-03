using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Moveable : MonoBehaviour
{
    AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (AS)  AS.Play();
    }
}