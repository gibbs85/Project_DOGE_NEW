using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_start : MonoBehaviour
{
    GameObject bgmObjStart;
    AudioSource bgmSourceStart;
    void Awake()
    {
        bgmObjStart = GameObject.Find("BGM_start");
        bgmSourceStart = bgmObjStart.GetComponent<AudioSource>();
        if (bgmSourceStart.isPlaying) return;
        else
        {
            bgmSourceStart.Play();
            DontDestroyOnLoad(bgmObjStart);
        }
    }
}
