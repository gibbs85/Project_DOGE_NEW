using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//using StockDOGE;

public class OpenStockDetail : MonoBehaviour
{
    public void seeDetail()
    {
        string stockName = GameObject.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text;

        GameObject.Find("AppStock").transform.Find("StockDetail").gameObject.SetActive(true);
        GameObject.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().setStock(stockName);

        GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockToggleAllOwned").gameObject.SetActive(false);

        

    }
}
