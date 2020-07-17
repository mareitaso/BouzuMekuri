using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    [SerializeField]
    private Image YamahudaFake;

    [SerializeField]
    private GameObject[] Place;

    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Test test;

    private Vector2 YamahudaVec2;

    private void Start()
    {
        YamahudaVec2 = YamahudaFake.transform.position;
    }

    public void AnimeYamaToPlayer()
    {
        YamahudaFake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
        {
            //引いたカードのspriteにする
            YamahudaFake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard + 1);
            YamahudaFake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
            {
                //DoToweenで移動
                YamahudaFake.transform.DOMove(Place[deck.Count].transform.position, 1).OnComplete(() =>
                {
                    //コールバックで移動後の処理
                    test.Player[deck.Count].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard + 1);
                    //偽山札を作り移動アニメーションを見せる
                    YamahudaFake.sprite = Resources.Load<Sprite>("Images/CardBack");
                    //アニメーション後元の場所に戻す
                    YamahudaFake.transform.position = YamahudaVec2;
                });
            });
        });
    }
}
