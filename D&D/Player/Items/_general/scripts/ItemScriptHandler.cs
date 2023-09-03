using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScriptHandler : MonoBehaviour
{
    public string itemName = "Missing";
    public string Discription = "Missing";
    public GameObject item;
    // Start is called before the first frame update
    public void ItemUse(Transform parent)
    {
        var createdItem = Instantiate(item);
        createdItem.transform.SetParent(parent);
        createdItem.transform.localPosition = Vector3.zero;
        createdItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
