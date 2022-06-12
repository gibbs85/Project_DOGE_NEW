using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;

public class StockListOwned : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    private int moneySpentAll;
    private int moneySellAll;
    private int moneyProfit;
    private double profitRate;

    public void init()
    {
        this.refresh();
    }

    void OnEnable()
    {
        this.refresh();
    }

    public int GetMoneySellAll()
    {
        return moneySpentAll;
    }

    public void refresh()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        this.moneySpentAll = GameObject.Find("Stocks").GetComponent<Stocks>().MoneyBought();
        this.moneySellAll = GameObject.Find("Stocks").GetComponent<Stocks>().MoneySellAll();
        this.moneyProfit = this.moneySellAll - this.moneySpentAll;
        this.profitRate = ((double)this.moneyProfit / (double)this.moneySpentAll) * 100;

        GameObject.Find("StockListOwnMoneySpentAll").GetComponentInChildren<TextMeshProUGUI>().text = this.moneySpentAll.ToString("c", numberFormat);
        GameObject.Find("StockListOwnMoneySellAll").GetComponentInChildren<TextMeshProUGUI>().text = this.moneySellAll.ToString("c", numberFormat); ;
        GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().text =
            this.moneyProfit.ToString("c", numberFormat) + "(" + this.profitRate.ToString("F2") + "%)";

        if (this.profitRate > 0)
        {
            GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
        }
        else if (profitRate < 0)
        {
            GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
        }
        else
        {
            GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);
        }


        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(i).gameObject);
        }

        for (int i = 0; i < GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn.Length; i++)
        {
            if(GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].count > 0)
            {
                string name = GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].stock.getName();
                int price = (int)(GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].stock.getPrice());
                int avg = GameObject.Find("Stocks").GetComponent<Stocks>().MoneyAvg(GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].stock.getName());
                int bought = GameObject.Find("Stocks").GetComponent<Stocks>().MoneyBought(GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].stock.getName());
                int sell = (int)(GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].stock.getPrice() * GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].count);
                int count = GameObject.Find("Stocks").GetComponent<Stocks>().stocksOwn[i].count;
                int profit = sell - bought;
                double profitRate = (double)profit / (double)bought * 100;
                double rateDay = GameObject.Find("Stocks").GetComponent<Stocks>().getRateDay(GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i), GameObject.Find("Main").GetComponent<MainScript>().GetTime());

                GameObject btn = Resources.Load<GameObject>("Prefabs/BtnContentStockListOwn");
                GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("Viewport").transform.Find("Content"));
                Instance.transform.Find("TextStockListOwnName").GetComponentInChildren<TextMeshProUGUI>().text = name;
                Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().text = price.ToString("c", numberFormat) + "(" + rateDay.ToString("F2") + "%)";
                Instance.transform.Find("TextStockListOwnAvg").GetComponentInChildren<TextMeshProUGUI>().text = "내 평단가: " + avg.ToString("c", numberFormat);
                Instance.transform.Find("TextStockListOwnMoneyBought").GetComponentInChildren<TextMeshProUGUI>().text = "매입금액: " + bought.ToString("c", numberFormat);
                Instance.transform.Find("TextStockListOwnMoneySell").GetComponentInChildren<TextMeshProUGUI>().text = "평가금액: " + sell.ToString("c", numberFormat);
                Instance.transform.Find("TextStockListOwnCount").GetComponentInChildren<TextMeshProUGUI>().text = "보유수량: " + count.ToString() + "주";
                Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().text = "수익률: " + profit.ToString() + "(" + profitRate.ToString("F2") + "%)";

                if(rateDay > 0)
                    Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
                else if (rateDay < 0)
                    Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
                else
                    Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);

                if (profit > 0)
                    Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
                else if(profit < 0)
                    Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
                else
                    Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);
            }
        }
    }
}
