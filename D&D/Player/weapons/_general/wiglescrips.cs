using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiglescrips : MonoBehaviour
{
    float t = 0;
    public float smoothing = 1;
    public float AmpX = 0.25f;
    public float AmpY = 0.25f;
    public float AmpZ = 0.25f;
    public float Freq = 2;
    float OffsetX = 0;
    float OffsetY = 0;
    float OffsetZ = 0;
    public Vector3 StartPos;

    bool zoom = false;
    float move;

    public Vector3 vectorX;
    public float runTimer = 0;
    public float s;
    float RunFreq;
    float RunAmpY;
    CameraMovement camMove;
    InterFace Ui;

    public Camera playerCamera;

    void Start()
    { 
        StartPos = transform.position;
        RunFreq = Freq * 1;
        RunAmpY = AmpY * 4;
        camMove = GetComponent<CameraMovement>();
        Ui = GetComponentInParent<InterFace>();
    }

    void Update()
    {
        if (Ui.gameIsPaused) return;
        float curSpeedX = Input.GetAxis("Vertical");
        float curSpeedY = Input.GetAxis("Horizontal");
   
        t += Time.deltaTime;


        if (GetComponentInParent<Health>().isRunning)
        {
            runTimer += Time.deltaTime * 2;
            runTimer = Mathf.Clamp(runTimer, 0, 1);
            OffsetX = AmpX * Mathf.Sin(t * (Freq / 2) * move);
            OffsetY = zoom ? (0) : (RunAmpY * Mathf.Sin(t * RunFreq * move) + (-0.5f * runTimer));
        } else
        {
            runTimer -= Time.deltaTime * 2;
            runTimer = Mathf.Clamp(runTimer, 0, 1);
            OffsetX = AmpX * curSpeedY * (zoom ? 0.1f : 1f);
            OffsetY = zoom ? (0) : (AmpY * Mathf.Sin(t * Freq * move) + (-0.5f * runTimer));
        }

        playerCamera.fieldOfView = 60 + 10 * runTimer;

        transform.localRotation = Quaternion.Euler(-35f * runTimer - camMove.CameraLookAngleY * (zoom ? 0.3f : 1),
                                                    camMove.CameraLookAngle * (zoom ? 0.3f : 1), 0);

        if (GetComponentInChildren<Scope>())
        {
            zoom = GetComponentInChildren<Scope>().zoom;
        }
      
        if (curSpeedX == 0 && curSpeedY == 0) //&& zoom == false)
        {
            move = 0.5f;
        }
        else
        { 
            move = 2;
        }
        
        OffsetZ = AmpZ * curSpeedX + (0.3f * runTimer);
        vectorX = new Vector3(-OffsetX, OffsetY, -OffsetZ);

        transform.localPosition = Vector3.Lerp(transform.localPosition, vectorX, smoothing * Time.deltaTime);

        //transform.localPosition = new Vector3(-OffsetX, OffsetY, -OffsetZ);
       
    }
}
