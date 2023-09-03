using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float maxX = 5.5f;
    public float maxY = 5.5f;
    public float CameraLookAngle;
    public float CameraLookAngleY;
    InterFace Ui;
    void Start()
    {
        Ui = GetComponentInParent<InterFace>();
    }

    void Update()
        {
        if (Ui.gameIsPaused) return;
        CameraLookAngle -= Input.GetAxis("Mouse X");
        CameraLookAngleY -= Input.GetAxis("Mouse Y");

        CameraLookAngle = Mathf.Clamp(CameraLookAngle, -maxX, maxX);
        CameraLookAngleY = Mathf.Clamp(CameraLookAngleY, -maxY, maxY);


        if (CameraLookAngle > .2f)
        {
            CameraLookAngle -= Time.deltaTime * 10;
        }
        if (CameraLookAngle < -.2f)
        {
            CameraLookAngle += Time.deltaTime * 10;
        }
        if (CameraLookAngleY > .2f)
        {
            CameraLookAngleY -= Time.deltaTime * 10;
        }
        if (CameraLookAngleY < -.2f)
        {
            CameraLookAngleY += Time.deltaTime * 10;
        }
    }
}
