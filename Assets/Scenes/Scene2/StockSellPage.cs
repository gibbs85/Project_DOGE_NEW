using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.EventSystems;
using System;

public class StockSellPage : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    public string stockName;
    public int stockPrice;
    public int stockCount;
    public int stockPriceCaled;
    public int stockCountOwn;
    public string inputProcessed;

    public void init()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        this.stockName = GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getName();
        this.stockPrice = (int)(GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getPrice());
        this.stockCount = 0;
        this.stockCountOwn = GameObject.Find("Stocks").GetComponent<Stocks>().CountOwn(this.stockName);
        this.stockPriceCaled = 0;
        this.inputProcessed = "0";



        GameObject.Find("StockSellPage").transform.Find("TextStockSellPrice").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPrice.ToString("c", numberFormat);
        GameObject.Find("StockSellPage").transform.Find("TextStockSellCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCount + "주";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellOwnCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCountOwn + "주";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPriceCaled.ToString("c", numberFormat);
    }

    void OnEnable()
    {
        this.refresh();
    }

    public void refresh()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        this.stockPriceCaled = this.stockPrice * this.stockCount;
        this.stockCountOwn = GameObject.Find("Stocks").GetComponent<Stocks>().CountOwn(this.stockName);

        GameObject.Find("StockSellPage").transform.Find("TextStockSellCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCount + "주";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellOwnCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCountOwn + "주";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPriceCaled.ToString("c", numberFormat);

        //if (this.stockPriceCaled > GameObject.Find("Player").GetComponent<Player>().GetMoney())
        //{
        //    GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
        //}
        //else
        //{
        //    GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
        //}

        if (this.stockPriceCaled < 100000000) // 1억 미만
            GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
        else if (this.stockPriceCaled < 1000000000) // 10억 미만
            GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 14;
        else
            GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
    }

    public void inputHandle(string input)
    {
        if (input.Equals("99"))
        {
            if (this.inputProcessed.Equals("0"))
                return;

            if (this.inputProcessed.Length == 1)
            {
                this.inputProcessed = "0";
                this.stockCount = Int32.Parse(this.inputProcessed);
                this.refresh();
                return;
            }

            this.inputProcessed = this.inputProcessed.Substring(0, this.inputProcessed.Length - 1);
            this.stockCount = Int32.Parse(this.inputProcessed);

            this.refresh();
            return;
        }

        if (this.inputProcessed.Length > 2)
            return;


        if (this.inputProcessed.Equals("0"))
        {
            this.inputProcessed = input;
            this.stockCount = Int32.Parse(this.inputProcessed);
            this.refresh();
            return;
        }

        this.inputProcessed += input;

        this.stockCount = Int32.Parse(this.inputProcessed);
        this.refresh();
    }
    
    public void SellConfirmClicked()
    {
        if (this.stockCount > this.stockCountOwn) // 판매할 수 있는 양 부족
            return;
        if (GameObject.Find("Main").GetComponent<MainScript>().useTired(1) == false)
            return;

        GameObject.Find("Stocks").GetComponent<Stocks>().SellStock(GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock(), this.stockCount);
        Player.player.SetMoney(Player.player.GetMoney() + this.stockPriceCaled);
        this.refresh();
    }
}
