using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SavePrefs))]
public class LoadNextLevel : MonoBehaviour
{
    public int SceneToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 8)
        {
            GetComponent<SavePrefs>().SaveGame(other.gameObject);
            SceneManager.LoadSceneAsync(SceneToLoad);
        }

    }
}
