using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject[] Target;
     AudioSource AS;
    bool t = true;
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        Anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    public void Interact_with_taget()
    {
        AS?.Play();
        ChangeState();
        for (int i = 0; i <= Target.Length - 1; i++)
        {
            if (Target[i] != null)
            {
                Target[i].GetComponentInChildren<doors>()?.ChangeState();
                if (Target[i].GetComponentInChildren<MultiLeverDoor>())
                {
                    MultiLeverDoor MLD = Target[i].GetComponentInChildren<MultiLeverDoor>();
                    if (t == true)
                    {
                        MLD.signals += 1;
                        t = !t;
                    }
                    else
                    {
                        MLD.signals -= 1;
                        
                        t = !t;
                    }
                    MLD.ChangeState();
                }
                if (Target[i].GetComponentInParent<Spawn_in_Room>()) Target[i].GetComponent<Spawn_in_Room>().signals += 1;
                if (Target[i].GetComponentInParent<Destroy_on_lever>()) Target[i].GetComponent<Destroy_on_lever>().signals += 1;
                Target[i].GetComponent<LightWay>()?.ChangeState();
                Target[i].GetComponent<Arena>()?.ArenaStart();
                if (Target[i].GetComponent<ForwardArena>())
                {
                    Target[i].GetComponent<ForwardArena>().FDArenaStart();
                    Destroy(gameObject);
                }
            }
        }
    }
    public void ChangeState()
    {
        if (!Anim) return;
        if (Anim.GetBool("Open"))
        {
            Anim.SetBool("Open", false);
        }
        else
        {
            Anim.SetBool("Open", true);
        }
    }
}