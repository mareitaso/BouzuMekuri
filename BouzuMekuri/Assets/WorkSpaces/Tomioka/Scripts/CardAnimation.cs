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
    [SerializeField]
    private touvh touch;

    [SerializeField]
    private Image skillCutIn;
    [SerializeField]
    private Image skillCutInCard;


    [SerializeField]
    private GameObject CutInBefore, CutInAfter;

    [HideInInspector]
    public bool animeEnd = true;

    [HideInInspector]
    public int skillPlayer;
    [HideInInspector]
    public int animeFunctionNum;
    private int movePlace;

    private float animeTime = 0.6f;
    private float rotateTime = 0.3f;

    //山札からプレイヤーの手札に移動するアニメーション
    public void AnimeTono()
    {
        animeEnd = false;
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
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                     {
                         //コールバックで移動後の処理
                         player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                         //偽山札を作り移動アニメーションを見せる
                         Yama1Null();
                         //アニメーション後元の場所に戻す
                         Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                         animeEnd = true;
                     });
                });
            });
        }
        //山札2から各プレイヤーに移動
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                        animeEnd = true;
                    });
                });
            });
        }
    }

    //捨て札に全部移動するアニメーション
    public void AnimeBouzu()
    {
        animeEnd = false;
        movePlace = deck.Count;

        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで捨て札に移動
                    Yamahuda1Fake.transform.DOMove(SutehudaFake.transform.position, animeTime).OnComplete(() =>
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

                    playerFake[movePlace].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
                    {
                        playerFake[movePlace].transform.position = Place[movePlace].transform.position;
                        playerFake[movePlace].sprite = Resources.Load<Sprite>("Images/Null");
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/Null");
                        animeEnd = true;
                    });
                });
            });
        }
        //山札2から各プレイヤーに移動
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで捨て札に移動
                    Yamahuda2Fake.transform.DOMove(SutehudaFake.transform.position, animeTime).OnComplete(() =>
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

                    playerFake[movePlace].transform.DOMove(SutehudaFake.transform.position, animeTime).OnComplete(() =>
                    {
                        playerFake[movePlace].transform.position = Place[movePlace].transform.position;
                        playerFake[movePlace].sprite = Resources.Load<Sprite>("Images/Null");
                        animeEnd = true;
                    });

                });
            });
        }
    }

    //捨て札を全部回収するアニメーション
    public void AnimeHime()
    {
        animeEnd = false;
        movePlace = deck.Count;

        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama1Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                    });

                    //捨て札から回収のアニメーション
                    SutehudaFake.sprite = Sutehuda.sprite;
                    Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");

                    SutehudaFake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        SutehudaFake.transform.position = Sutehuda.transform.position;
                        SutehudaFake.sprite = Resources.Load<Sprite>("Images/Null");
                        animeEnd = true;
                    });

                });
            });
        }
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                    });

                    //捨て札から回収のアニメーション
                    SutehudaFake.sprite = Sutehuda.sprite;
                    Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");

                    SutehudaFake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        SutehudaFake.transform.position = Sutehuda.transform.position;
                        SutehudaFake.sprite = Resources.Load<Sprite>("Images/Null");
                        animeEnd = true;
                    });
                });
            });
        }
    }

    //もう一枚引くアニメーション
    public void AnimeOneDraw()
    {
        animeEnd = false;
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
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama1Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                        animeEnd = true;
                        test.Draw1();
                    });
                });
            });
        }
        //山札2から各プレイヤーに移動
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                        //偽山札を作り移動アニメーションを見せる
                        Yama2Null();
                        //アニメーション後元の場所に戻す
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                        animeEnd = true;
                        test.Draw2();
                    });
                });
            });
        }
    }

    //全プレイヤーの手札を回収するアニメーション
    public void AnimeHandCardGet()
    {
        animeEnd = false;
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
                        animeEnd = true;
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
                        animeEnd = true;
                    });
                });
            });
        }
    }

    //プレイヤー1人にN枚カードを移動する
    public void AnimeCardNMove()
    {
        animeEnd = false;
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
                        animeEnd = true;
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
                        animeEnd = true;
                    });
                });
            });
        }
    }

    //全プレイヤーの手札と捨て札を回収するアニメーション
    public void AnimeAllGet()
    {
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
                        animeEnd = true;
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
                        animeEnd = true;
                    });
                });
            });
        }

    }

    //左隣からカードをもらうアニメーション
    public void AnimeLeftToRight()
    {
        animeEnd = false;
        movePlace = deck.Count;
        int YumiNum = YumimotiDraw.instance.YumimotiNum;
        Debug.Log(YumiNum);
        Debug.Log("カードは" + (YumiNum + 1) + "P" + "→" + (deck.Count + 1) + "Pへ");

        //山札1から各プレイヤーに移動
        if (test.drowYama1 == true)
        {
            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    if (YumiNum != movePlace)
                    {
                        playerFake[YumiNum].sprite = player[YumiNum].sprite;
                        if (MasterList.Instance.list[YumiNum].Count == 0)
                        {
                            player[YumiNum].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        else
                        {
                            playerFake[YumiNum].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[YumiNum][MasterList.Instance.list[YumiNum].Count - 1]);
                        }
                        //DoToweenで移動
                        playerFake[YumiNum].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                        {
                            player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                            Yama1Null();
                            Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                            playerFake[YumiNum].sprite = Resources.Load<Sprite>("Images/Null");
                            playerFake[YumiNum].transform.DOMove(Place[YumiNum].transform.position, animeTime);
                            animeEnd = true;
                        });
                    }
                    else
                    {
                        Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                        {
                            player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                            Yama1Null();
                            Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                            animeEnd = true;
                        });
                    }
                });
            });
        }

        //山札2から各プレイヤーに移動
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    if (YumiNum != movePlace)
                    {
                        playerFake[YumiNum].sprite = player[YumiNum].sprite;
                        if (MasterList.Instance.list[YumiNum].Count == 0)
                        {
                            player[YumiNum].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        else
                        {
                            playerFake[YumiNum].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[YumiNum][MasterList.Instance.list[YumiNum].Count - 1]);
                        }
                        //DoToweenで移動
                        playerFake[YumiNum].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                        {
                            player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                            Yama2Null();
                            Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                            playerFake[YumiNum].sprite = Resources.Load<Sprite>("Images/Null");
                            playerFake[YumiNum].transform.DOMove(Place[YumiNum].transform.position, animeTime);
                            animeEnd = true;
                        });
                    }
                    else
                    {
                        Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                        {
                            player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                            Yama2Null();
                            Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                            animeEnd = true;
                        });
                    }
                });
            });
        }
    }

    //蝉丸の山札半分捨てる処理
    public void AnimeYamaHalf()
    {
        animeEnd = false;
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
                    Yamahuda1Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
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
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        //コールバックで移動後の処理
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
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

            Yamahuda1Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                Yamahuda1Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.cards1[0]);
                Yamahuda1Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda1Fake.transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
                    {
                        Sutehuda.sprite = Yamahuda1Fake.sprite;
                        Yama1Null();
                        Yamahuda1Fake.transform.position = Yamahuda1.transform.position;
                        animeEnd = true;
                    });
                });
            });
        }
        if (deck.cards2.Count > 1)
        {
            movePlace = deck.Count;

            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.cards2[0]);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    //DoToweenで移動
                    Yamahuda2Fake.transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
                    {
                        Sutehuda.sprite = Yamahuda2Fake.sprite;
                        Yama2Null();
                        Yamahuda2Fake.transform.position = Yamahuda2.transform.position;
                        animeEnd = true;
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

    //プレイヤーの手札の中身をシャッフルする処理
    public void AnimePlayerSkill1()
    {
        animeEnd = false;

        for (int i = 0; i < 4; i++)
        {
            playerFake[i].sprite = player[i].sprite;
            player[i].sprite = Resources.Load<Sprite>("Images/Null");
        }
        playerFake[0].transform.DOMove(new Vector2(0, 0), animeTime);
        playerFake[1].transform.DOMove(new Vector2(0, 0), animeTime);
        playerFake[2].transform.DOMove(new Vector2(0, 0), animeTime);
        playerFake[3].transform.DOMove(new Vector2(0, 0), animeTime).OnComplete(() =>
        {
            for (int i = 0; i < 4; i++)
            {
                if (MasterList.Instance.list[i].Count != 0)
                {
                    playerFake[i].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                    MasterList.Instance.list[i][MasterList.Instance.list[i].Count - 1]);
                }
                else
                {
                    playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                }
            }
            playerFake[0].transform.DOMove(Place[0].transform.position, animeTime);
            playerFake[1].transform.DOMove(Place[1].transform.position, animeTime);
            playerFake[2].transform.DOMove(Place[2].transform.position, animeTime);
            playerFake[3].transform.DOMove(Place[3].transform.position, animeTime).OnComplete(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    player[i].sprite = playerFake[i].sprite;
                    playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                }
                animeEnd = true;
            });
        });
    }


    //自分の手札を全部捨て場に置き、１位のプレイヤーの手札の半分を捨て場に置く
    public void AnimePlayerSkill2()
    {
        animeEnd = false;

        playerFake[touch.touchPlayer].sprite = player[touch.touchPlayer].sprite;
        //枚数によってはNullか持ってる1番上のカードにする

        player[touch.touchPlayer].sprite = Resources.Load<Sprite>("Images/Null");

        playerFake[touch.touchPlayer].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
        {
            playerFake[touch.touchPlayer].transform.position = Place[touch.touchPlayer].transform.position;
            Sutehuda.sprite = playerFake[touch.touchPlayer].sprite;
            playerFake[touch.touchPlayer].sprite = Resources.Load<Sprite>("Images/Null");
            player[touch.touchPlayer].sprite = Resources.Load<Sprite>("Images/Null");
            animeEnd = true;
        });


        playerFake[skillPlayer].sprite = player[skillPlayer].sprite;
        //枚数によってはNullか持ってる1番上のカードにする

        player[skillPlayer].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.Instance.list[skillPlayer][MasterList.Instance.list[skillPlayer].Count - 1]);

        playerFake[skillPlayer].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
        {
            playerFake[skillPlayer].transform.position = Place[skillPlayer].transform.position;
            playerFake[skillPlayer].sprite = Resources.Load<Sprite>("Images/Null");
            animeEnd = true;
        });

    }

    //全てのプレイヤーは最下位と同じ枚数になるように、捨て場にカードを置く
    public void AnimePlayerSkill3()
    {
        animeEnd = false;

        int i = skillPlayer + 1;
        if (MasterList.Instance.list[skillPlayer].Count != 0)
        {
            playerFake[i % 4].sprite = player[i % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[i % 4].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.Instance.list[i % 4][MasterList.Instance.list[i % 4].Count - 1]);

            playerFake[i % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[i % 4].transform.position = Place[i % 4].transform.position;
                Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[deck.DiscardCount.Count - 1]);
                playerFake[i % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
            });
        }
        else
        {
            playerFake[i % 4].sprite = player[i % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[i % 4].sprite = Resources.Load<Sprite>("Images/Null");

            playerFake[i % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
              {
                  playerFake[i % 4].transform.position = Place[i % 4].transform.position;
                  playerFake[i % 4].sprite = Resources.Load<Sprite>("Images/Null");
                  player[i % 4].sprite = Resources.Load<Sprite>("Images/Null");
                  animeEnd = true;
              });
        }
        int j = i + 1;
        if (MasterList.Instance.list[skillPlayer].Count != 0)
        {
            playerFake[j % 4].sprite = player[j % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[j % 4].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.Instance.list[j % 4][MasterList.Instance.list[j % 4].Count - 1]);

            playerFake[j % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[j % 4].transform.position = Place[j % 4].transform.position;
                Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[deck.DiscardCount.Count - 1]);
                playerFake[j % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
            });
        }
        else
        {
            playerFake[j % 4].sprite = player[j % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[j % 4].sprite = Resources.Load<Sprite>("Images/Null");

            playerFake[j % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[j % 4].transform.position = Place[j % 4].transform.position;
                playerFake[j % 4].sprite = Resources.Load<Sprite>("Images/Null");
                player[j % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
            });
        }

        int k = j + 1;
        if (MasterList.Instance.list[skillPlayer].Count != 0)
        {
            playerFake[k % 4].sprite = player[k % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[k % 4].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.Instance.list[k % 4][MasterList.Instance.list[k % 4].Count - 1]);

            playerFake[k % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[k % 4].transform.position = Place[k % 4].transform.position;
                Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[deck.DiscardCount.Count - 1]);
                playerFake[k % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
            });
        }
        else
        {
            playerFake[k % 4].sprite = player[k % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[k % 4].sprite = Resources.Load<Sprite>("Images/Null");

            playerFake[k % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[k % 4].transform.position = Place[k % 4].transform.position;
                playerFake[k % 4].sprite = Resources.Load<Sprite>("Images/Null");
                player[k % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
            });
        }
    }

    public void AnimeSkillCutIn()
    {
        animeEnd = false;
        movePlace = deck.Count;
        SoundManager.instance.SeApply(Se.cardSkill);

        Debug.Log("関数内も呼ばれた");
        skillCutInCard.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
        skillCutIn.transform.DOMove(new Vector3(0, 0, 0), animeTime).OnComplete(() =>
        {
            skillCutIn.transform.DOMove(new Vector3(0, 0, 0), 0.7f).OnComplete(() =>
            {
                skillCutIn.transform.DOMove(CutInAfter.transform.position, animeTime / 2).OnComplete(() =>
                {
                    skillCutIn.transform.position = CutInBefore.transform.position;
                    AnimeSwitch();
                });
            });
        });
    }


    private void AnimeSwitch()
    {
        switch (animeFunctionNum)
        {
            case 1:
                AnimeAllGet();
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6:
                break;

            case 7:
                break;

            case 8:
                break;

            case 9:
                break;

            case 10:
                break;

            case 11:
                break;

            case 12:
                break;

            default:
                Debug.Log(animeFunctionNum + "がおかしい");
                break;

        }
    }


    /*雛形
    public void Anime()
        animeEnd = false;
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
                    
                });
            });
        }
        //山札2から各プレイヤーに移動
        else
        {
            Yamahuda2Fake.transform.DORotate(new Vector3(0, 90, 0), rotateTime).OnComplete(() =>
            {
                //引いたカードのspriteにする
                Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
                Yamahuda2Fake.transform.DORotate(new Vector3(0, 0, 0), rotateTime).OnComplete(() =>
                {
                    
                });
            });
        }
    */
}
