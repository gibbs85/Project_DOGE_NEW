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
    public static int Day = 2; //0=토요일, 2=월요일 .... 6 = 금요일
    public static int Date = -1;
    public static int Tired = 5;

    /*////////////////////////////////////////////////////////////////////////
     * 업데이트.
     * 2022.06.04
     * 
     * using StockDOGE 추가
     * Date = 0 으로 수정
     * public static int DateEndGame 추가
     * public static int Time 추가
     * public static int[] TimeTurns 추가
     * public static int Turn 추가
     * void nextDay() 에서 Date 업데이트 방식 변경
     * void nextTime() 추가
     * void InitPlay() 추가
     * void refresh() 추가
     * 
     * 작성자. 박동옥
     *//// <summary>
     /// /////////////////////////////////////////////////////////////////////
     /// </summary>
    public static int DateEndGame = 31; // 마지막 날.
    public static int Time = (int)SettingsStock.TIME_START_OF_DAY; // 첫 시간
    public static int[] TimeTurns = { (int)SettingsStock.TIME_START_OF_DAY, 10, 13, 15 }; // 턴 마다의 시간
    public static int Turn = 0; // 0턴은 플레이 불가. 1, 2, 3, ... 턴은 TimeTurns에 매치


    public Text dday;
    public Text date;
    public Text remMoney;
    public Text tired;

    /*////////////////////////////////////////////////////////////////////////
     * 
     * void Start() 가 두 번 실행되는데 이유를 찾지 못함.
     * 
     *////////////////////////////////////////////////////////////////////////


    void Start()
    {
        print("Start");
        InitPlay();
    }
    void Update()
    {
        tired.text = "피로도 (" + Tired.ToString() + "/5)";
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
         * 시간과 턴, 주식 업데이트 추가
         */
        Turn = 1; //
        Time = TimeTurns[Turn];
        GameObject.Find("Stocks").GetComponent<Stocks>().UpdateAllStocks(TimeTurns[Turn] - TimeTurns[Turn-1]);

        Tired = 5;
        tired.text = "피로도 (" + Tired.ToString() + "/5)";

        //Date--;
        //dday.text = "D-" + Date.ToString();

        /*
         * Date++ 방식으로 변경. 박동옥이 업데이트.
         */
        Date++;
        dday.text = "D-" + (DateEndGame - Date).ToString();

        Day++;
        if (Day == 6)   //만약 금요일이면
        {
            Money = Money + Saving + (int)(Saving * 0.2);
            Saving = 0;
        }
        else if (Day == 7) //7이면 0으로 변경
        {
            Day = 0;
        }
        if (Day == 0) date.text = "토요일";
        else if (Day == 1) date.text = "일요일";
        else if (Day == 2) date.text = "월요일";
        else if (Day == 3) date.text = "화요일";
        else if (Day == 4) date.text = "수요일";
        else if (Day == 5) date.text = "목요일";
        else if (Day == 6) date.text = "금요일";
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
            "현재 시간: " + tempTime.ToString() + ":" + "00 " + AMPM;
    }

    public void refresh()
    {
        //void OnEnable()도 참고
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
