using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int Money = 150;
    public static int Saving = 0;
    public static int Investment = 0;
    public static int Day = 2; //0=�����, 2=������ .... 6 = �ݿ���
    public static int Date = 30;
    public static int Tired = 5;

    public Text dday;
    public Text date;
    public Text remMoney;
    public Text tired;

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
    public void nextDay()
    {
        Tired = 5;
        tired.text = "�Ƿε� (" + Tired.ToString() + "/5)";

        Date--;
        dday.text = "D-" + Date.ToString();
        
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

        print(Day);
    }
}
