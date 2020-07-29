using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MockScene : MonoBehaviour
{
    [SerializeField]
    private Image cloud1, cloud2;

    [SerializeField]
    private GameObject cloudPlace1, cloudPlace2;

    private void Start()
    {
        SoundManager.instance.BgmApply(Bgm.Title);
    }
    public void SceneLoad()
    {
        SoundManager.instance.FadeOutBgm(1f);

        cloud1.transform.DOMove(cloudPlace1.transform.position, 1.5f);
        cloud1.transform.DOMove(cloudPlace1.transform.position, 1.5f).OnComplete(() =>
        {

            SceneManager.LoadScene("ru-ruhebbsyuu");
        });
    }
}
