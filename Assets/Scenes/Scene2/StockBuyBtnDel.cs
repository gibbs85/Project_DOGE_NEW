using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class StockBuyBtnDel : MonoBehaviour
{
    public void btnClicked()
    {
        string input = "99";

        GameObject.Find("StockBuyPage").GetComponent<StockBuyPage>().inputHandle(input);
    }
}
