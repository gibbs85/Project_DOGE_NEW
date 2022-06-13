using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabClickStockOwned : MonoBehaviour
{
    public void clicked(bool isOn)
    {
        print("clicked");
        GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(true);
        GameObject.Find("AppStock").transform.Find("StockListOwned").GetComponent<StockListOwned>().init();

        GameObject.Find("StockToggleOwned").transform.Find("Label").GetComponent<Text>().color = new Color(255, 192, 0);
        GameObject.Find("StockToggleAll").transform.Find("Label").GetComponent<Text>().color = new Color(255, 255, 255);
    }
}
