using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSE : MonoBehaviour
{
    //public AudioClip SE;
    //public AudioSource audioSource;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    audioSource = gameObject.GetComponent<AudioSource>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F6))
    //    {
    //        audioSource.volume += (float)0.1;
    //    }
    //    //ボリュームダウン
    //    if (Input.GetKeyDown(KeyCode.F5))
    //    {
    //        audioSource.volume -= (float)0.1;
    //    }
    //}

    //ボタンを押したらSEが流れる
    public void OnClick()
    {
        //audioSource.Play();
        SoundManager.instance.SeApply(Se.choice);
        Debug.Log("有効");
    }

}
