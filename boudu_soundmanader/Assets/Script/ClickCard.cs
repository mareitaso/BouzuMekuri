using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCard : MonoBehaviour
{

    private AudioSource sound01;
    private AudioSource sound02;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();//音を代入
        sound01 = audioSources[0];
        //sound02 = audioSources[1];
    }

    public void OnClick()
    {
        sound01.PlayOneShot(sound01.clip);// クリックしたら音が鳴る
    }
    //public void OnClick2()
    //{
    //    sound02.PlayOneShot(sound02.clip);
    //}
}
