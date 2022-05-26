using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Image : MonoBehaviour
{
    public GameObject BackGround;

    public Sprite level1;
    public Sprite level2;
    public Sprite level3;

    // Start is called before the first frame update
    public void Start()
    {
        print("started");
        int money = GameObject.Find("Player").GetComponent<Player>().GetMoney();

        if (money >= 0 && money < 100)
            BackGround.GetComponent<Image>().sprite = level1;
        else if (money >= 100 && money < 200)
            BackGround.GetComponent<Image>().sprite = level2;
        else
            BackGround.GetComponent<Image>().sprite = level3;

    }
}
