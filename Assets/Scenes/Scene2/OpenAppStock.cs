using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAppStock : MonoBehaviour
{
    //public Button btn;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    btn.onClick.AddListener(btnClicked);
    //}

    public void btnClicked()
    { 
        GameObject.Find("ScreenHome").SetActive(false);
        GameObject.Find("PhoneOnHand").transform.Find("AppStock").gameObject.SetActive(true);
    }
}
