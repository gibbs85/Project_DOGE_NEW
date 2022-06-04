using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockSellBtnDel : MonoBehaviour
{
    public void btnClicked()
    {
        string input = "99";

        GameObject.Find("StockSellPage").GetComponent<StockSellPage>().inputHandle(input);
    }
}
