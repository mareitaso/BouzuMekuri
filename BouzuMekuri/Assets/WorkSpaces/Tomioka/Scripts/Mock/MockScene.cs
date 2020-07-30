using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MockScene : MonoBehaviour
{
    [SerializeField]
    private Image cloudLU, cloudLD, cloudRU, cloudRD;

    [SerializeField]
    private GameObject cloudPlaceLU, cloudPlaceLD, cloudPlaceRU, cloudPlaceRD;

    private void Start()
    {
        SoundManager.instance.BgmApply(Bgm.Title);
    }
    public void SceneLoad()
    {
        SoundManager.instance.FadeOutBgm(1f);

        cloudLU.transform.DOMove(cloudPlaceLU.transform.position, 1.5f);
        cloudLD.transform.DOMove(cloudPlaceLD.transform.position, 1.5f);
        cloudRU.transform.DOMove(cloudPlaceRU.transform.position, 1.5f);
        cloudRD.transform.DOMove(cloudPlaceRD.transform.position, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene("ru-ruhebbsyuu");
            //SceneManager.LoadScene("Mock");
        });
    }
}
