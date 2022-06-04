using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockBuyBtnConfirm : MonoBehaviour
{
    public void btnClicked() {
        GameObject.Find("AppStock").transform.Find("StockBuyPage").GetComponent<StockBuyPage>().BuyConfirmClicked();
    }
}
