using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuAchivements : MonoBehaviour
{
    public GameObject Achivement;
    public GameObject scroll;
    public List<GameObject> Achivements = new List<GameObject>();
    public bool menu_opened = false;

    public void Open()
    {
        GetComponent<Achivements>().GetAchivements();
        if (!menu_opened)
        {
            string[,] achiv = GetComponent<Achivements>().achiv;
            menu_opened = true;     
            for (int i = 0; i < achiv.Length - 1; i++)
            {
                if (i % 2 != 0 && i != 0) { }
                else
                {
                    var NewAchivement = Instantiate(Achivement, new Vector3(1120, i * 60 + 60, 0), new Quaternion(0, 0, 0, 0));
                    Achivements.Add(NewAchivement);
                    Debug.Log(achiv[i / 2, 0] + " " + achiv[i / 2, 1]);
                    if (achiv[i / 2, 1] == "no")
                    {
                        NewAchivement.GetComponentInChildren<Image>().color = new Color32(120, 120, 120, 255);
                    }
                    NewAchivement.GetComponentInChildren<TextMeshProUGUI>().text = achiv[i / 2, 0];
                    NewAchivement.transform.SetParent(scroll.transform);
                  //PlayerPrefs.SetString(achiv[i / 2, 0], achiv[i / 2, 1]);
                  //Debug.Log(achiv[i / 2, 0] + " " + achiv[i / 2, 1]);
                  //PlayerPrefs.Save();
                }
            }
        }
    }
   public void Close()
    {
        menu_opened = false;
        int g = Achivements.Count;
        for (int i = g - 1; i >= 0; i--)
        {
            Destroy(Achivements[i]);
            Achivements.RemoveAt(i);}
    }
}
