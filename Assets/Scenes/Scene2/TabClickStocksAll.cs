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
        //if (isOn){
        //    Debug.Log("TabAllTrue");
        //    GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(false);
        //    GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(true); 
        //}
        //else
        //{
        //    Debug.Log("TabAllFalse");
        //    GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(true);
        //    GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(false);
        //}

    }
}
