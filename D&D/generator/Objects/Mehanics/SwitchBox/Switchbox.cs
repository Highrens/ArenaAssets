using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchbox : MonoBehaviour
{

    public bool isDark = false;
    public Animator anim;

    public List<GameObject> filtredObj = new List<GameObject>();
    public List<GameObject> filtredLightObj = new List<GameObject>();
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        // Находим все объекты с заданным параметром
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<Light>() && !GetComponentInParent<LightWay>() && obj.name != "Toxin Light")
            {
                filtredLightObj.Add(obj);
            }
            if (obj.GetComponent<LightWay>())
            {
                filtredObj.Add(obj);
            }
        }
    }

    // Update is called once per frame
    public void ChangeLight()
    {
        anim.SetTrigger("change");
        if (isDark)
        {
            RenderSettings.ambientLight = new Color(0.023f, 0.0039f, 0);
            foreach (GameObject ObjLight in filtredObj)
            {
                if (!ObjLight) return;
                ObjLight.GetComponent<LightWay>().state = false;

            }
            foreach (GameObject ObjLight in filtredLightObj)
            {
                if (!ObjLight) return;
                ObjLight.SetActive(false);
            }
        }
        else
        {

            RenderSettings.ambientLight = new Color(0.3f, 0.3f, 0.3f);
            foreach (GameObject ObjLight in filtredObj)
            {
                if (!ObjLight) return;
                ObjLight.GetComponent<LightWay>().state = true;

            }
            foreach (GameObject ObjLight in filtredLightObj)
            {
                if (!ObjLight) return;
                ObjLight.SetActive(true);
            }
        }
    }
}

        // foreach (GameObject obj in objects)
        // {
        //     if (obj.name == targetName)
        //     {
        //         // Найден объект с именем "ИмяОбъекта"
        //         Debug.Log("Найден объект с именем " + targetName + ": " + obj.name);
        //         // Добавьте здесь свой код для обработки найденного объекта
        //     }
        // }
