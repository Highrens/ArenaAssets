using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeBomb : MonoBehaviour
{
    public int code;
    public int curretCombination = 1000;
    public TextMeshPro board;
    public float countdown;
    public GameObject explode;
    public GameObject CodePaper;
    public AudioClip button;
    public AudioClip error;
    AudioSource AS;

    bool neutralized = false;
    bool first = false;
    bool second = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        AS = GetComponent<AudioSource>();
        code = UnityEngine.Random.Range(100, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (!neutralized) {
            countdown -= Time.deltaTime;
            if (countdown <= 0) explode.SetActive(true);
        } else
        {
            gameObject.AddComponent(typeof(DestroyInTime));
        }
        board.text = Math.Round(countdown, 2).ToString() + "\n" + curretCombination;
    }

    public void InsertNumber(int number)
    {
        AS.clip = button;
        if (first == false)
        {
            AS.Play();
            first = true;
            curretCombination += (number * 100);
            
            return;
        }
        if (second == false)
        {
            AS.Play();
            second = true;
            curretCombination += (number * 10);
            return;
        }

        AS.Play();
        curretCombination += number;

        if (code == curretCombination)
        {
            neutralized = true;
            Debug.Log("Good Job!");
        } else
        {
            AS.clip = error;
            AS.Play();
            curretCombination = 000;
            first = false;
            second = false;
        }
    }
}
