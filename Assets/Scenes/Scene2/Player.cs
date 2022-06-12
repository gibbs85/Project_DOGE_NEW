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
