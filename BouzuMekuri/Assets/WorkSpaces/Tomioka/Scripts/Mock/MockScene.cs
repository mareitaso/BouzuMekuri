using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MockScene : MonoBehaviour
{
    private void Start()
    {
        //SoundManager.instance.BgmApply(Bgm.B);
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene("Mock");
        //SoundManager.instance.FadeOutBgm(1f);
    }
}
