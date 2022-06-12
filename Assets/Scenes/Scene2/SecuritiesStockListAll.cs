using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

using StockDOGE;

public class SecuritiesStockListAll : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    // Start is called before the first frame update
    void Start()
    {
        this.refresh();
    }

    void OnEnable()
    {
        this.refresh();
    }

    public void refresh()
    {
        /*
         * ���� ��ư�� ����
         */

        this.delete();


        /*
         * �ֽ� ������ �о ��ư �߰�
         * 
         */
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;


        for (int i = 0; i < GameObject.Find("Stocks").GetComponent<Stocks>().getStocksCount(); i++)
        {
            double rate = GameObject.Find("Stocks").GetComponent<Stocks>().getRateDay(GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i), GameObject.Find("Main").GetComponent<MainScript>().GetTime());

            GameObject btn = Resources.Load<GameObject>("Prefabs/StockButtonContentListAll");
            GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("StockListAll").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));
            Instance.transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getName();
            Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().text = ((int)GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i).getPrice()).ToString("c", numberFormat)
                + "(" + rate.ToString("F2") + "%)";

            if (rate > 0)
            {
                Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
            }
            else if (rate < 0)
            {
                Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
            }
            else
            {
                Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);
            }

        }

    }

    public void delete()
    {

        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(i).gameObject);
        }
    }
}
