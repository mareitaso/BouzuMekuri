using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MikujiEffect : MonoBehaviour
{
    [SerializeField]
    private Draw draw;

    [SerializeField]
    private GameObject MikujiBox;

    [SerializeField]
    private Image KujiBefore, KujiAfter;

    [SerializeField]
    private GameObject mikujiPlace;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Text fieldEffectText;

    private bool animeEnd = false;

    private void Start()
    {
        FieldEffectDecide();
        animeEnd = false;
        KujiBefore.sprite = Resources.Load<Sprite>("Images/Null");
        Invoke("BoxTap", 2.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && animeEnd == true)
        {
            PanelOff();
        }
    }


    private void BoxTap()
    {
        float z = 5f;

        MikujiBox.transform.DORotate(new Vector3(0, 0, z), 0.2f).OnComplete(() =>
        {
            MikujiBox.transform.DORotate(new Vector3(0, 0, -z), 0.2f).OnComplete(() =>
            {
                MikujiBox.transform.DORotate(new Vector3(0, 0, z), 0.2f).OnComplete(() =>
                {
                    MikujiBox.transform.DORotate(new Vector3(0, 0, -z), 0.2f).OnComplete(() =>
                    {
                        MikujiBox.transform.DORotate(new Vector3(0, 0, 0), 0.2f).OnComplete(() =>
                        {
                            MikujiMove();
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
            animeEnd = true;
        });
    }

    private void PanelOff()
    {
        panel.SetActive(false);
    }

    private void FieldEffectDecide()
    {
        int i = Random.Range(1, 4);
        draw.fieldEffectNum = i;

        switch (i)
        {
            case 1:
                fieldEffectText.text = "今回のフィールドスキルは\n引く枚数が+1される";
                break;

            case 2:
                fieldEffectText.text = "今回のフィールドスキルは\n20枚引くごとに手札シャッフル";
                break;

            case 3:
                fieldEffectText.text = "今回のフィールドスキルは\nプレイヤーが4回ひいたら\n山札から捨て場に３枚置く";
                break;

            default:
                fieldEffectText.text = "今回のフィールドスキルは\nエラーになりました";
                Debug.LogError("フィールド効果がおかしい");
                break;
        }

    }
}

