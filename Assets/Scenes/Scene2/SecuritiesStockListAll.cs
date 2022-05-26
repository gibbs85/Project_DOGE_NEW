using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using StockDOGE;

public class SecuritiesStockListAll : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //GameObject btntemp = Resources.Load<GameObject>("Prefabs/ButtonContentForList");
        //GameObject Instancetemp = (GameObject)Instantiate(btntemp, GameObject.Find("Viewport").transform.Find("Content"));
        //Instancetemp.GetComponentInChildren<Text>().text = "NO ROOP BTN";

        for (int i = 0; i < GameObject.Find("Stocks").GetComponent<Stocks>().getStocksCount(); i++)
        {
            //print(i);
            //print(GameObject.Find("Stocks").GetComponent<Stocks>().getPriceByName("사성전자"));


            //print(GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getName());

            GameObject btn = Resources.Load<GameObject>("Prefabs/ButtonContentForList");
            GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("Viewport").transform.Find("Content"));
            Instance.GetComponentInChildren<Text>().text = GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getName()
                + "    "
                + (int)(GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getPrice())
                + "원 ";


        }


    }

    

}
