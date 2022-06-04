using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabClickStockOwned : MonoBehaviour
{
    public void clicked(bool isOn)
    {
        GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(true);
        GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockListOwned").GetComponent<StockListOwned>().init();
    }
}
