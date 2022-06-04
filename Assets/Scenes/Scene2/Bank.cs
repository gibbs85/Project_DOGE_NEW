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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int money = GameObject.Find("Player").GetComponent<Player>().GetMoney();
        Txt2.text = "���� �ܰ�: " + money.ToString();
        remMoney.text = "���� �ں���: " + money.ToString();
        int investment = GameObject.Find("Player").GetComponent<Player>().GetInvestment();
        Txt3.text = "���� �ڻ�: " + investment.ToString();

        int saving = GameObject.Find("Player").GetComponent<Player>().GetSaving();
        Txt4.text = "����: " + saving.ToString();

        int total = money + investment + saving;
        Txt5.text = "�� �ڻ�: " + total.ToString();
    }

    
}
