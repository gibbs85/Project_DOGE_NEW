using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.EventSystems;
using System;

public class StockBuyPage : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    public int stockPrice;
    public int stockCount;
    public int stockPriceCaled;
    public string inputProcessed;

    public void init()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        this.stockPrice = (int)(GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getPrice());
        this.stockCount = 0;
        this.stockPriceCaled = 0;
        this.inputProcessed = "0";

        GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPrice").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPrice.ToString("c", numberFormat);
        GameObject.Find("StockBuyPage").transform.Find("TextStockBuyCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCount + "��";
        GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPriceCaled").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPriceCaled.ToString("c", numberFormat);
    }

    void OnEnable()
    {
        this.refresh();
    }

    public void refresh()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        this.stockPriceCaled = this.stockPrice * this.stockCount;

        GameObject.Find("StockBuyPage").transform.Find("TextStockBuyCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCount + "��";
        GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPriceCaled").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPriceCaled.ToString("c", numberFormat);
        
        if (this.stockPriceCaled > Player.player.GetMoney())
        {
            GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPriceCaled").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
        }
        else
        {
            GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPriceCaled").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
        }

        if (this.stockPriceCaled < 100000000) // 1�� �̸�
            GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
        else if (this.stockPriceCaled < 1000000000) // 10�� �̸�
            GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 14;
        else
            GameObject.Find("StockBuyPage").transform.Find("TextStockBuyPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
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

            this.inputProcessed = this.inputProcessed.Substring(0, this.inputProcessed.Length-1);
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

    public void BuyConfirmClicked()
    {
        print("�Ƿε�: " + GameObject.Find("Player").GetComponent<Player>().GetTired());
        if (this.stockPriceCaled > Player.player.GetMoney()) // ������ �� ����
            return;

        if (GameObject.Find("Main").GetComponent<MainScript>().useTired(1) == false)
            return;
        print("�Ƿε� after if: " + GameObject.Find("Player").GetComponent<Player>().GetTired());

        GameObject.Find("Stocks").GetComponent<Stocks>().BuyStock(GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock(), this.stockCount);

        //GameObject.Find("Main").GetComponent<MainScript>().useTired(1);
        //print("�Ƿε� after use: " + GameObject.Find("Player").GetComponent<Player>().GetTired());
        Player.player.SetMoney(Player.player.GetMoney() - this.stockPriceCaled);
        this.refresh();
    }
}
