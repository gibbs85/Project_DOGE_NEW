using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockSellBtnConfirm : MonoBehaviour
{
    public void btnClicked()
    {
        GameObject.Find("AppStock").transform.Find("StockSellPage").GetComponent<StockSellPage>().SellConfirmClicked();
    }
}
