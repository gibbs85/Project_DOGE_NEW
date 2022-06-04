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
    // Start is called before the first frame update
    //void Start()
    //{
    //    GameObject.Find("StockDetailTitle").transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = this.stock.getName();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
