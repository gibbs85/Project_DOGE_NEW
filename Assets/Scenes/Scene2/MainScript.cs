using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using StockDOGE;

public class MainScript : MonoBehaviour
{
    public static int DateEndGame = 31; // ������ ��.
    public static int Time = (int)SettingsStock.TIME_START_OF_DAY; // ù �ð�
    public static int[] TimeTurns = { (int)SettingsStock.TIME_START_OF_DAY, 10, 13, 15 }; // �� ������ �ð�
    public static int Turn = 0; // 0���� �÷��� �Ұ�. 1, 2, 3, ... ���� TimeTurns�� ��ġ
    public static int Day = 2; //0=�����, 2=������ .... 6 = �ݿ���
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
        tired.text = "�Ƿε� (" + Tired.ToString() + "/5)";

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
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n�����. �������� ����? �ƴϾ� ����� �ⷷ�ٸ��� ����\n�� �λ��� �׷��� ��");
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("BadEndingScene");
            }
        }
        else if (totalMoney <= 1500000 && !showText150)
        {
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n���� ���̷��� ������...?? ��������..? �����ž�..��ġ?? ��Ƽ���.. ��������.");
            showText150 = true;
        }
        else if (totalMoney >= 4000000 && !showText400)
        {
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n�� �̳� ���� �� �� �̳� �������!!! �� ���� ��!! ��!!!!");
            showText400 = true;
        }
        else if (totalMoney >= 4500000)
        {
            talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n����!!!�����̶��!!!! ��ϱ��� �������� �� �� �־�!!!");
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
        //Tired -= tired;
        Player.player.SetTired(Tired - tired);

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
        GameObject.Find("Stocks").GetComponent<Stocks>().UpdateAllStocks(TimeTurns[Turn] - TimeTurns[Turn - 1]);

        //Tired = 5;
        Player.player.SetTired(5);
        int Tired = Player.player.GetTired();

        ObjTired5.SetActive(true);  //5���� true
        ObjTired4.SetActive(false);
        ObjTired3.SetActive(false);
        ObjTired2.SetActive(false);
        ObjTired1.SetActive(false);
        ObjTired0.SetActive(false);

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
            Player.player.Money = Player.player.Money + Player.player.Saving + (int)(Player.player.Saving * 0.2);
            Player.player.Saving = 0;
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
