using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAppAndScript : MonoBehaviour
{
    public void initBuyPage()
    {
        GameObject.Find("AppStock").transform.Find("StockBuyPage").GetComponent<StockBuyPage>().init();
    }

    public void initSellPage()
    {
        GameObject.Find("AppStock").transform.Find("StockSellPage").GetComponent<StockSellPage>().init();
    }
}
