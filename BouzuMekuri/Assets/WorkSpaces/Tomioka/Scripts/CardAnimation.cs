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
    private Image skillCutIn;

    [SerializeField]
    private GameObject CutInBefore, CutInAfter;

    public bool animeEnd = true;

    private int movePlace;

    private float animeTime = 0.6f;
    private float rotateTime = 0.3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimeSkillCutIn();
        }
    }


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
        animeEnd = false;
        movePlace = deck.Count;
        AnimeSkillCutIn();

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
    public void PlayerAllShuffle()
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

    public void AnimeSkillCutIn()
    {
        Debug.Log("関数内も呼ばれた");

        skillCutIn.transform.DOMove(new Vector3(0, 0, 0), animeTime).OnComplete(() =>
        {
            skillCutIn.transform.DOMove(new Vector3(0, 0, 0), 0.7f).OnComplete(() =>
            {
                skillCutIn.transform.DOMove(CutInAfter.transform.position, animeTime / 2).OnComplete(() =>
                {
                    skillCutIn.transform.position = CutInBefore.transform.position;
                });
            });
        });
    }

    private IEnumerator EndCutIn()
    {
        AnimeSkillCutIn();

        while (animeEnd)
        {
            // childのisComplete変数がtrueになるまで待機
            yield return new WaitForEndOfFrame();
        }

        // childのアニメーションが終了したとき
        // (child.isCompleteがtrueになったとき)
        // ここより下にかかれた処理が実行される
    }

    //private void AnimeSwitch()
    //{
    //    switch ()
    //    {
    //        case 1:
    //            break;
    //    }
    //}


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
