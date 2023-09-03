using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsIcons : MonoBehaviour
{
    public int itemsCount = 0;
    public GameObject ItemsInterface;
    public GameObject icon;
    public void AddItem(Sprite iconSprite)
    {
        var NewAchivement = Instantiate(icon, new Vector3( itemsCount * 32 + 380, 60, 0), new Quaternion(0, 0, 0, 0), ItemsInterface.transform);
        NewAchivement.GetComponentInChildren<Image>().sprite = iconSprite;
        //NewAchivement.transform.localPosition = Vector3.zero;
        itemsCount++;
    }
    public void DeleteReorganizeItemIcons(int itemToDelete)
    {
        DestroyImmediate(ItemsInterface.transform.GetChild(itemToDelete).gameObject);

        for (int i = 0; i < ItemsInterface.transform.childCount; i++)
        {
            Debug.Log(ItemsInterface.transform.GetChild(i));
            itemsCount = i + 1;
            ItemsInterface.transform.GetChild(i).position = new Vector3(i * 32 + 380, 60, 0);
        }
    }
}
