using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabClickStocksAll : MonoBehaviour
{


    public void clicked(bool isOn)
    {
        GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(false);
        GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(true);

        GameObject.Find("StockToggleAll").transform.Find("Label").GetComponent<Text>().color = new Color(255, 192, 0);
        GameObject.Find("StockToggleOwned").transform.Find("Label").GetComponent<Text>().color = new Color(255, 255, 255);

    }
}
