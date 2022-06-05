using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartStock : MonoBehaviour
{
    public int countRecordHour = (int)(SettingsStock.COUNT_UPDATE_PER_HOUR);

    private double[] data;
    private double[] dataToChart;


    void OnEnable()
    {
        this.getData();
        this.chartNrecords(GameObject.Find("Player").GetComponent<Player>().GetTime() - (int)SettingsStock.TIME_START_OF_DAY);
    }

    public void getData()
    {
        data = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getPriceRecord();
    }

    public void chartNrecords(int n)
    {
        if(this.data.Length < n)
        {
            //요구받은 데이터양보다 존재 데이터양이 적음
            n = this.data.Length;
        }

        int length = n;
        int writeIndex = 0;
        int readIndex = n;
        this.dataToChart = new double[n];

        while (readIndex > 0)
        {
            this.dataToChart[writeIndex] = this.data[^readIndex];
            writeIndex++;
            readIndex--;
        }
    }
}
