using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

//using StockDOGE;

public class OpenStockDetail : MonoBehaviour
{
    public void seeDetail()
    {
        //string stockName = GameObject.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text;
        string stockName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;

        GameObject.Find("AppStock").transform.Find("StockDetail").gameObject.SetActive(true);
        GameObject.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().setStockName(stockName);
        GameObject.Find("ChartStock").GetComponent<ChartStock>().init();
        GameObject.Find("StockDetail").GetComponent<StockDetailDisplay>().refresh();

        GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockToggleAllOwned").gameObject.SetActive(false);

        

    }

    public void openDetailFromOwns()
    {
        //string stockName = GameObject.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text;
        string stockName = EventSystem.current.currentSelectedGameObject.transform.Find("TextStockListOwnName").GetComponentInChildren<TextMeshProUGUI>().text;

        GameObject.Find("AppStock").transform.Find("StockDetail").gameObject.SetActive(true);
        GameObject.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().setStockName(stockName);
        GameObject.Find("StockDetail").GetComponent<StockDetailDisplay>().refresh();
        GameObject.Find("ChartStock").GetComponent<ChartStock>().init();

        GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockToggleAllOwned").gameObject.SetActive(false);
    }
}
