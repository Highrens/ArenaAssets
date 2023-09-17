using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        pistol_n RandomAK = GetComponent<pistol_n>();
        Recoil RandomAK_recoil = GetComponent<Recoil>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponentInChildren<ChooseReward>() != null)
            {
                RandomAKstat Obj = transform.GetChild(i).GetComponentInChildren<ChooseReward>().reward.GetComponent<RandomAKstat>();
                if(Obj != null)
                {
                    RandomAK.damage += Obj.damage;
                    RandomAK.accuracy += Obj.spread;
                    RandomAK_recoil.rotationX += Obj.recoilX;
                    RandomAK_recoil.rotationY += Obj.recoilY;
                    RandomAK.mobility += Obj.mobility;
                    if (Obj.shotPoint != null)
                    {
                        RandomAK.shot_dot = Obj.shotPoint;
                    }
                    if (Obj.ShotPs != null)
                    {
                        RandomAK.PS_obj = Obj.ShotPs;
                    }
                }

            }       
        }
    }

}
