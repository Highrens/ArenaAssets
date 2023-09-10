using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCell : MonoBehaviour
{
    public int price;
    public bool randomPrice;
    public GameObject Sellitem;
    public GameObject render;
    private void Start()
    {
        if (randomPrice)
        {
            price = Random.Range(1, price);
        }


        Sellitem = GetComponentInChildren<ChooseReward>().reward;
        if (Sellitem.GetComponent<Price>())
        {
            price = Sellitem.GetComponent<Price>().price;
        }

        TextMeshPro textmeshPro = GetComponentInChildren<TextMeshPro>();
        textmeshPro.text = price.ToString();
        Sellitem.layer = 0;
    }
    public void Sold()
    {
        price = 0;
        Sellitem.layer = 7;
        render.SetActive(false);
    }
}
