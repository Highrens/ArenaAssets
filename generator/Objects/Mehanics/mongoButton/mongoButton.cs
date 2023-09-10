using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mongoButton : MonoBehaviour
{
    public GameObject button;
    public AudioSource AS;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        AS.Play();
        button.transform.localPosition = new Vector3(0, -0.125f, 0);
        GetComponent<Lever>().Interact_with_taget();
    }
    private void OnTriggerExit(Collider other)
    {
        AS.Play();
        button.transform.localPosition = new Vector3(0, 0, 0);
        GetComponent<Lever>().Interact_with_taget();
    }
}
