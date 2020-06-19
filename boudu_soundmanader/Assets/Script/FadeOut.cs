using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public AudioSource audioSource;
    
    public bool IsFade;
    public double FadeOutSeconds = 1.0;//フェードアウトにかかる時間（Unity内で変更可）
    bool IsFadeOut = true;
    double FadeDeltaTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            Debug.Log("フェードアウト開始");
            if (IsFadeOut)
            {
                FadeDeltaTime += Time.deltaTime;
                if (FadeDeltaTime >= FadeOutSeconds)
                {
                    FadeDeltaTime = FadeOutSeconds;
                    IsFadeOut = false;
                }
                audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds);
            }
        }
    }
}
