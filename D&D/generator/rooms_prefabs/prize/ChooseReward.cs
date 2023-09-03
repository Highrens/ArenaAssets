using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseReward : MonoBehaviour
{
    public GameObject reward;
    // Start is called before the first frame update
    void Awake()
    {
        // ”ничтожаем заблокированное оружие
        for (int i = transform.childCount; i > 0; i--)
        {
            Transform UnclockDestroy = gameObject.transform.GetChild(i-1);
            if (UnclockDestroy.gameObject.GetComponent<Gun_container>() != null && UnclockDestroy.gameObject.GetComponent<Gun_container>().ReturnIsGunAlreadyUnlock() == false)
            {
                DestroyImmediate(UnclockDestroy.gameObject);
            }
        }
        while (transform.childCount > 1)
        {
            Transform childToDestroy = transform.GetChild(Random.Range(0, transform.childCount));
            DestroyImmediate(childToDestroy.gameObject);
        }
        reward = transform.GetChild(0).gameObject;
    }

}
