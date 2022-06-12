using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankSavingUpdater : MonoBehaviour
{
    public Text txtSaving;
    public static int intsaving = 0;

    public void btnAddSaving()
    {
        int money = Player.player.GetMoney();
        int day = GameObject.Find("Main").GetComponent<MainScript>().GetDay();
        int tired = Player.player.GetTired();
        if (intsaving <= money && day == 0 && tired >= 2) { //���� �ݾ��� ���� �� ���� && ����� && �Ƿε� 2�̻�
            Player.player.SetSaving(intsaving);
            money -= intsaving;
            Player.player.SetMoney(money);
            tired -= 2;
            Player.player.SetTired(tired);
        }
        txtSaving.text = "0��";
        intsaving = 0;
    }

    public void btn1()
    {
        intsaving *= 10;
        intsaving += 1;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn2()
    {
        intsaving *= 10;
        intsaving += 2;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn3()
    {
        intsaving *= 10;
        intsaving += 3;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn4()
    {
        intsaving *= 10;
        intsaving += 4;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn5()
    {
        intsaving *= 10;
        intsaving += 5;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn6()
    {
        intsaving *= 10;
        intsaving += 6;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn7()
    {
        intsaving *= 10;
        intsaving += 7;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn8()
    {
        intsaving *= 10;
        intsaving += 8;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn9()
    {
        intsaving *= 10;
        intsaving += 9;
        txtSaving.text = intsaving.ToString() + "��";
    }

    public void btn00()
    {
        intsaving *= 100;
        txtSaving.text = intsaving.ToString() + "��";
    }
    public void btn0()
    {
        intsaving *= 10;
        txtSaving.text = intsaving.ToString() + "��";
    }
    public void btnBack()
    {
        intsaving /= 10;
        txtSaving.text = intsaving.ToString() + "��";
    }
}
