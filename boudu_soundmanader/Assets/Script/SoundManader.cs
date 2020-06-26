using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManader : MonoBehaviour
{

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

    private List<Sounds> soundList = new List<Sounds>();

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { }

    public void Taitle()
    {
        
    }

}
