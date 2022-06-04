using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using StockDOGE;

public class Player : MonoBehaviour
{
    public static int Money = 3000000;
    public static int Saving = 0;
    public static int Investment = 0;
    public static int Day = 2; //0=�����, 2=������ .... 6 = �ݿ���
    public static int Date = -1;
    public static int Tired = 5;

    /*////////////////////////////////////////////////////////////////////////
     * ������Ʈ.
     * 2022.06.04
     * 
     * using StockDOGE �߰�
     * Date = 0 ���� ����
     * public static int DateEndGame �߰�
     * public static int Time �߰�
     * public static int[] TimeTurns �߰�
     * public static int Turn �߰�
     * void nextDay() ���� Date ������Ʈ ��� ����
     * void nextTime() �߰�
     * void InitPlay() �߰�
     * void refresh() �߰�
     * 
     * �ۼ���. �ڵ���
     *//// <summary>
     /// /////////////////////////////////////////////////////////////////////
     /// </summary>
    public static int DateEndGame = 31; // ������ ��.
    public static int Time = (int)SettingsStock.TIME_START_OF_DAY; // ù �ð�
    public static int[] TimeTurns = { (int)SettingsStock.TIME_START_OF_DAY, 10, 13, 15 }; // �� ������ �ð�
    public static int Turn = 0; // 0���� �÷��� �Ұ�. 1, 2, 3, ... ���� TimeTurns�� ��ġ


    public Text dday;
    public Text date;
    public Text remMoney;
    public Text tired;

    /*////////////////////////////////////////////////////////////////////////
     * 
     * void Start() �� �� �� ����Ǵµ� ������ ã�� ����.
     * 
     *////////////////////////////////////////////////////////////////////////


    void Start()
    {
        print("Start");
        InitPlay();
    }
    void Update()
    {
        tired.text = "�Ƿε� (" + Tired.ToString() + "/5)";
    }

    public int GetMoney()
    {
        return Money;
    }

    public int GetSaving()
    {
        return Saving;
    }

    public int GetInvestment()
    {
        return Investment;
    }

    public int GetDay()
    {
        return Day;
    }
    public int GetTired()
    {
        return Tired;
    }
    public int GetTime()
    {
        return Time;
    }
    /////////////////////////////////////////////
    public void SetMoney(int a)
    {
        Money = a;
    }

    public void SetSaving(int a)
    {
        Saving = a;
    }

    public void SetInvestment(int a)
    {
        Investment = a;
    }
    public void SetTired(int a)
    {
        Tired = a;
    }
    /////////////////////////////////////////////
    public bool useTired(int tired)
    {
        if (Tired < tired)
            return false;
        Tired -= tired;
        return true;
    }
    
    public void nextDay()
    {
        print("nextDay");
        /*
         * �ð��� ��, �ֽ� ������Ʈ �߰�
         */
        Turn = 1; //
        Time = TimeTurns[Turn];
        GameObject.Find("Stocks").GetComponent<Stocks>().UpdateAllStocks(TimeTurns[Turn] - TimeTurns[Turn-1]);

        Tired = 5;
        tired.text = "�Ƿε� (" + Tired.ToString() + "/5)";

        //Date--;
        //dday.text = "D-" + Date.ToString();

        /*
         * Date++ ������� ����. �ڵ����� ������Ʈ.
         */
        Date++;
        dday.text = "D-" + (DateEndGame - Date).ToString();

        Day++;
        if (Day == 6)   //���� �ݿ����̸�
        {
            Money = Money + Saving + (int)(Saving * 0.2);
            Saving = 0;
        }
        else if (Day == 7) //7�̸� 0���� ����
        {
            Day = 0;
        }
        if (Day == 0) date.text = "�����";
        else if (Day == 1) date.text = "�Ͽ���";
        else if (Day == 2) date.text = "������";
        else if (Day == 3) date.text = "ȭ����";
        else if (Day == 4) date.text = "������";
        else if (Day == 5) date.text = "�����";
        else if (Day == 6) date.text = "�ݿ���";
        SetTextTime();
    }

    /*
     * 
     */
    public void nextTime()
    {
        print("nextTime: " + Time);
        Turn++;
        if (Turn >= TimeTurns.Length)
        {
            nextDay();
        }

        Time = TimeTurns[Turn];
        GameObject.Find("Stocks").GetComponent<Stocks>().UpdateAllStocks(Time - TimeTurns[Turn - 1]);
        SetTextTime();
        refresh();

    }

    public void InitPlay()
    {
        print("InitPlay");
        this.nextDay();
    }

    public void SetTextTime()
    {
        int tempTime;
        string AMPM;
        if (Time > 12)
        {
            tempTime = Time - 12;
            AMPM = "PM";
        }
        else
        {
            tempTime = Time;
            AMPM = "AM";
        }
        GameObject.Find("GameObject").transform.Find("Time").GetComponent<Text>().text = 
            "���� �ð�: " + tempTime.ToString() + ":" + "00 " + AMPM;
    }

    public void refresh()
    {
        //void OnEnable()�� ����
        if(GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListAll").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListAll").GetComponent<SecuritiesStockListAll>().refresh();
        if(GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").GetComponent<StockDetailDisplay>().refresh();
        if(GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockBuyPage").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockBuyPage").GetComponent<StockBuyPage>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListOwned").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListOwned").GetComponent<StockListOwned>().refresh();
    }
}
