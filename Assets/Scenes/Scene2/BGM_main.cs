using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_main : MonoBehaviour
{
    GameObject bgmObjMain;
    AudioSource bgmSourceMain;
    void Awake()
    {
        print("awake");
        if (GameObject.Find("BGM_start").GetComponent<AudioSource>().isPlaying)
        {
            print("isplaying");
            GameObject.Find("BGM_start").GetComponent<AudioSource>().Stop();
            Destroy(GameObject.Find("BGM_start"));
        }

        bgmObjMain = GameObject.Find("BGM_main");
        bgmSourceMain = bgmObjMain.GetComponent<AudioSource>();
        if (bgmSourceMain.isPlaying) return;
        else
        {
            bgmSourceMain.Play();
        }
    }
}
