using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class ChartStock : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    public int countRecordHour = (int)(SettingsStock.COUNT_UPDATE_PER_HOUR);

    public int countDays = 1;

    private double[] data;
    private double[] dataToChart;
    private int[] dataXtoChart;

    public Color Colorhigh;
    public Color Colorlow;
    public Color Colormid;

    //public RectTransform GraphArea;

    private float graph_Width;
    private float graph_Height;

    public double getPriceOld()
    {
        return this.dataToChart[0];
    }

    public double getPriceNow()
    {
        return this.dataToChart[^1];
    }

    public void start()
    {
        this.setDays(1);
    }
    public void init()
    {
        this.setDays(1);
        this.refresh();
    }

    public void setDays(int n)
    {
        this.countDays = n;
    }

    public void refresh()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        int countchild = GameObject.Find("ChartStock").transform.Find("DotGroup").childCount;
        for (int i = 0; i < countchild; i++)
            Destroy(GameObject.Find("ChartStock").transform.Find("DotGroup").GetChild(i).gameObject);

        countchild = GameObject.Find("ChartStock").transform.Find("LineGroup").childCount;
        for (int i = 0; i < countchild; i++)
            Destroy(GameObject.Find("ChartStock").transform.Find("LineGroup").GetChild(i).gameObject);

        this.graph_Width = 160.0f;
        this.graph_Height = 110.0f;

        this.getData();

        if(this.countDays == 1)
            this.chartNrecords((GameObject.Find("Player").GetComponent<Player>().GetTime() - (int)(SettingsStock.TIME_START_OF_DAY))*(int)(SettingsStock.COUNT_UPDATE_PER_HOUR));
        //else
        //    this.chartNrecords((GameObject.Find("Player").GetComponent<Player>().GetTime() - (int)(SettingsStock.TIME_START_OF_DAY)) * (int)(SettingsStock.COUNT_UPDATE_PER_HOUR) + (      ((int)(SettingsStock.COUNT_UPDATE_PER_HOUR) * ((this.countDays-1)) * 6)     )   );
        else
            this.sampleData(((int)(SettingsStock.COUNT_UPDATE_PER_HOUR) * ((this.countDays)) * (int)(SettingsStock.TIME_END_OF_DAY)));


    }

    public void getData()
    {
        string stockName = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().getStockName();
        this.data = GameObject.Find("Stocks").GetComponent<Stocks>().getStockByName(stockName).getPriceRecord();
    }

    public void sampleData(int n)
    {
        print("ORIGIN :" + this.data.Length);
        int sampleRateDay = 1;      // n 27000

        int writeIndex = 0;
        int readIndex = n;
        int sampleRate = (n / (((int)(SettingsStock.COUNT_UPDATE_PER_HOUR) * (sampleRateDay) * (int)(SettingsStock.TIME_END_OF_DAY)))) +1;
        int sampleCount = (n / sampleRate);
        double[] dataSampled = new double[sampleCount];       // 6700샘플
        print("SAMPLE :" + dataSampled.Length);

        while (readIndex > sampleRate)
        {
            print("WriteIndex :" + writeIndex);
            print("ReadIndex :" + readIndex);
            dataSampled[writeIndex] = this.data[^readIndex]; 
            writeIndex++;
            //readIndex = readIndex - (n / dataSampled.Length);
            readIndex = readIndex - sampleRate;
        }
        dataSampled[^1] = this.data[^1];
        print("HERE");
        //print("SAMPLE :"+dataSampled.Length);
        this.data = dataSampled;
        this.chartNrecords(sampleCount);
        
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

        GameObject.Find("TextStockChartMax").GetComponentInChildren<TextMeshProUGUI>().text = ((int)(maxData)).ToString("c", numberFormat);
        GameObject.Find("TextStockChartMid").GetComponentInChildren<TextMeshProUGUI>().text = ((int)( (maxData+minData) / 2)).ToString("c", numberFormat);
        GameObject.Find("TextStockChartMin").GetComponentInChildren<TextMeshProUGUI>().text = ((int)(minData)).ToString("c", numberFormat);

        float maxDataOffset = (float)(maxData / maxData);   //1
        float minDataOffset = (float)(minData / maxData);   //0.8~


        float startPosition = -this.graph_Width / 2;
        float maxYPosition = this.graph_Height / 2;

        Vector2 prevDotPos = Vector2.zero;
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

            GameObject dot = Resources.Load<GameObject>("Prefabs/ChartDot");
            GameObject Instance = (GameObject)Instantiate(dot, GameObject.Find("ChartStock").transform.Find("DotGroup"));

            RectTransform dotRT = dot.GetComponent<RectTransform>();
            dotRT.anchoredPosition = new Vector2(startPosition + (graph_Width / (n - 1) * i), maxYPosition * yPosOffset);   // 최대 높이 * 0.0~1.0

            if (i == 0)
            {
                prevDotPos = dotRT.anchoredPosition;
                continue;
            }

            GameObject line = Resources.Load<GameObject>("Prefabs/ChartLine");
            GameObject InstanceLine = Instantiate(line, GameObject.Find("ChartStock").transform.Find("LineGroup"));
            InstanceLine.transform.localScale = Vector3.one;

            RectTransform lineRT = InstanceLine.GetComponent<RectTransform>();

            float lineWidth = Vector2.Distance(prevDotPos, dotRT.anchoredPosition);
            float xPos = (prevDotPos.x + dotRT.anchoredPosition.x) / 2;
            float yPos = (prevDotPos.y + dotRT.anchoredPosition.y) / 2;

            Vector2 dir = (dotRT.anchoredPosition - prevDotPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            lineRT.anchoredPosition = new Vector2(xPos, yPos);
            lineRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lineWidth);
            lineRT.localRotation = Quaternion.Euler(0f, 0f, angle);

            //GameObject maskPanel = Instantiate(GameObject.Find("ChartStock").transform.Find("LineGroup").transform.Find("MaskPanel").gameObject, Vector3.zero, Quaternion.identity);
            //maskPanel.transform.SetParent(GameObject.Find("ChartStock").transform.Find("LineGroup"));
            //maskPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            //maskPanel.transform.SetParent(InstanceLine.transform);

            if (this.dataToChart[^1] > this.dataToChart[0])
                InstanceLine.GetComponent<Image>().color = new Color32(255, 38, 4, 255);
            else if (this.dataToChart[^1] < this.dataToChart[0])
                InstanceLine.GetComponent<Image>().color = new Color32(0, 112, 192, 255);
            else
                InstanceLine.GetComponent<Image>().color = new Color32(129, 128, 131, 255);


            prevDotPos = dotRT.anchoredPosition;
        }

        double rate = ((this.dataToChart[^1] / this.dataToChart[0]) - 1) * 100;
        GameObject.Find("StockDetailTitle").transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getName();
        GameObject.Find("StockDetailTitle").transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getPrice().ToString("c", numberFormat)
        + "(" + rate.ToString("F2") + "%)";

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

        GameObject.Find("StockDetailDesc").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getDesc();
    }
}
