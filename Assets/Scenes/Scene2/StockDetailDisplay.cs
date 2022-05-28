using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
//using ScottPlot;

public class StockDetailDisplay : MonoBehaviour
{
    NumberFormatInfo numberFormat;
    // Start is called before the first frame update
    void Start()
    {
        this.refresh();
    }

    void refresh()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;
        double rate = GameObject.Find("Stocks").GetComponent<Stocks>().getRateDay(GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().stock, 15);

        GameObject.Find("StockDetailTitle").transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().stock.getName();
        GameObject.Find("StockDetailTitle").transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().stock.getPrice().ToString("c", numberFormat)
        +"(" + rate.ToString("F2") + "%";

        if (rate > 0)
        {
            GameObject.Find("StockDetailTitle").transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
        }
        else if (rate < 0)
        {
            GameObject.Find("StockDetailTitle").transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
        }
        else
        {
            GameObject.Find("StockDetailTitle").transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);
        }

        GameObject.Find("StockDetailDesc").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().stock.getDesc();

        //var plt = new ScottPlot.Plot(600, 400);
        //plt.AddSignal(GameObject.Find("Stocks").GetComponent<Stocks>().getRecordDay(GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().stock, 15));
        //plt.SaveFig("StockGraph");



    }
}