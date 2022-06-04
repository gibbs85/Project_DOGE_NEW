using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class StockBuyBtn : MonoBehaviour
{
    public void btnClicked()
    {
        string input = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;

        GameObject.Find("StockBuyPage").GetComponent<StockBuyPage>().inputHandle(input);
    }
}
