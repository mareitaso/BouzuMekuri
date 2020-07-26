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

    //全プレイヤーの手札を回収するアニメーション
    public void AnimeHandCardGet()
    {

        movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    for (int i = 0; i < 4; i++)
                    {
                        playerFake[i].sprite = player[i].sprite;
                        player[i].sprite = Resources.Load<Sprite>("Images/Null");
                    }
                    playerFake[0].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    playerFake[1].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    playerFake[2].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    playerFake[3].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama1Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                        //元の位置に戻す

                        for (int i = 0; i < 4; i++)
                        {
                            if (i != movePlace)
                            {
                                playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                                playerFake[i].transform.position = player[i].transform.position;
                            }
                            else
                            {
                                playerFake[i].transform.position = player[i].transform.position;
                            }
                        }

                    });
                });
            });
        }
        else
        //山札2から各プレイヤーに移動
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    for (int i = 0; i < 4; i++)
                    {
                        playerFake[i].sprite = player[i].sprite;
                        player[i].sprite = Resources.Load<Sprite>("Images/Null");
                    }
                    playerFake[0].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    playerFake[1].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    playerFake[2].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    playerFake[3].transform.DOMove(Place[movePlace].transform.position, animeTime);
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                        //元の位置に戻す
                        for (int i = 0; i < 4; i++)
                        {
                            if (i != movePlace)
                            {
                                playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                                playerFake[i].transform.position = player[i].transform.position;
                            }
                            else
                            {
                                playerFake[i].transform.position = player[i].transform.position;
                            }
                        }
                    });
                });
            });
        }
    }

    //プレイヤー1人にN枚カードを移動する
    public void AnimeCardNMove()
    {
        movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    for (int i = 0; i < 4; i++)
                    {
                        playerFake[i].sprite = player[i].sprite;
                        if (MasterList.Instance.list[i].Count == 0)
                        {
                            player[i].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        else
                        {
                            player[i].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[i][MasterList.Instance.list[i].Count - 1]);
                        }
                        playerFake[i].transform.DOMove(Place[movePlace].transform.position, animeTime);

                    }
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama1Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;

                        //元の位置に戻す
                        for (int i = 0; i < 4; i++)
                        {
                            playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                            playerFake[i].transform.position = player[i].transform.position;
                        }

                    });
                });
            });
        }
        else
        //山札2から各プレイヤーに移動
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    for (int i = 0; i < 4; i++)
                    {
                        playerFake[i].sprite = player[i].sprite;
                        if (MasterList.Instance.list[i].Count == 0)
                        {
                            player[i].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        else
                        {
                            playerFake[i].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[i][MasterList.Instance.list[i].Count - 1]);
                        }
                        playerFake[i].transform.DOMove(Place[movePlace].transform.position, animeTime);

                    }
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                        //元の位置に戻す
                        for (int i = 0; i < 4; i++)
                        {
                            playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                            playerFake[i].transform.position = player[i].transform.position;
                        }
                    });
                });
            });
        }
    }

    //全プレイヤーの手札と捨て札を回収するアニメーション
    public void AnimeAllGet()
    {
        {
            movePlace = deck.Count;

            //山札1から各プレイヤーに移動
            if (test.drowYama1 == true)
            {
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
                {
                    //引いたカードのspriteにする
                    Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                    Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                    {
                        //DoToweenで移動
                        for (int i = 0; i < 4; i++)
                        {
                            playerFake[i].sprite = player[i].sprite;
                            player[i].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        SutehudaFake.sprite = Sutehuda.sprite;
                        SutehudaFake.sprite = Sutehuda.sprite;
                        Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");
                        playerFake[0].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        playerFake[1].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        playerFake[2].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        playerFake[3].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        SutehudaFake.transform.DOMove(Place[movePlace].transform.position, animeTime);
                        Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                        {
                            //コールバックで移動後の処理
                            player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                            //偽山札を作り移動アニメーションを見せる
                            Yama1Null();
                            //アニメーション後元の場所に戻す
                            Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                            //元の位置に戻す
                            for (int i = 0; i < 4; i++)
                            {
                                playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                                playerFake[i].transform.position = player[i].transform.position;
                            }
                            SutehudaFake.sprite = Resources.Load<Sprite>("Images/Null");
                            SutehudaFake.transform.position = Sutehuda.transform.position;
                        });
                    });
                });
            }
            else
            //山札2から各プレイヤーに移動
            {
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
                {
                    //引いたカードのspriteにする
                    Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                    Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                    {
                        //DoToweenで移動
                        for (int i = 0; i < 4; i++)
                        {
                            playerFake[i].sprite = player[i].sprite;
                            player[i].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        SutehudaFake.sprite = Sutehuda.sprite;
                        Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");
                        playerFake[0].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        playerFake[1].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        playerFake[2].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        playerFake[3].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        SutehudaFake.transform.DOMove(Place[movePlace].transform.position, animeTime);
                        Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                        {
                            //コールバックで移動後の処理
                            player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                            //偽山札を作り移動アニメーションを見せる
                            Yama2Null();
                            //アニメーション後元の場所に戻す
                            Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                            //元の位置に戻す
                            for (int i = 0; i < 4; i++)
                            {
                                playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                                playerFake[i].transform.position = player[i].transform.position;
                            }
                            SutehudaFake.sprite = Resources.Load<Sprite>("Images/Null");
                            SutehudaFake.transform.position = Sutehuda.transform.position;
                        });
                    });
                });
            }
        }
    }

    //蝉丸の山札半分捨てる処理
    public void AnimeYamaHalf()
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
                        AnimeYamaHalfReady();
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
                        AnimeYamaHalfReady();
                    });
                });
            });
        }
    }

    //蝉丸の山札半分捨てる処理
    private void AnimeYamaHalfReady()
    {
        if (deck.cards1.Count > 1)
        {
            movePlace = deck.Count;

            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.cards1[0]);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda1Fake.transform.DOMove(Sutehuda.transform.position, 1f).OnComplete(() =>
                    {
                        Sutehuda.sprite = Yamahuda1Fake.sprite;
                        Yama1Null();
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                    });
                });
            });
        }
        if (deck.cards2.Count > 1)
        {
            movePlace = deck.Count;

            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
            {
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.cards2[0]);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Sutehuda.transform.position, 1f).OnComplete(() =>
                    {
                        Sutehuda.sprite = Yamahuda2Fake.sprite;
                        Yama2Null();
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                    });
                });
            });
        }
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

    //プレイヤーの手札シャッフルする処理
    public void PlayerAllShuffle()
    {
        playerFake[0].sprite = player[0].sprite;
        playerFake[1].sprite = player[1].sprite;
        playerFake[2].sprite = player[2].sprite;
        playerFake[3].sprite = player[3].sprite;
        player[0].sprite = Resources.Load<Sprite>("Images/Null");
        player[1].sprite = Resources.Load<Sprite>("Images/Null");
        player[2].sprite = Resources.Load<Sprite>("Images/Null");
        player[3].sprite = Resources.Load<Sprite>("Images/Null");

        playerFake[0].transform.DOMove(new Vector2(0, 0), 1f);
        playerFake[1].transform.DOMove(new Vector2(0, 0), 1f);
        playerFake[2].transform.DOMove(new Vector2(0, 0), 1f);
        playerFake[3].transform.DOMove(new Vector2(0, 0), 1f).OnComplete(() =>
        {
            playerFake[0].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[0][MasterList.Instance.list[0].Count - 1]);
            playerFake[1].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[1][MasterList.Instance.list[1].Count - 1]);
            playerFake[2].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[2][MasterList.Instance.list[2].Count - 1]);
            playerFake[3].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[3][MasterList.Instance.list[3].Count - 1]);
            playerFake[0].transform.DOMove(Place[0].transform.position, 1f);
            playerFake[1].transform.DOMove(Place[1].transform.position, 1f);
            playerFake[2].transform.DOMove(Place[2].transform.position, 1f);
            playerFake[3].transform.DOMove(Place[3].transform.position, 1f).OnComplete(() =>
            {
                player[0].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[0][MasterList.Instance.list[0].Count - 1]);
                player[1].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[1][MasterList.Instance.list[1].Count - 1]);
                player[2].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[2][MasterList.Instance.list[2].Count - 1]);
                player[3].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[3][MasterList.Instance.list[3].Count - 1]);

                playerFake[0].sprite = Resources.Load<Sprite>("Images/Null");
                playerFake[1].sprite = Resources.Load<Sprite>("Images/Null");
                playerFake[2].sprite = Resources.Load<Sprite>("Images/Null");
                playerFake[3].sprite = Resources.Load<Sprite>("Images/Null");
            });
        });
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
