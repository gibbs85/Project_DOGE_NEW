using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{
    public int SceneID = 0;

    public GameObject StoryCanvas;
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject BackBtn;
    public GameObject NextBtn;
    public GameObject BG;
    private Color Green;
    private Color Blue;
    // Start is called before the first frame update
    void Start()
    {
        Green = new Color(70 / 255f, 106 / 255f, 52 / 255f);
        Blue = new Color(52 / 255f, 62 / 255f, 126 / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        switch(SceneID)
        {
            case 0:
                BG.GetComponent<SpriteRenderer>().color = Green;
                StoryCanvas.SetActive(true);
                Tutorial1.SetActive(false);
                Tutorial2.SetActive(false);
                Tutorial3.SetActive(false);
                BackBtn.SetActive(false);
                NextBtn.SetActive(true);
                break;
            case 1:
                BG.GetComponent<SpriteRenderer>().color = Blue;
                StoryCanvas.SetActive(false);
                Tutorial1.SetActive(true);
                Tutorial2.SetActive(false);
                Tutorial3.SetActive(false);
                BackBtn.SetActive(true);
                NextBtn.SetActive(true);
                break;
            case 2:
                BG.GetComponent<SpriteRenderer>().color = Blue;
                StoryCanvas.SetActive(false);
                Tutorial1.SetActive(false);
                Tutorial2.SetActive(true);
                Tutorial3.SetActive(false);
                BackBtn.SetActive(true);
                NextBtn.SetActive(true);
                break;
            case 3:
                BG.GetComponent<SpriteRenderer>().color = Blue;
                StoryCanvas.SetActive(false);
                Tutorial1.SetActive(false);
                Tutorial2.SetActive(false);
                Tutorial3.SetActive(true);
                BackBtn.SetActive(true);
                NextBtn.SetActive(true);
                break;
        }
    }

    public void NextCanvas()
    {
        if (SceneID < 2)
        {
            SceneID++;
        }
        else if (SceneID == 2)
        {
            NextBtn.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "시작하기";
            SceneID++;
        }
        else if (SceneID == 3)
        { 
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            SceneID = 3;
        }
    }

    public void BackCanvase()
    {
        if (SceneID <= 2 && SceneID > 0)
        {
            SceneID--;
        }
        else if (SceneID == 3)
        {
            NextBtn.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "다음";
            SceneID--;
        }
        else
        {
            SceneID = 0;
        }
    }
}
