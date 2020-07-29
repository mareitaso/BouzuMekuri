using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MockScene : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.BgmApply(Bgm.Title);
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene("ru-ruhebbsyuu");
        //SoundManager.instance.FadeOutBgm(0.5f);
    }
}
