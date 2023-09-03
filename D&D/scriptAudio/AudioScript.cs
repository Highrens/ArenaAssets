using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class AudioScript : MonoBehaviour
{
    public AudioClip clip;
    AudioSource AS;
    bool played = false;

    public float Time;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 && played == false)
        {
            played = true;
            StartCoroutine(PlayAudioSource());
        }
    }
    public IEnumerator PlayAudioSource()
    {

        AS.clip = clip;
        AS.Play();
        yield return new WaitForSeconds(Time);
        if (GetComponent<Lever>()) GetComponent<Lever>().Interact_with_taget();
    }
}
