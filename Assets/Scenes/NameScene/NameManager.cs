using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NameManager : MonoBehaviour
{
    public GameObject InputCanvas;
    public GameObject CheckCanvas;
    public GameObject InputText;
    public GameObject CheckText;
    // Start is called before the first frame update
    void Start()
    {
        InputCanvas.SetActive(true);
        CheckCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onNextBtnClick()
    {
        CheckText.GetComponent<TextMeshProUGUI>().text = "주인공의 이름은 " + InputText.GetComponent<TextMeshProUGUI>().text + "입니다.";
        InputCanvas.SetActive(false);
        CheckCanvas.SetActive(true);
    }


    public void onCancelBtnClick()
    {
        CheckCanvas.SetActive(false);
        InputCanvas.SetActive(true);

    }


    public void onStartBtnClick()
    {
        Player.player.UserName = InputText.GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene("OpeningScene");
    }
}
