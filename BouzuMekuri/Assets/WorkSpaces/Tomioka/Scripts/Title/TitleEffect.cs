using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleEffect : MonoBehaviour
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
        SoundManager.instance.SeApply(Se.start);

        cloudLU.transform.DOMove(cloudPlaceLU.transform.position, 1.5f);
        cloudLD.transform.DOMove(cloudPlaceLD.transform.position, 1.5f);
        cloudRU.transform.DOMove(cloudPlaceRU.transform.position, 1.5f);
        cloudRD.transform.DOMove(cloudPlaceRD.transform.position, 1.5f).OnComplete(() =>
        {
            SceneController.instance.LoadScene(SceneController.SceneName.Rule);
        });
    }
}
