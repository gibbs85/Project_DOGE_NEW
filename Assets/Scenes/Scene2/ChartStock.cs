using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartStock : MonoBehaviour
{
    public int countRecordHour = (int)(SettingsStock.COUNT_UPDATE_PER_HOUR);

    private double[] data;
    private double[] dataToChart;
    private int[] dataXtoChart;

    public Color Colorhigh;
    public Color Colorlow;
    public Color Colormid;

    //public RectTransform GraphArea;

    private float graph_Width;
    private float graph_Height;


    void OnEnable()
    {
        this.refresh();
    }

    public void refresh()
    {
        int countchild = GameObject.Find("ChartStock").transform.Find("DotGroup").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("ChartStock").transform.Find("DotGroup").GetChild(i).gameObject);
        }

        this.graph_Width = 180.0f;
        this.graph_Height = 120.0f;

        this.getData();
        this.chartNrecords((GameObject.Find("Player").GetComponent<Player>().GetTime() - (int)SettingsStock.TIME_START_OF_DAY) * (int)SettingsStock.COUNT_UPDATE_PER_HOUR);
    }

    public void getData()
    {
        string stockName = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().getStockName();
        this.data = GameObject.Find("Stocks").GetComponent<Stocks>().getStockByName(stockName).getPriceRecord();
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
        double maxData = this.data[^readIndex];
        double minData = this.data[^readIndex];

        while (readIndex > 0)
        {
            this.dataToChart[writeIndex] = this.data[^readIndex];
            //print("DataToChart[" + writeIndex + "] = " + this.dataToChart[writeIndex]);
            //print("data[" + readIndex + "] = " + this.data[^readIndex]);

            if (maxData < this.data[^readIndex])
                maxData = this.data[^readIndex];
            if (minData > this.data[^readIndex])
                minData = this.data[^readIndex];

            writeIndex++;
            readIndex--;
        }

        float maxDataOffset = (float)(maxData / maxData);   //1
        float minDataOffset = (float)(minData / maxData);   //0.8~


        float startPosition = -this.graph_Width / 2;
        float maxYPosition = this.graph_Height / 2;

        //print("MAX :" + maxData);
        //print("MIN :" + minData);
        //print("MAXOFFSET : " + maxDataOffset);
        //print("MINOFFSET : " + minDataOffset);
        //print("MAXOFFSET NORMAL :" + (float)((maxDataOffset - minDataOffset) / (maxDataOffset - minDataOffset)));
        //print("MINOFFSET NORMAL :" + (float)((minDataOffset - minDataOffset) / (maxDataOffset - minDataOffset)));
        for (int i = 0; i < n; i++)
        {
            float dataOffset = (float)(this.dataToChart[i] / maxData); // 0.9~
            float yPosOffset = (float)(2*((dataOffset - minDataOffset)/(maxDataOffset - minDataOffset))-1);  // 0.5

            //print("IN FOR DataToChart[" + i + "] = " + this.dataToChart[i]);
            //if (yPosOffset > 1 || yPosOffset < 0)
            //    print("yPosOffset OVER: " + yPosOffset);
            if (this.dataToChart[i] > maxData || this.dataToChart[i] < minData)
                print("dataToChart OVER: " + dataToChart[i]);
            GameObject dot = Resources.Load<GameObject>("Prefabs/ChartDot");
            GameObject Instance = (GameObject)Instantiate(dot, GameObject.Find("ChartStock").transform.Find("DotGroup"));

            RectTransform dotRT = dot.GetComponent<RectTransform>();
            dotRT.anchoredPosition = new Vector2(startPosition + (graph_Width / (n - 1) * i), maxYPosition * yPosOffset);   // 최대 높이 * 0.0~1.0
            print(maxYPosition * yPosOffset);
        }
    }
}
