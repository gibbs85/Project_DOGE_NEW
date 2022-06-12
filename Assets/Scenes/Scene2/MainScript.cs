using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using StockDOGE;

public class MainScript : MonoBehaviour
{
    public static int DateEndGame = 31; // 마지막 날.
    public static int Time = (int)SettingsStock.TIME_START_OF_DAY; // 첫 시간
    public static int[] TimeTurns = { (int)SettingsStock.TIME_START_OF_DAY, 10, 13, 15 }; // 턴 마다의 시간
    public static int Turn = 0; // 0턴은 플레이 불가. 1, 2, 3, ... 턴은 TimeTurns에 매치
    public static int Day = 2; //0=토요일, 2=월요일 .... 6 = 금요일
    public static int Date = -1;

    public GameObject talkPanel;

    [Header("Manage")]
    public Text dday;
    public Text date;
    public Text remMoney;
    public Text tired;

    public GameObject ObjTired5;
    public GameObject ObjTired4;
    public GameObject ObjTired3;
    public GameObject ObjTired2;
    public GameObject ObjTired1;
    public GameObject ObjTired0;

    public bool showText400;
    public bool showText150;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize
        showText400 = false;
        showText150 = false;

        print("Start");
        InitPlay();
    }

    void Update()
    {
        int Tired = Player.player.GetTired();
        tired.text = "피로도 (" + Tired.ToString() + "/5)";

        ObjTired5.SetActive(false);
        ObjTired4.SetActive(false);
        ObjTired3.SetActive(false);
        ObjTired2.SetActive(false);
        ObjTired1.SetActive(false);
        ObjTired0.SetActive(false);

        if (Tired == 5)
        {
            ObjTired5.SetActive(true);
        }
        else if (Tired == 4)
        {
            ObjTired5.SetActive(false);
            ObjTired4.SetActive(true);
        }
        else if (Tired == 3)
        {
            ObjTired4.SetActive(false);
            ObjTired3.SetActive(true);
        }
        else if (Tired == 2)
        {
            ObjTired3.SetActive(false);
            ObjTired2.SetActive(true);
        }
        else if (Tired == 1)
        {
            ObjTired2.SetActive(false);
            ObjTired1.SetActive(true);
        }
        else if (Tired == 0)
        {
            ObjTired1.SetActive(false);
            ObjTired0.SetActive(true);
        }

        int totalMoney = GameObject.Find("Stocks").GetComponent<Stocks>().MoneySellAll() + Player.player.Money;

        if ((DateEndGame - Date) == -1 || totalMoney <= 0)
        {
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n어디보자. 섬강으로 갈까? 아니야 가까운 출렁다리로 가자\n내 인생이 그렇지 뭐");
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("BadEndingScene");
            }
        }
        else if (totalMoney <= 1500000 && !showText150)
        {
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n발이 왜이렇게 떨리지...?? 오르겠지..? 오를거야..그치?? 버티면돼.. 존버하자.");
            showText150 = true;
        }
        else if (totalMoney >= 4000000 && !showText400)
        {
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n물 겁나 들어올 때 노 겁나 저어야지!!! 더 사자 더!! 더!!!!");
            showText400 = true;
        }
        else if (totalMoney >= 4500000)
        {
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n성공!!!성공이라고!!!! 등록금을 내돈으로 낼 수 있어!!!");
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("HappyEndingScene");
            }
        }

        if(Input.anyKeyDown)
        { 
            talkPanel.SetActive(false);
        }
    }
    public int GetTime()
    {
        return Time;
    }
    public int GetDay()
    {
        return Day;
    }


    /////////////////////////////////////////////
    public bool useTired(int tired)
    {
        int Tired = Player.player.GetTired();
        if (Tired < tired)
            return false;
        Tired -= tired;

        return true;
    }

    public void nextDay()
    {
        int Tired = Player.player.GetTired();
        print("nextDay");
        /*
         * 시간과 턴, 주식 업데이트 추가
         */
        Turn = 1; //
        Time = TimeTurns[Turn];
        GameObject.Find("Stocks").GetComponent<Stocks>().UpdateAllStocks(TimeTurns[Turn] - TimeTurns[Turn - 1]);

        Tired = 5;

        ObjTired5.SetActive(true);  //5번만 true
        ObjTired4.SetActive(false);
        ObjTired3.SetActive(false);
        ObjTired2.SetActive(false);
        ObjTired1.SetActive(false);
        ObjTired0.SetActive(false);

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
            Player.player.Money = Player.player.Money + Player.player.Saving + (int)(Player.player.Saving * 0.2);
            Player.player.Saving = 0;
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
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListAll").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListAll").GetComponent<SecuritiesStockListAll>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").GetComponent<StockDetailDisplay>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockBuyPage").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockBuyPage").GetComponent<StockBuyPage>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListOwned").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListOwned").GetComponent<StockListOwned>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").gameObject.activeSelf == true)
            GameObject.Find("StockDetail").transform.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().refresh();
    }
}
