using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManader : MonoBehaviour
{
    public AudioSource audioSource;
    public enum Sounds
    {
        BGM1, //タイトル画面    
        BGM2, //編集画面        
        BGM3, //ゲーム画面      
        BGM4, //リザルト画面    
        SE1,  //ゲーム開始      
        SE2,  //シャッフルする  
        SE3,  //カードを加える  
        SE4,  //カードを捨てる  
        SE5,  //スキル発動      
        SE6,  //ゲーム終了  
        SE7   //決定

    };

    public List<Sounds> bgmList = new List<Sounds>();
    public List<Sounds> seList = new List<Sounds>();

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }
}
