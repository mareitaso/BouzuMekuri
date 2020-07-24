using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    [SerializeField]
    private Image Yamahuda1, Yamahuda2, Sutehuda;
    [SerializeField]
    private Image Yamahuda1Fake, Yamahuda2Fake, SutehudaFake;

    [SerializeField]
    private Image[] player;
    [SerializeField]
    private Image[] playerFake;

    [SerializeField]
    private GameObject[] Place;

    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Test test;

    private int movePlace;


    //山札からプレイヤーの手札に移動するアニメーション
    public void AnimeTono()
    {
        movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, 1f).OnComplete(() =>
                     {
                         //コールバックで移動後の処理
                         test.Player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                         //偽山札を作り移動アニメーションを見せる
                         Yama1Null();
                         //アニメーション後元の場所に戻す
                         Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                     });
                });
            });
        }
        //山札2から各プレイヤーに移動
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, 1f).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        test.Player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                    });
                });
            });
        }
    }

    //捨て札に全部移動するアニメーション
    public void AnimeBouzu()
    {
        movePlace = deck.Count;

        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで捨て札に移動
                    Yamahuda1Fake.transform.DOMove(SutehudaFake.transform.position, 1).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        SutehudaFake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama1Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                        //移動後移動してきたカードの画像に変更
                        Sutehuda.sprite = SutehudaFake.sprite;
                    });

                    playerFake[movePlace].sprite = player[movePlace].sprite;
                    //枚数によってはNullか持ってる1番上のカードにする
                    player[movePlace].sprite = Resources.Load<Sprite>("Images/Null");

                    playerFake[movePlace].transform.DOMove(Sutehuda.transform.position, 0.8f).OnComplete(() =>
                    {
                        playerFake[movePlace].transform.position = Place[movePlace].transform.position;
                        playerFake[movePlace].sprite = Resources.Load<Sprite>("Images/Null");

                    });
                });
            });
        }
        //山札2から各プレイヤーに移動
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで捨て札に移動
                    Yamahuda2Fake.transform.DOMove(SutehudaFake.transform.position, 1).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        SutehudaFake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                        //移動後移動してきたカードの画像に変更
                        Sutehuda.sprite = SutehudaFake.sprite;
                    });

                    playerFake[movePlace].sprite = player[movePlace].sprite;

                    //枚数によってはNullか持ってる1番上のカードにする
                    player[movePlace].sprite = Resources.Load<Sprite>("Images/Null");

                    playerFake[movePlace].transform.DOMove(SutehudaFake.transform.position, 1).OnComplete(() =>
                    {
                        playerFake[movePlace].transform.position = Place[movePlace].transform.position;
                        playerFake[movePlace].sprite = Resources.Load<Sprite>("Images/Null");

                    });

                });
            });
        }
    }

    //捨て札を全部回収するアニメーション
    public void AnimeHime()
    {
        movePlace = deck.Count;

        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, 1f).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        test.Player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama1Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                    });

                    //捨て札から回収のアニメーション
                    SutehudaFake.sprite = Sutehuda.sprite;
                    Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");

                    SutehudaFake.transform.DOMove(Place[movePlace].transform.position, 1f).OnComplete(() =>
                    {
                        SutehudaFake.transform.position = Sutehuda.transform.position;
                        SutehudaFake.sprite = Resources.Load<Sprite>("Images/Null");
                    });

                });
            });
        }
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, 1f).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        test.Player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                    });

                    //捨て札から回収のアニメーション
                    SutehudaFake.sprite = Sutehuda.sprite;
                    Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");

                    SutehudaFake.transform.DOMove(Place[movePlace].transform.position, 1f).OnComplete(() =>
                    {
                        SutehudaFake.transform.position = Sutehuda.transform.position;
                        SutehudaFake.sprite = Resources.Load<Sprite>("Images/Null");
                    });
                });
            });
        }
    }

    //蝉丸の山札半分捨てる処理
    public void AnimeYamaHalf()
    {
    
    }

    //偽山札を作り移動アニメーションを見せる用関数
    private void Yama1Null()
    {
        if (deck.cards1.Count == 0)
        {
            Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/Null");
        }
        else
        {
            Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/CardBack");
        }
    }


    //偽山札を作り移動アニメーションを見せる用関数
    private void Yama2Null()
    {
        if (deck.cards2.Count == 0)
        {
            Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/Null");
        }
        else
        {
            Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/CardBack");
        }
    }

    /*雛形
    public void Anime()
    {
        movePlace = deck.Count;

        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {

            });
        }
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {

            });
        }
    }
    */
}
