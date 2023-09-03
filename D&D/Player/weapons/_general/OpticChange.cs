using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpticChange : MonoBehaviour
{
    Camera cam;
    public int firstZoom;
    public int secondZoom;
    bool IsSecondZoomNow;
    // Start is called before the first frame update
    void Start()
    {
     cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if  (IsSecondZoomNow)
            {
                cam.fieldOfView = firstZoom;
            } else {
                cam.fieldOfView = secondZoom;
            }
           
            IsSecondZoomNow = !IsSecondZoomNow;
        }
    }
}
