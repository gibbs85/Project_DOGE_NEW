using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public Text Txt2;
    public Text Txt3;
    public Text Txt4;
    public Text Txt5;
    public Text remMoney;
    public GameObject tired5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int total = 0;

        int Len;
        int count;
        int temp;

        ///////통장 잔고////////
        int money = Player.player.GetMoney();
        total += money;
        string str2 = money.ToString(); //수정 요구
        Len = str2.Length; //수정 요구
        count = 0;
        Txt2.text = ""; //수정 요구
        while (true)
        {
            count++;
            temp = money % 10;
            money /= 10;
            Txt2.text = temp.ToString() + Txt2.text;

            if (count % 3 == 0 && count != Len)
            {
                Txt2.text = "," + Txt2.text;
            }
            if (count == Len)
            {
                break;
            }
        }
        remMoney.text = "남은 자본금: " + Txt2.text + "원";
        Txt2.text = "통장 잔고: " + Txt2.text + "원"; //수정 요구

        //////투자 자산///////////
        int investment = GameObject.Find("Stocks").GetComponent<Stocks>().MoneySellAll();
        total += investment;
        string str3 = investment.ToString(); //수정 요구
        Len = str3.Length; //수정 요구
        count = 0;
        Txt3.text = ""; //수정 요구
        while (true)
        {
            count++;
            temp = investment % 10;
            investment /= 10;
            Txt3.text = temp.ToString() + Txt3.text;

            if (count % 3 == 0 && count != Len)
            {
                Txt3.text = "," + Txt3.text;
            }
            if (count == Len)
            {
                break;
            }
        }
        Txt3.text = "투자 자산: " + Txt3.text + "원";

        //////적금///////////
        int saving = Player.player.GetSaving();
        total += saving;
        string str4 = saving.ToString(); //수정 요구
        Len = str4.Length; //수정 요구
        count = 0;
        Txt4.text = ""; //수정 요구
        while (true)
        {
            count++;
            temp = saving % 10;
            saving /= 10;
            Txt4.text = temp.ToString() + Txt4.text;

            if (count % 3 == 0 && count != Len)
            {
                Txt4.text = "," + Txt4.text;
            }
            if (count == Len)
            {
                break;
            }
        }
        Txt4.text = "적금: " + Txt4.text + "원";
        //////총 자산///////////
        string str5 = total.ToString(); //수정 요구
        Len = str5.Length; //수정 요구
        count = 0;
        Txt5.text = ""; //수정 요구
        while (true)
        {
            count++;
            temp = total % 10;
            total /= 10;
            Txt5.text = temp.ToString() + Txt5.text;

            if (count % 3 == 0 && count != Len)
            {
                Txt5.text = "," + Txt5.text;
            }
            if (count == Len)
            {
                break;  
            }
        }

        Txt5.text = "총 자산: " + Txt5.text + "원";
    }

}
