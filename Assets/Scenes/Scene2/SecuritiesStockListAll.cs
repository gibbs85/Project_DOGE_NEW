using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

using StockDOGE;

public class SecuritiesStockListAll : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    // Start is called before the first frame update
    void Start()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        //GameObject btntemp = Resources.Load<GameObject>("Prefabs/ButtonContentForList");
        //GameObject Instancetemp = (GameObject)Instantiate(btntemp, GameObject.Find("Viewport").transform.Find("Content"));
        //Instancetemp.GetComponentInChildren<Text>().text = "NO ROOP BTN";


        for (int i = 0; i < GameObject.Find("Stocks").GetComponent<Stocks>().getStocksCount(); i++)
        {
            //print(i);
            //print(GameObject.Find("Stocks").GetComponent<Stocks>().getPriceByName("�缺����"));


            //print(GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getName());

            //GameObject btn = Resources.Load<GameObject>("Prefabs/ButtonContentForList");
            //GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("Viewport").transform.Find("Content"));
            //Instance.GetComponentInChildren<Text>().text = GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getName()
            //    + "    "
            //    + (int)(GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getPrice())
            //    + "�� ";


            GameObject btn = Resources.Load<GameObject>("Prefabs/StockButtonContentListAll");
            GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("Viewport").transform.Find("Content"));
            Instance.transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getName();
            Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().text = ((int)GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getPrice()).ToString("c", numberFormat);

            //Instance.transform.Find("TextName").GetComponentInChildren<Text>().text = GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getName();
            //Instance.transform.Find("TextPrice").GetComponentInChildren<Text>().text = (int)GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getPrice()
            //    + "\\";

            //Instance.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("inAppContent");


        }


    }

    

}