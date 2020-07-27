using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bgm
{
    Title,//タイトル
    Main,//編集
    BGM2//ゲーム画面
}

public enum Se
{
    cardOpen
    //SE0,//試合開始
    //SE1,//シャッフル 
    //SE2,//手札に加える
    //SE3,//手札を捨てる 
    //SE4,//スキル発動
    //SE5,//試合終了
    //SE6,//タイトルのはじめボタン
    //SE7//決定 タイトル以外
}

[System.Serializable]
public class Sound
{
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float audioSize;
}

[DefaultExecutionOrder(-1)]
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    public Sound[] bgmsounds;
    public Sound[] sesounds;

    public Dictionary<Bgm, Sound> bgmDIctionary = new Dictionary<Bgm, Sound>();
    public Dictionary<Se, Sound> seDictionary = new Dictionary<Se, Sound>();

    [SerializeField]
    private AudioSource bgmAudioSource;

    [SerializeField]
    private AudioSource seAudioSource;

    //public bool IsFade;
    //public double FadeOutSeconds = 1.0;//フェードアウトにかかる時間（Unity内で変更可）
    //bool IsFadeOut = true;
    //double FadeDeltaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        for (int i = 0; i < bgmsounds.Length; i++)
        {
            bgmDIctionary.Add((Bgm)i, bgmsounds[i]);
        }
        for (int i = 0; i < sesounds.Length; i++)
        {
            seDictionary.Add((Se)i, sesounds[i]);
        }

    }

    public void BgmApply(Bgm key)
    {
        Sound sound = bgmDIctionary[key];
        AudioClip audio = sound.audioClip;
        bgmAudioSource.volume = sound.audioSize;
        bgmAudioSource.clip = audio;
        bgmAudioSource.Play();
    }

    public void SeApply(Se key)
    {
        Sound sound = seDictionary[key];
        AudioClip audio = sound.audioClip;
        seAudioSource.volume = sound.audioSize;
        seAudioSource.clip = audio;
        seAudioSource.PlayOneShot(audio);
    }

    //public void FadeOut()
    //{

    //    FadeDeltaTime += Time.deltaTime;
    //    if (FadeDeltaTime >= FadeOutSeconds)
    //    {
    //        FadeDeltaTime = FadeOutSeconds;
    //        IsFadeOut = false;
    //    }
    //    bgmAudioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds);

    //}

    public void FadeOutBgm(float fadeTime)
    {
        StartCoroutine(FadeOut(fadeTime));
    }

    public void FadeOutSE(float fadeTime)
    {
        StartCoroutine(SEFadeOut(fadeTime));
    }

    private IEnumerator FadeOut(float time)
    {
        float _time = time;
        float vol = bgmAudioSource.volume;
        while (_time > 0f)
        {
            _time -= Time.deltaTime;
            bgmAudioSource.volume = vol * _time / time;
            yield return null;
        }
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
        yield break;
    }

    private IEnumerator SEFadeOut(float time)
    {
        float _time = time;
        float vol = seAudioSource.volume;
        while (_time > 0f)
        {
            _time -= Time.deltaTime;
            seAudioSource.volume = vol * _time / time;
            yield return null;
        }
        seAudioSource.Stop();
        seAudioSource.clip = null;
        yield break;
    }
}
