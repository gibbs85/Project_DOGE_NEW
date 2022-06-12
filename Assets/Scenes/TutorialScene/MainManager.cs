using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [Header("Dialog")]
    public GameObject talkPanel;

    [Header("Phone UI")]
    public GameObject ListBtn;
    public GameObject HomeBtn;
    public GameObject BackBtn;

    [Header("Apps")]
    public GameObject BankBtn;
    public GameObject StockBtn;
    public GameObject KakaoBtn;
    public GameObject SNSBtn;
    public GameObject SaveBtn;
    public GameObject SettingsBtn;
    public GameObject AppHighlight;

    [Header("Screens")]
    public GameObject DefaultScreen;
    public GameObject BankScreen;
    public GameObject StockScreen;
    public GameObject SettingScreen;
    public GameObject SaveScreen;

    private GameObject currentScreen;
    private GameObject previousScreen;
    private bool appHighlighted;
    private int flag;
    private bool isTutorial;

    // Scale
    private Vector3 AppScale = new Vector3(0.5f, 0.5f, 1.0f);
    private Vector3 PhoneUIScale = new Vector3(0.4f, 0.4f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        // Initialize
        isTutorial = true;
        appHighlighted = false;
        talkPanel.SetActive(false);
        AppHighlight.SetActive(false);

        // Set First Screen
        SaveScreen.SetActive(false);
        SettingScreen.SetActive(false);
        StockScreen.SetActive(false);
        BankScreen.SetActive(false);
        DefaultScreen.SetActive(true);
        currentScreen = DefaultScreen; 
        
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (flag)
        {
            case 0:
                {
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n한번 연습이나 해보자!!");
                    break;
                }
            case 1:
                {
                    // Enable App Highlight
                    EnableAppHighlight(BankBtn.transform.position, AppScale);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n이 어플들은 뭐지?? 클릭해볼까?");
                    break;
                }
            case 2:
                {
                    // Active Bank Screen
                    ChangeScreen(BankScreen);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "이건 은행 어플이구나\n" +
                        "지금 내가 넣어놓은 300만원이 들어있네!! 입출금도 자유롭고 심지어 이자도 있네??\n" +
                        "이 시드머니로 등록금을 모아보는거야\n" +
                        "적금...? 저건 토요일에만 열리나보다 나중에 다시 봐야겠는걸");
                    break;
                }
            case 3:
                {
                    // Enable App Highlight
                    EnableAppHighlight(HomeBtn.transform.position, PhoneUIScale);

                    // Disable Panel
                    talkPanel.SetActive(false);

                    break;
                }
            case 4:
                {
                    // Active Default Screen
                    ChangeScreen(DefaultScreen);

                    // Enable App Highlight
                    EnableAppHighlight(StockBtn.transform.position, AppScale);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "이번엔 이걸 눌러보자");

                    break;
                }
            case 5:
                {
                    // Active Default Screen
                    ChangeScreen(StockScreen);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "이건 증권 어플이구나!\n" +
                        "10개 종목 시세가 이렇게 한눈에 나오네!!\n" +
                        "이걸 잘 보고 어디다 투자할지 정해야겠어!!");

                    break;
                }
            case 6:
                {
                    // Enable App Highlight
                    EnableAppHighlight(HomeBtn.transform.position, PhoneUIScale);

                    // Disable Panel
                    talkPanel.SetActive(false);

                    break;
                }
            case 7:
                {
                    // Active Default Screen
                    ChangeScreen(DefaultScreen);

                    // Enable App Highlight
                    EnableAppHighlight(SettingsBtn.transform.position, AppScale);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "이건 환경설정이야!");

                    break;
                }
            case 8:
                {
                    // Enable App Highlight
                    ChangeScreen(DefaultScreen);

                    // Enable App Highlight
                    EnableAppHighlight(SaveBtn.transform.position, AppScale);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "이건 내가 주식으로 돈 번 일기장이네");

                    break;
                }
            case 9:
                {
                    // Enable App Highlight
                    ChangeScreen(DefaultScreen);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "자!!! 모든 준비는 완벽하다!! 난 자신있어!!\n" +
                        "화성 갈끄니까아~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                    break;
                }
            case 10:
                {
                    isTutorial = false;
                    SceneManager.LoadScene("Scene2");
                    break;
                }
        }

        if (Input.anyKeyDown)
        {
            if(!appHighlighted && isTutorial)
                flag++;
        }
    }

    private void ChangeScreen(GameObject newScreen)
    {
        currentScreen.SetActive(false);
        previousScreen = currentScreen;
        currentScreen = newScreen;
        currentScreen.SetActive(true);
    }
    
    private void EnableAppHighlight(Vector3 pos, Vector3 scale)
    {
        AppHighlight.transform.position = pos;
        AppHighlight.transform.localScale = scale;  
        AppHighlight.SetActive(true);
        appHighlighted = true;
    }

    private void OnClickAppHighlight() { flag++; appHighlighted = false; AppHighlight.SetActive(false); }
    
    public void OpenApp(GameObject newScene)
    {
        if (!isTutorial)
            ChangeScreen(newScene);
    }

    public void GoHomeScreen()
    {
        ChangeScreen(DefaultScreen);
    }

    public void GoBackScreen()
    {
        ChangeScreen(previousScreen);
    }
}
/*
 * 
            if (flag == 1)
            {
                healthObject.GetComponent<SpriteRenderer>().sprite = healthMark;
                talkPanel.GetComponent<MainDialog>().ShowDialog("피로도는 패망이의 체력입니다. \n주식차트를 너무 오래보고 있으면 패망이가 힘들어합니다. \n일정시간이 지나면 피로도가 점점 줄게되고 피로도를 다 소모하면 하루동안의 수익을 되돌아 보며 다음날로 넘어갑니다");
            }
            else if (flag == 2)
            {
                healthObject.GetComponent<SpriteRenderer>().sprite = healthNormal;
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 한번 연습이나 해보자!! 김패망: 이 어플들은 뭐지 ??");
            }
            else if (flag == 3)
            {
                BankObject.GetComponent<Image>().sprite = BankMark;
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 이건 은행 어플이구나! \n김패망: 지금 내가 넣어놓은 300만원이 들어있네!!입출금도 자유롭고 심지어 이자도 있네?? \n김패망 : 많이 넣어놓으면 금방 이자가 불겠어!!");
            }
            else if (flag == 4)
            {
                BankObject.GetComponent<Image>().sprite = BankNormal;
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 이건 증권 어플이구나! \n김패망: 10개 종목 시세가 이렇게 한눈에 나오네!! \n김패망 : 이걸 잘 보고 어디다 투자할지 정해야겠어!!");
            }
            else if (flag == 5)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 이건 환경설정이야! \n김패망: 음악소리가 너무 크거나 창이 너무 작아서 안보이면 조절해봐야겠어!");
            }
            else if (flag == 6)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 이건 내가 주식으로 돈 번 일기장이네! \n김패망: 좋았어!! 지금부터 열심히 벌어서 매일매일 수익기록을 여기다 써야겠어!");
            }
            else if (flag == 7)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 이건 내가 하고 있는 알바 목록이네! \n김패망: 내가 알바를 하면서 번 돈을 여기서 볼 수 있겠어!!");
            }
            else if (flag == 8)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 이건 메신저 어플이구나! \n김패망: 주식톡방이나 지인으로부터 정보를 얻을 수 있겠어! \n김패망 : 알림이 울리면 바로바로 체크해봐야겠다!!");
            }
            else if (flag == 9)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("김패망 : 자!!! 모든준비는 완벽하다!! 난 자신있어!! \n김패망: 화성 갈끄니까아~~~~~~~~~~~~~~~~~~~~!!!");
            }
            else if (flag == 10)
            {
                talkPanel.SetActive(false);
            }*/
