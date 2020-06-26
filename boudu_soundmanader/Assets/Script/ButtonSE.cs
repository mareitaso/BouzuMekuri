using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSE : MonoBehaviour
{
    public AudioClip SE;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { }

    //ボタンを押したらSEが流れる
    public void OnClick()
    {
        audioSource.Play();
        Debug.Log("有効");
    }
}
