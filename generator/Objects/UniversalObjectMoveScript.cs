using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalObjectMoveScript : MonoBehaviour
{

    Quaternion startRot;
    float angle;
    public Vector3 Rot_vector;
    public float speed_rotate = 1;

    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle++;

        Quaternion rot_algX = Quaternion.AngleAxis(angle * speed_rotate, Rot_vector.x * new Vector3(1,0,0));
        Quaternion rot_algY = Quaternion.AngleAxis(angle * speed_rotate, Rot_vector.y * new Vector3(0, 1, 0));
        Quaternion rot_algZ = Quaternion.AngleAxis(angle * speed_rotate, Rot_vector.z * new Vector3(0, 0, 1));

        transform.rotation = startRot * rot_algY * rot_algZ * rot_algX ;


    }
}
