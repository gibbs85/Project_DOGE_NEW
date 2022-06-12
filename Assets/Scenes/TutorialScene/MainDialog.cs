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
            GetComponent<TextMeshProUGUI>().text = "������ ����Ǵ� ����ȭ���Դϴ�.\n�и��̰� ��ȿ��� �ڵ����� �ϰ��ֳ׿�!\n�����ܰ� ���� �� ����� �޶�����~\n�ڵ��� ���õ��� ���� �����ܰ�, ���� �ü� Ȯ��, ȯ�� ����, �ֽ� ���� ���� �� ���� �������� Ȯ�� �� �� �ֽ��ϴ�!\n�߰��߰� ������ �̺�Ʈ�� �߻��� �� ������ ȭ���� �����ֽ����ּ���!";
             
        }
        else if (flag == 1)
        {
            GetComponent<TextMeshProUGUI>().text = "�Ƿε��� �и����� ü���Դϴ�. \n�ֽ���Ʈ�� �ʹ� �������� ������ �и��̰� ������մϴ�. \n�����ð��� ������ �Ƿε��� ���� �ٰԵǰ� �Ƿε��� �� �Ҹ��ϸ� �Ϸ絿���� ������ �ǵ��� ���� �������� �Ѿ�ϴ�";
        }
        else if (flag == 2)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �ѹ� �����̳� �غ���!! ���и�: �� ���õ��� ���� ??";
        }
        else if (flag == 3)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �̰� ���� �����̱���! \n���и�: ���� ���� �־���� 300������ ����ֳ�!!����ݵ� �����Ӱ� ������ ���ڵ� �ֳ�?? \n���и� : ���� �־������ �ݹ� ���ڰ� �Ұھ�!!";
        }
        else if (flag == 4)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �̰� ���� �����̱���! \n���и�: 10�� ���� �ü��� �̷��� �Ѵ��� ������!! \n���и� : �̰� �� ���� ���� �������� ���ؾ߰ھ�!!";
        }
        else if (flag == 5)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �̰� ȯ�漳���̾�! \n���и�: ���ǼҸ��� �ʹ� ũ�ų� â�� �ʹ� �۾Ƽ� �Ⱥ��̸� �����غ��߰ھ�!";
        }
        else if (flag == 6)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �̰� ���� �ֽ����� �� �� �ϱ����̳�! \n���и�: ���Ҿ�!! ���ݺ��� ������ ��� ���ϸ��� ���ͱ���� ����� ��߰ھ�!";
        }
        else if (flag == 7)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �̰� ���� �ϰ� �ִ� �˹� ����̳�! \n���и�: ���� �˹ٸ� �ϸ鼭 �� ���� ���⼭ �� �� �ְھ�!!";
        }
        else if (flag == 8)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �̰� �޽��� �����̱���! \n���и�: �ֽ�����̳� �������κ��� ������ ���� �� �ְھ�! \n���и� : �˸��� �︮�� �ٷιٷ� üũ�غ��߰ڴ�!!";
        }
        else if (flag == 9)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : ��!!! ����غ�� �Ϻ��ϴ�!! �� �ڽ��־�!! \n���и�: ȭ�� �����ϱ��~~~~~~~~~~~~~~~~~~~~!!!";
        }
        else if (money == 3000000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �̴�δ� �ȵ�... ������ ���...?";
        }
        else if (money == 4500000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �� �尡��~~~~";
        }
        else if (money == 6000000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : ��ؤФ� �� ���� ���ܰ���!! ���̾���~~";
        }
        else if (money == 9000000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : 900�����̶��..?? �� �����ִ°� �ƴϾ�?? 100������ �� ���� ��ϱ��̶��!!! ������!!";
        }
        else if (money == 10000000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : ����!!!�����̶��!! ��ϱ��� �� ������ �� �� �־�!! \n���и� : (����) �׳� �� �б� �����ϰ� �̰ɷ� �� �ҷ�����..???";
        }
        else if (money == 1500000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : ��....���ڱ� ������ ������ �ͳ�?";
        }
        else if (money == 1000000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : ���� ���̷��� ������..?? ��������?? �����ž� ��ġ?? ��Ƽ���..��������!";
        }
        else if (money == 500000)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : ������ ���� �ų�!! ���� ���� ���j�j������";
        }
        else if (money == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "���и� : �����. �������ΰ���? �ƴϾ�..����� �ⷷ�ٸ��� ����^^ \n���и� : �� �λ��� �׷��� ��..�ֽ��� ���� �մ뼭..�и��߳�..";
        }
        else if (dp == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "[System] " + dpMoney + "���� ���·� �ԱݵǾ����ϴ�";
        }
        else if (dp == 1)
        {
            GetComponent<TextMeshProUGUI>().text = "[System] " + dpMoney + "���� ���·κ��� ��ݵǾ����ϴ�";
        }
        else if (msg == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "�������κ��� �޽����� �����Ͽ����ϴ�";
        }
        else if (msg == 1)
        {
            GetComponent<TextMeshProUGUI>().text = "�ֽ���濡 ���ο� �޽����� �ö�Խ��ϴ�";
        }
        else if (diary = 1)
        {
            GetComponent<TextMeshProUGUI>().text = "�Ϸ������� ����Ǿ����ϴ�";
        }
        else if (event = 1)
        {
        GetComponent<TextMeshProUGUI>().text = "[EVENT]" + name + "�ֽ��� ���������Ͽ����ϴ�!!" + name + "�ֽ��� �������� ���������� �Ǿ����ϴ�!!!";
        }
        else
        {
        isAction = 0;
        }*/