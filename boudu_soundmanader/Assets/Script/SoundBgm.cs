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
        //右クリックを受け付ける
        if (Input.GetMouseButtonDown(1))
        {
            audioSource.Stop();
            Debug.Log("止まれー");
            
        }
        //スペースで再生
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            Debug.Log("再生せよ！");
        }

    }
}
