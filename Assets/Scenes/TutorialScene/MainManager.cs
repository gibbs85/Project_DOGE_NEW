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
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n�ѹ� �����̳� �غ���!!");
                    break;
                }
            case 1:
                {
                    // Enable App Highlight
                    EnableAppHighlight(BankBtn.transform.position, AppScale);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n�� ���õ��� ����?? Ŭ���غ���?");
                    break;
                }
            case 2:
                {
                    // Active Bank Screen
                    ChangeScreen(BankScreen);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "�̰� ���� �����̱���\n" +
                        "���� ���� �־���� 300������ ����ֳ�!! ����ݵ� �����Ӱ� ������ ���ڵ� �ֳ�??\n" +
                        "�� �õ�ӴϷ� ��ϱ��� ��ƺ��°ž�\n" +
                        "����...? ���� ����Ͽ��� ���������� ���߿� �ٽ� ���߰ڴ°�");
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
                        "�̹��� �̰� ��������");

                    break;
                }
            case 5:
                {
                    // Active Default Screen
                    ChangeScreen(StockScreen);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "�̰� ���� �����̱���!\n" +
                        "10�� ���� �ü��� �̷��� �Ѵ��� ������!!\n" +
                        "�̰� �� ���� ���� �������� ���ؾ߰ھ�!!");

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
                        "�̰� ȯ�漳���̾�!");

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
                        "�̰� ���� �ֽ����� �� �� �ϱ����̳�");

                    break;
                }
            case 9:
                {
                    // Enable App Highlight
                    ChangeScreen(DefaultScreen);

                    // Print Panel
                    talkPanel.GetComponent<MainDialog>().ShowDialog("/username/\n\n" +
                        "��!!! ��� �غ�� �Ϻ��ϴ�!! �� �ڽ��־�!!\n" +
                        "ȭ�� �����ϱ��~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

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
            if (!appHighlighted && isTutorial)
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
        Vector3 Hpos = new Vector3(pos.x, pos.y, 1.0f);
        AppHighlight.transform.position = Hpos;
        AppHighlight.transform.localScale = scale;  
        AppHighlight.SetActive(true);
        appHighlighted = true;
    }

    public void OnClickAppHighlight() 
    {
        flag++; 
        appHighlighted = false; 
        AppHighlight.SetActive(false); 
    }
    
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
                talkPanel.GetComponent<MainDialog>().ShowDialog("�Ƿε��� �и����� ü���Դϴ�. \n�ֽ���Ʈ�� �ʹ� �������� ������ �и��̰� ������մϴ�. \n�����ð��� ������ �Ƿε��� ���� �ٰԵǰ� �Ƿε��� �� �Ҹ��ϸ� �Ϸ絿���� ������ �ǵ��� ���� �������� �Ѿ�ϴ�");
            }
            else if (flag == 2)
            {
                healthObject.GetComponent<SpriteRenderer>().sprite = healthNormal;
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : �ѹ� �����̳� �غ���!! ���и�: �� ���õ��� ���� ??");
            }
            else if (flag == 3)
            {
                BankObject.GetComponent<Image>().sprite = BankMark;
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : �̰� ���� �����̱���! \n���и�: ���� ���� �־���� 300������ ����ֳ�!!����ݵ� �����Ӱ� ������ ���ڵ� �ֳ�?? \n���и� : ���� �־������ �ݹ� ���ڰ� �Ұھ�!!");
            }
            else if (flag == 4)
            {
                BankObject.GetComponent<Image>().sprite = BankNormal;
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : �̰� ���� �����̱���! \n���и�: 10�� ���� �ü��� �̷��� �Ѵ��� ������!! \n���и� : �̰� �� ���� ���� �������� ���ؾ߰ھ�!!");
            }
            else if (flag == 5)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : �̰� ȯ�漳���̾�! \n���и�: ���ǼҸ��� �ʹ� ũ�ų� â�� �ʹ� �۾Ƽ� �Ⱥ��̸� �����غ��߰ھ�!");
            }
            else if (flag == 6)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : �̰� ���� �ֽ����� �� �� �ϱ����̳�! \n���и�: ���Ҿ�!! ���ݺ��� ������ ��� ���ϸ��� ���ͱ���� ����� ��߰ھ�!");
            }
            else if (flag == 7)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : �̰� ���� �ϰ� �ִ� �˹� ����̳�! \n���и�: ���� �˹ٸ� �ϸ鼭 �� ���� ���⼭ �� �� �ְھ�!!");
            }
            else if (flag == 8)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : �̰� �޽��� �����̱���! \n���и�: �ֽ�����̳� �������κ��� ������ ���� �� �ְھ�! \n���и� : �˸��� �︮�� �ٷιٷ� üũ�غ��߰ڴ�!!");
            }
            else if (flag == 9)
            {
                talkPanel.GetComponent<MainDialog>().ShowDialog("���и� : ��!!! ����غ�� �Ϻ��ϴ�!! �� �ڽ��־�!! \n���и�: ȭ�� �����ϱ��~~~~~~~~~~~~~~~~~~~~!!!");
            }
            else if (flag == 10)
            {
                talkPanel.SetActive(false);
            }*/
