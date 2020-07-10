using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManader : MonoBehaviour
{
    public enum sounds
    {
        BGM0,//タイトル
        BGM1,//編集
        BGM2,//ゲーム画面
        BGM3,//リザルト

        SE0,//試合開始
        SE1,//シャッフル
        SE2,//手札に加える
        SE3,//手札を捨てる
        SE4,//スキル発動
        SE5,//試合終了
        SE6//決定
    }

    [SerializeField]
    private List<AudioClip> BGM;

    [SerializeField]
    private List<AudioClip> SE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

    }
}
