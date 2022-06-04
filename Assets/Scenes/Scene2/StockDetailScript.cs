using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using StockDOGE;

public class StockDetailScript : MonoBehaviour
{
    

    public string stockName;

    public void setStockName(string stockName)
    {
        this.stockName = stockName;
    }
    public Stock getStock()
    {
        return GameObject.Find("Stocks").GetComponent<Stocks>().getStockByName(this.stockName);
    }
}
