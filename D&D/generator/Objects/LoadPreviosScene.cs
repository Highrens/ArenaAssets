using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SavePrefs))]
public class LoadPreviosScene : MonoBehaviour
{
    public GameObject player;
    public void Start()
    {
            GetComponent<SavePrefs>().LoadGame(player);
    }
}
