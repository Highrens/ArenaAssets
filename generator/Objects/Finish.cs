using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Win;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 8)
        {
            GetComponent<SavePrefs>().LoadGame();
            Win.SetActive(true);
            other.GetComponentInChildren<SimpleAchivement>().ShowAndSaveAchivement(1);
            GetComponent<SavePrefs>().GameComplite++;
            GetComponent<SavePrefs>().SaveGame();
        }
       
    }
}
