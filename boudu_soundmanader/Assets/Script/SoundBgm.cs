using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBgm : MonoBehaviour
{
    public AudioClip BGM;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//音を代入
    }

    // Update is called once per frame
    void Update()
    {
        //右クリックで停止
        if (Input.GetMouseButtonDown(1))
        {
            audioSource.Stop();
            Debug.Log("止まれー");
        }
        //一時停止 & 途中から再生
        if(Input.GetKeyDown(KeyCode.S))
        {
            audioSource.mute = !audioSource.mute;
        }
        //スペースで再生
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            Debug.Log("再生せよ！");
        }
        //ボリュームアップ
        if(Input.GetKeyDown(KeyCode.F6))
        {
            audioSource.volume += (float)0.1;
        }
        //ボリュームダウン
        if (Input.GetKeyDown(KeyCode.F5))
        {
            audioSource.volume -= (float)0.1;
        }

    }
}
