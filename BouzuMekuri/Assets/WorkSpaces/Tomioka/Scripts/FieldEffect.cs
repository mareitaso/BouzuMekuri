using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FieldEffect : MonoBehaviour
{
    [SerializeField]
    private Image MikujiBox;

    [SerializeField]
    private Image KujiBefore, KujiAfter;

    [SerializeField]
    private GameObject shakePlace1, shakePlace2, shakePlace3, shakePlace4, mikujiPlace;

    [SerializeField]
    private GameObject panel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BoxTap();
        }
    }

    private void Start()
    {
        KujiBefore.sprite = Resources.Load<Sprite>("Images/Null");
        Invoke("BoxTap", 2.5f); 
    }

    private void BoxTap()
    {
        MikujiBox.transform.DOMove(shakePlace1.transform.position, 0.5f).OnComplete(() =>
        {
            MikujiBox.transform.DOMove(shakePlace2.transform.position, 0.5f).OnComplete(() =>
            {
                MikujiBox.transform.DOMove(shakePlace3.transform.position, 0.5f).OnComplete(() =>
                {
                    MikujiBox.transform.DOMove(shakePlace4.transform.position, 0.5f).OnComplete(() =>
                    {
                        MikujiBox.transform.DOMove(new Vector2(0, 0), 0.5f).OnComplete(() =>
                        {
                            MikujiBox.transform.DORotate(new Vector3(0, 0, 180), 0.5f).OnComplete(() =>
                            {
                                MikujiMove();
                            });
                        });
                    });
                });
            });
        });
    }

    private void MikujiMove()
    {
        KujiBefore.sprite = Resources.Load<Sprite>("Images/MikujiBefore");
        KujiBefore.transform.DOMove(mikujiPlace.transform.position, 1.2f).OnComplete(() =>
        {
            KujiAfter.transform.DOMove(new Vector2(0, 0), 0.5f);
            Invoke("PanelOff", 2.5f);
        });
    }

    private void PanelOff()
    {
        panel.SetActive(false);
    }
}
