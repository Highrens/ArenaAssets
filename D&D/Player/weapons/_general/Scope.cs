using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public int scopeSpeed;
    public GameObject sight;
    public bool zoom;
    public Vector3 zoom_vector;
    float t = 0;
    float z = 0;
    InterFace Ui;
    public GameObject cross;
    private void Start()
    {

        Ui = GetComponentInParent<InterFace>();
    }
    void Update()
    {
        if (!Ui.gameIsPaused)
        {
            t = Mathf.Clamp(t, 0, 1);
            zoom = GetComponent<pistol_n>().zoom;
            if (zoom == true)
            {
                cross.SetActive(false);
                z = 0;
                t += Time.deltaTime * scopeSpeed;

                if (t > 1)
                {
                    t = 1;
                }

                if (transform.localPosition.x > zoom_vector.x)
                {
                    transform.localPosition = zoom_vector * t;
                }
                if (sight != null)
                {
                    sight.SetActive(true);
                }

            }
            else
            {
                cross.SetActive(true);
                z += Time.deltaTime * scopeSpeed;
                t = 0;
                if (transform.localPosition.x < 0)
                {
                    transform.localPosition = zoom_vector * (1 - z);
                }
                if (sight != null)
                {
                    sight.SetActive(false);
                }
            }
        }
            
    }
}
