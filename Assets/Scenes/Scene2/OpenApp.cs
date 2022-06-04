using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApp : MonoBehaviour
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
        appOpen.SetActive(true);
    }

    public void ClosingApp()
    {
        appClose.SetActive(false);
    }
}
