using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockToggleChart : MonoBehaviour
{

    public void clickedDay(bool isOn)
    {
        GameObject.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().setDays(1);
        GameObject.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().refresh();
    }
    public void clickedWeek(bool isOn)
    {
        GameObject.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().setDays(7);
        GameObject.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().refresh();
    }
    public void clickedMonth(bool isOn)
    {
        GameObject.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().setDays(30);
        GameObject.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().refresh();
    }
}
