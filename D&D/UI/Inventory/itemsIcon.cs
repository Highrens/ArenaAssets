using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsIcon : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject curret;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Nani());
    }

    IEnumerator Nani()
    {
        for (int i = 0; i < weapons.Length - 1; i++)
        {
            string saveName = "weapon_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
            string savePath = Application.dataPath + "/icons/" + saveName;
            var curItem = Instantiate(weapons[i], transform.position, transform.rotation);
            curret = curItem;
            ScreenCapture.CaptureScreenshot(savePath);
            Debug.Log("Saved at" + savePath);
            yield return new WaitForSeconds(1f);
            Destroy(curret);

        }

    }

}
