using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioClip SE1;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();//音を代入
    }

    void Update()
    {
       
        //左クリックを受け付ける
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(SE1);
            Debug.Log("鳴ったー");
        }
        

    }

}
