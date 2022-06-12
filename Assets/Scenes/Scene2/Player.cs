using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using StockDOGE;

public class Player : MonoBehaviour
{
    public static Player player;
    public string UserName = "";
    public int Money = 3000000;
    public int Saving = 0;
    public int Investment = 0;
    public int Tired = 5;
    
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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (player == null)
        {
            player = this;
        }
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

    public int GetTired()
    {
        return Tired;
    }
    
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
}
