using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAppSaving : MonoBehaviour
{
    public GameObject appOpen;
    public GameObject appClose;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpeningApp()
    {
        int Day = GameObject.Find("Main").GetComponent<MainScript>().GetDay();
        if (Day == 0)
            appOpen.SetActive(true);
    }

    public void ClosingApp()
    {
        int Day = GameObject.Find("Main").GetComponent<MainScript>().GetDay();
        if (Day == 0)
            appOpen.SetActive(true);
    }
}
