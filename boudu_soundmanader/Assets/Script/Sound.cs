using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

   // public AudioClip SE1;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();//音を代入
        audioSource.Play();
    }

    void Update()
    {

    }

}
