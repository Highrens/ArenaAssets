using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersAudioControl : MonoBehaviour
{
    public AudioClip step;
    public AudioSource step_Sourse;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        step_Sourse = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float curSpeedX = Input.GetAxis("Vertical");
        float curSpeedY = Input.GetAxis("Horizontal");
        if ((curSpeedX != 0 || curSpeedY != 0) && step_Sourse.isPlaying == false && characterController != null && characterController.isGrounded == true)
        {
            step_Sourse.Play();
          
        }
        else
        {
        }
    }
}
