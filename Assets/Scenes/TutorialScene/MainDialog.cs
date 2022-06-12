using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void ShowDialog(string text)
    {
        gameObject.SetActive(true);

        transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = text.Replace("/username/", Player.player.UserName);

        //TextMeshProUGUI t = gameObject.GetComponent<TextMeshProUGUI>();
        //t.text = t.text.Replace("/username/", UserInfo.user.UserName);
    }
}

/*if (flag == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "게임이 진행되는 메인화면입니다.\n패망이가 방안에서 핸드폰을 하고있네요!\n통장잔고에 따라 방 모습이 달라져요~\n핸드폰 어플들을 통해 통장잔고, 종목 시세 확인, 환경 설정, 주식 정보 습득 등 많은 정보들을 확인 할 수 있습니다!\n중간중간 랜덤한 이벤트가 발생할 수 있으니 화면을 예의주시해주세요!";
             
        }
        else if (flag == 1)
        {
            GetComponent<TextMeshProUGUI>().text = "피로도는 패망이의 체력입니다. \n주식차트를 너무 오래보고 있으면 패망이가 힘들어합니다. \n일정시간이 지나면 피로도가 점점 줄게되고 피로도를 다 소모하면 하루동안의 수익을 되돌아 보며 다음날로 넘어갑니다";
        }
        else if (flag == 2)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 한번 연습이나 해보자!! 김패망: 이 어플들은 뭐지 ??";
        }
        else if (flag == 3)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 이건 은행 어플이구나! \n김패망: 지금 내가 넣어놓은 300만원이 들어있네!!입출금도 자유롭고 심지어 이자도 있네?? \n김패망 : 많이 넣어놓으면 금방 이자가 불겠어!!";
        }
        else if (flag == 4)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 이건 증권 어플이구나! \n김패망: 10개 종목 시세가 이렇게 한눈에 나오네!! \n김패망 : 이걸 잘 보고 어디다 투자할지 정해야겠어!!";
        }
        else if (flag == 5)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 이건 환경설정이야! \n김패망: 음악소리가 너무 크거나 창이 너무 작아서 안보이면 조절해봐야겠어!";
        }
        else if (flag == 6)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 이건 내가 주식으로 돈 번 일기장이네! \n김패망: 좋았어!! 지금부터 열심히 벌어서 매일매일 수익기록을 여기다 써야겠어!";
        }
        else if (flag == 7)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 이건 내가 하고 있는 알바 목록이네! \n김패망: 내가 알바를 하면서 번 돈을 여기서 볼 수 있겠어!!";
        }
        else if (flag == 8)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 이건 메신저 어플이구나! \n김패망: 주식톡방이나 지인으로부터 정보를 얻을 수 있겠어! \n김패망 : 알림이 울리면 바로바로 체크해봐야겠다!!";
        }
        else if (flag == 9)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 자!!! 모든준비는 완벽하다!! 난 자신있어!! \n김패망: 화성 갈끄니까아~~~~~~~~~~~~~~~~~~~~!!!";
        }
        else if (money == 3000000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 이대로는 안되... 뭐부터 살까...?";
        }
        else if (money == 4500000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 자 드가자~~~~";
        }
        else if (money == 6000000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 어떡해ㅠㅠ 나 이제 부잔가봐!! 아이씐나~~";
        }
        else if (money == 9000000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 900만원이라고..?? 나 소질있는거 아니야?? 100만원만 더 벌면 등록금이라고!!! 가보자!!";
        }
        else if (money == 10000000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 성공!!!성공이라고!! 등록금을 내 돈으로 낼 수 있어!! \n김패망 : (씨익) 그냥 한 학기 휴학하고 이걸로 더 불려볼까..???";
        }
        else if (money == 1500000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 음....갑자기 손톱이 물어뜯고 싶네?";
        }
        else if (money == 1000000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 발이 왜이렇게 떨리지..?? 오르겠지?? 오를거야 그치?? 버티면되..존버하자!";
        }
        else if (money == 500000)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 히히히 아이 신나!! 헤헤 히히 흐헼헼ㅋㅋㅋ";
        }
        else if (money == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "김패망 : 어디보자. 섬강으로갈까? 아니야..가까운 출렁다리로 가자^^ \n김패망 : 내 인생이 그렇지 뭐..주식은 괜히 손대서..패망했네..";
        }
        else if (dp == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "[System] " + dpMoney + "원이 계좌로 입금되었습니다";
        }
        else if (dp == 1)
        {
            GetComponent<TextMeshProUGUI>().text = "[System] " + dpMoney + "원이 계좌로부터 출금되었습니다";
        }
        else if (msg == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "지인으로부터 메시지가 도착하였습니다";
        }
        else if (msg == 1)
        {
            GetComponent<TextMeshProUGUI>().text = "주식톡방에 새로운 메시지가 올라왔습니다";
        }
        else if (diary = 1)
        {
            GetComponent<TextMeshProUGUI>().text = "하루일지가 저장되었습니다";
        }
        else if (event = 1)
        {
        GetComponent<TextMeshProUGUI>().text = "[EVENT]" + name + "주식이 상장폐지하였습니다!!" + name + "주식의 보유액이 휴지조각이 되었습니다!!!";
        }
        else
        {
        isAction = 0;
        }*/