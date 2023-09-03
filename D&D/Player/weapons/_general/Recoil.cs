using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public float rotationX;
    public float rotationY;
    public float angleRecoil;
    public GameObject player;

    public  void MakeRecoil()
    {
        GetComponentInParent<SC_FPSController>().rotationX += rotationX;
        player.transform.localRotation *= Quaternion.Euler(0, Random.Range(-rotationY, rotationY) + angleRecoil, 0); 
    }
    public IEnumerator Make_Recoil()
    {
        for (int i = 0; i < 5; i++)
        {
            player.transform.localRotation *= Quaternion.Euler(0, Random.Range(-rotationY, rotationY) + angleRecoil, 0);
            GetComponentInParent<SC_FPSController>().rotationX += rotationX;
            yield return new WaitForSeconds(.01f);
        }
    }
}
