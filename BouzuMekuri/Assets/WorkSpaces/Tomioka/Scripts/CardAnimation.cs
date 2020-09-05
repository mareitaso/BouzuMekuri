using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    [SerializeField]
    private CardDataBase cardDataBase;

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
    private Draw draw;
    [SerializeField]
    private Touch touch;

    [SerializeField]
    private Image skillCutIn;
    [SerializeField]
    private Image fieldSkillCutIn;
    [SerializeField]
    private Image skillCutInCard;

    [SerializeField]
    private Text drawCardType;
    [SerializeField]
    private Text skillType;
    [SerializeField]
    private Text fieldSkillType;

    [SerializeField]
    private GameObject CutInBefore, CutInAfter;

    //[HideInInspector]
    public bool animeEnd = true;

    [HideInInspector]
    public int skillPlayer;
    [HideInInspector]
    public int skillDamagePlayer;
    [HideInInspector]
    public int animeFunctionNum;
    public int movePlace;

    private readonly float animeTime = 0.6f;
    private readonly float rotateTime = 0.3f;

    //山札からプレイヤーの手札に移動するアニメーション
    public void AnimeTono()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
                         draw.FieldEffectSwitch();
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
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
    }

    //捨て札に全部移動するアニメーション
    public void AnimeBouzu()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count;

        if (draw.drowYama1 == true)
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
                        draw.FieldEffectSwitch();
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
                        player[movePlace].sprite = Resources.Load<Sprite>("Images/Null");
                        animeEnd = true;
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
    }

    //捨て札を全部回収するアニメーション
    public void AnimeHime()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count;

        if (draw.drowYama1 == true)
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
                        draw.FieldEffectSwitch();
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
                    });

                    //捨て札から回収のアニメーション
                    SutehudaFake.sprite = Sutehuda.sprite;
                    Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");

                    SutehudaFake.transform.DOMove(Place[movePlace].transform.position, animeTime).OnComplete(() =>
                    {
                        SutehudaFake.transform.position = Sutehuda.transform.position;
                        SutehudaFake.sprite = Resources.Load<Sprite>("Images/Null");
                        animeEnd = true;
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
    }

    //もう一枚引くアニメーション
    public void AnimeOneDraw()
    {
        YamaLoss();
        animeEnd = false;
        movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
                        draw.Draw1();
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
                        draw.Draw2();
                    });
                });
            });
        }
    }

    //全プレイヤーの手札を回収するアニメーション
    public void AnimeHandCardGet()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
                            playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                            playerFake[i].transform.position = player[i].transform.position;
                        }
                        animeEnd = true;
                        draw.FieldEffectSwitch();
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
                            playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                            playerFake[i].transform.position = player[i].transform.position;
                        }
                        animeEnd = true;
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
    }

    //プレイヤー1人にN枚カードを移動する
    private void AnimeCardNMove()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
                        if (i != movePlace)
                        {
                            playerFake[i].sprite = player[i].sprite;
                            if (MasterList.instance.list[i].Count == 0)
                            {
                                player[i].sprite = Resources.Load<Sprite>("Images/Null");
                            }
                            else
                            {
                                player[i].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.instance.list[i][MasterList.instance.list[i].Count - 1]);
                            }
                            playerFake[i].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        }
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
                        draw.FieldEffectSwitch();
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
                        if (i != movePlace)
                        {
                            playerFake[i].sprite = player[i].sprite;
                            if (MasterList.instance.list[i].Count == 0)
                            {
                                player[i].sprite = Resources.Load<Sprite>("Images/Null");
                            }
                            else
                            {
                                playerFake[i].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.instance.list[i][MasterList.instance.list[i].Count - 1]);
                            }
                            playerFake[i].transform.DOMove(Place[movePlace].transform.position, animeTime);
                        }
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
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
    }

    //全プレイヤーの手札と捨て札を回収するアニメーション
    private void AnimeAllGet()
    {
        YamaLoss();
        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
                        draw.FieldEffectSwitch();
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
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
    }

    //左隣からカードをもらうアニメーション
    private void AnimeLeftToRight()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count:
        int YumiNum = YumimotiDraw.instance.YumimotiNum;
        Debug.Log(YumiNum);
        Debug.Log("カードは" + (YumiNum + 1) + "P" + "→" + (deck.Count + 1) + "Pへ");

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
                        if (MasterList.instance.list[YumiNum].Count == 0)
                        {
                            player[YumiNum].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        else
                        {
                            playerFake[YumiNum].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.instance.list[YumiNum][MasterList.instance.list[YumiNum].Count - 1]);
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
                            draw.FieldEffectSwitch();
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
                            draw.FieldEffectSwitch();
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
                        if (MasterList.instance.list[YumiNum].Count == 0)
                        {
                            player[YumiNum].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                        else
                        {
                            playerFake[YumiNum].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.instance.list[YumiNum][MasterList.instance.list[YumiNum].Count - 1]);
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
                            draw.FieldEffectSwitch();
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
                            draw.FieldEffectSwitch();
                        });
                    }
                });
            });
        }
    }

    //自分以外のプレイヤーの手札をすべて捨てる
    public void AnimeAllDiscard()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
                    for (int i = 0; i > 4; i++)
                    {
                        if (i != movePlace)
                        {
                            playerFake[i].sprite = player[i].sprite;

                            //枚数によってはNullか持ってる1番上のカードにする
                            player[i].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                    }
                    playerFake[0].transform.DOMove(Sutehuda.transform.position, animeTime);
                    playerFake[1].transform.DOMove(Sutehuda.transform.position, animeTime);
                    playerFake[2].transform.DOMove(Sutehuda.transform.position, animeTime);
                    playerFake[3].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (i != movePlace)
                            {
                                playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                                playerFake[i].transform.position = player[i].transform.position;
                                player[i].sprite = Resources.Load<Sprite>("Images/Null");
                            }
                        }
                        animeEnd = true;
                        draw.FieldEffectSwitch();
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
                    });
                    for (int i = 0; i > 4; i++)
                    {
                        if (i != movePlace)
                        {
                            playerFake[i].sprite = player[i].sprite;

                            //枚数によってはNullか持ってる1番上のカードにする
                            player[i].sprite = Resources.Load<Sprite>("Images/Null");
                        }
                    }
                    playerFake[0].transform.DOMove(Sutehuda.transform.position, animeTime);
                    playerFake[1].transform.DOMove(Sutehuda.transform.position, animeTime);
                    playerFake[2].transform.DOMove(Sutehuda.transform.position, animeTime);
                    playerFake[3].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (i != movePlace)
                            {
                                playerFake[i].sprite = Resources.Load<Sprite>("Images/Null");
                                playerFake[i].transform.position = player[i].transform.position;
                                player[i].sprite = Resources.Load<Sprite>("Images/Null");
                            }
                        }
                        animeEnd = true;
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
    }

    //蝉丸の山札半分捨てる処理
    public void AnimeYamaHalf()
    {
        YamaLoss();
        animeEnd = false;
        //movePlace = deck.Count:

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
        if (SemimaruDraw.instance.halfYamahuda1 == 0)
        {
            Debug.Log("山札1は何もしない");
            animeEnd = true;
            draw.FieldEffectSwitch();
        }
        else if (SemimaruDraw.instance.halfYamahuda1 >= 1)
        {
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
                        draw.FieldEffectSwitch();
                    });
                });
            });
        }
        else
        {
            Debug.LogError("山札1の捨てるアニメーションおかしい");
            Debug.Log(SemimaruDraw.instance.halfYamahuda1);
            animeEnd = true;
            draw.FieldEffectSwitch();
        }



        if (SemimaruDraw.instance.halfYamahuda2 == 0)
        {
            Debug.Log("山札2は何もしない");
            animeEnd = true;
            draw.FieldEffectSwitch();
        }
        else if (SemimaruDraw.instance.halfYamahuda2 >= 1)
        {
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
                        draw.FieldEffectSwitch();
                    });
                });
            });
            animeEnd = true;
            draw.FieldEffectSwitch();
        }
        else
        {
            Debug.LogError("山札2の捨てるアニメーションおかしい");
            Debug.Log(SemimaruDraw.instance.halfYamahuda2);
            animeEnd = true;
            draw.FieldEffectSwitch();
        }
    }

    //偽山札を作り移動アニメーションを見せる用関数
    private void Yama1Null()
    {
        if (deck.cards1.Count <= 0)
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
        if (deck.cards2.Count <= 0)
        {
            Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/Null");
        }
        else
        {
            Yamahuda2Fake.sprite = Resources.Load<Sprite>("Images/CardBack");
        }
    }

    private void YamaLoss()
    {
        if (deck.cards1.Count <= 0)
        {
            Yamahuda1.sprite = Resources.Load<Sprite>("Images/Null");
        }
        if (deck.cards2.Count <= 0)
        {
            Yamahuda2.sprite = Resources.Load<Sprite>("Images/Null");
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
                if (MasterList.instance.list[i].Count != 0)
                {
                    playerFake[i].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                    MasterList.instance.list[i][MasterList.instance.list[i].Count - 1]);
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
                draw.FieldEffectSwitch();
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
            playerFake[touch.touchPlayer].sprite = Resources.Load<Sprite>("Images/Null");
            player[touch.touchPlayer].sprite = Resources.Load<Sprite>("Images/Null");
            animeEnd = true;
            draw.FieldEffectSwitch();
        });


        playerFake[skillPlayer].sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[0]);
        //枚数によってはNullか持ってる1番上のカードにする

        player[skillPlayer].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                            MasterList.instance.list[skillPlayer][MasterList.instance.list[skillPlayer].Count - 1]);

        playerFake[skillPlayer].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
        {
            playerFake[skillPlayer].transform.position = Place[skillPlayer].transform.position;
            Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[0]);
            playerFake[skillPlayer].sprite = Resources.Load<Sprite>("Images/Null");
            animeEnd = true;
            draw.FieldEffectSwitch();
        });

    }

    //全てのプレイヤーは最下位と同じ枚数になるように、捨て場にカードを置く
    public void AnimePlayerSkill3()
    {
        animeEnd = false;

        int i = skillPlayer + 1;
        if (MasterList.instance.list[skillPlayer].Count != 0)
        {
            playerFake[i % 4].sprite = player[i % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[i % 4].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.instance.list[i % 4][MasterList.instance.list[i % 4].Count - 1]);

            playerFake[i % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[i % 4].transform.position = Place[i % 4].transform.position;
                Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[deck.DiscardCount.Count - 1]);
                playerFake[i % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
                draw.FieldEffectSwitch();
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
                  draw.FieldEffectSwitch();
              });
        }
        int j = i + 1;
        if (MasterList.instance.list[skillPlayer].Count != 0)
        {
            playerFake[j % 4].sprite = player[j % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[j % 4].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.instance.list[j % 4][MasterList.instance.list[j % 4].Count - 1]);

            playerFake[j % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[j % 4].transform.position = Place[j % 4].transform.position;
                Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[deck.DiscardCount.Count - 1]);
                playerFake[j % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
                draw.FieldEffectSwitch();
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
                draw.FieldEffectSwitch();
            });
        }

        int k = j + 1;
        if (MasterList.instance.list[skillPlayer].Count != 0)
        {
            playerFake[k % 4].sprite = player[k % 4].sprite;
            //枚数によってはNullか持ってる1番上のカードにする

            player[k % 4].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                                MasterList.instance.list[k % 4][MasterList.instance.list[k % 4].Count - 1]);

            playerFake[k % 4].transform.DOMove(Sutehuda.transform.position, animeTime).OnComplete(() =>
            {
                playerFake[k % 4].transform.position = Place[k % 4].transform.position;
                Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[deck.DiscardCount.Count - 1]);
                playerFake[k % 4].sprite = Resources.Load<Sprite>("Images/Null");
                animeEnd = true;
                draw.FieldEffectSwitch();
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
                draw.FieldEffectSwitch();
            });
        }
    }

    //プレイヤーが4回ひいたら山札から捨て場に３枚置く
    public void AnimeFieldEffect3()
    {
        YamaLoss();
        animeEnd = false;
        movePlace = deck.Count;

        if (draw.drowYama1 == true)
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
                        animeEnd = true;
                    });
                });
            });
        }
    }

    public void AnimeSkillCutIn()
    {
        animeEnd = false;
        movePlace = deck.Count;
        SoundManager.instance.SeApply(Se.cardSkill);

        CutInText();
        skillCutInCard.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.drawcard);
        skillCutIn.transform.DOMove(new Vector3(0, 0, 0), animeTime).OnComplete(() =>
        {
            skillCutIn.transform.DOMove(new Vector3(0, 0, 0), 2f).OnComplete(() =>
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
        Debug.Log(animeFunctionNum);
        switch (animeFunctionNum)
        {
            case 1:
                //天皇のスキル1
                AnimeOneDraw();
                break;

            case 2:
                //天皇のスキル2
                AnimeAllGet();
                break;

            case 3:
                //段付きスキル1
                AnimeCardNMove();
                break;

            case 4:
                //段付きスキル2
                AnimeHandCardGet();
                break;

            case 5:
                //武官スキル1
                AnimeCardNMove();
                break;

            case 6:
                //武官スキル2
                AnimeTono();
                Reverses();
                break;

            case 7:
                //弓持ちスキル
                AnimeLeftToRight();
                break;

            case 8:
                //蝉丸スキル1
                AnimeTono();
                break;

            case 9:
                //蝉丸スキル2
                AnimeHandCardGet();
                break;

            case 10:
                //蝉丸スキル3
                AnimeAllDiscard();
                break;

            case 11:
                //蝉丸スキル4
                AnimeYamaHalf();
                break;

            case 12:
                //蝉丸スキル5
                AnimeTono();
                break;

            case 13:
                //フィールド効果2

                break;

            case 14:
                break;

            default:
                Debug.Log(animeFunctionNum + "がおかしい");
                break;
        }
    }

    private void CutInText()
    {
        //天皇スキル1
        if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 1)
        {
            drawCardType.text = "天皇ルール";
            skillType.text = "山札から2枚引く";
        }

        //天皇スキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 2)
        {
            drawCardType.text = "天皇ルール";
            skillType.text = "全員の札と捨て札をすべてもらう";
        }

        //段付きスキル1
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 3)
        {
            drawCardType.text = "段付きルール";
            skillType.text = "全員から5枚もらう";
        }

        //段付きスキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 4)
        {
            drawCardType.text = "段付きルール";
            skillType.text = "全員の札をすべてもらう";
        }

        //武官スキル1
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 1)
        {
            drawCardType.text = "武官ルール";
            skillType.text = "全員から4枚もらう";
        }

        //武官スキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 2)
        {
            drawCardType.text = "武官ルール";
            skillType.text = "山札を引く順番が逆周りに";
        }

        //弓持ちスキル1
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 3)
        {
            drawCardType.text = "弓持ちルール";
            skillType.text = "左隣のプレイヤーの\n手札から5枚もらう";
        }

        //蝉丸スキル1
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 1)
        {
            drawCardType.text = "蝉丸ルール";
            skillType.text = "次の人1回休み";
        }

        //蝉丸スキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 2)
        {
            drawCardType.text = "蝉丸ルール";
            skillType.text = "他のプレイヤーの手札を全てもらう";
        }

        //蝉丸スキル3
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 3)
        {
            drawCardType.text = "蝉丸ルール";
            skillType.text = "他のプレイヤーは全ての手札を捨て札に置く";
        }

        //蝉丸スキル4
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 4)
        {
            drawCardType.text = "蝉丸ルール";
            skillType.text = "山札の数を半分に";
        }

        //蝉丸スキル6
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 5)
        {
            drawCardType.text = "蝉丸ルール";
            skillType.text = "次に発動するスキルを無効化する";
        }
        else
        {
            Debug.LogError("ここのメッセージはでないはずだよ");
            drawCardType.text = "エラー";
            skillType.text = "ここのメッセージはでないはずだよ";
            Debug.LogError("");
            DebugSkill();
        }

    }

    //武官の逆回転引いたとき用
    private void Reverses()
    {
        if (BukanDraw.instance.clockWise)
        {
            deck.Count++;
            deck.Count %= 4;

        }
        else
        {
            deck.Count--;
            if (deck.Count < 0)
            {
                deck.Count = 3;
            }
        }
    }

    //フィールド効果のカットイン
    public void FieldSkillCutIn()
    {
        animeEnd = false;
        movePlace = deck.Count;
        SoundManager.instance.SeApply(Se.cardSkill);

        if (draw.fieldEffectNum == 2)
        {
            fieldSkillType.text = "山札が２０枚減るごとに\n手札を入れ替える";
        }
        else
        {
            fieldSkillType.text = "プレイヤーが4回ひいたら\n山札から捨て場に３枚置く";
        }

        fieldSkillCutIn.transform.DOMove(new Vector3(0, 0, 0), animeTime).OnComplete(() =>
        {
            fieldSkillCutIn.transform.DOMove(new Vector3(0, 0, 0), 2f).OnComplete(() =>
            {
                fieldSkillCutIn.transform.DOMove(CutInAfter.transform.position, animeTime / 2).OnComplete(() =>
                {
                    fieldSkillCutIn.transform.position = CutInBefore.transform.position;
                    if (draw.fieldEffectNum == 2)
                    {
                        //フィールド効果2
                        MasterList.instance.Shuffle2();
                        AnimePlayerSkill1();
                        draw.TextChange();
                    }
                    else
                    {
                        if (draw.drowYama1 == true && deck.cards1.Count != 0)
                        {
                            //フィールド効果3
                            draw.FieldEffect3();
                        }
                        if (draw.drowYama1 == false && deck.cards2.Count != 0)
                        {
                            //フィールド効果3
                            draw.FieldEffect3();
                        }
                    }
                });
            });
        });
    }

    //スキルエラーを探す用の関数
    private void DebugSkill()
    {
        Debug.LogError("引いたプレイヤー(count)は" + deck.Count);
        Debug.LogError("引いたプレイヤー(movePlace)は" + movePlace);

        Debug.LogError("引いたカードは" + deck.drawcard);
        Debug.LogError("引いたカードの情報1は" + cardDataBase.YamahudaLists()[deck.drawcard - 1].GetFirstJob());
        Debug.LogError("引いたカードの情報2は" + cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob());
        Debug.LogError("引いたカードの情報3は" + cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob());
        Debug.LogError("引いたカードの情報4は" + cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob());

        Debug.LogError("プレイヤー" + (deck.drawcard + 1) + "のスキル設定1は" + RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0]);
        Debug.LogError("プレイヤー" + (deck.drawcard + 1) + "のスキル設定2は" + RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0]);
        Debug.LogError("プレイヤー" + (deck.drawcard + 1) + "のスキル設定3は" + RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0]);

        //天皇スキル1
        if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 1)
        {
            Debug.LogError("天皇スキル1");
        }

        //天皇スキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 2)
        {
            Debug.LogError("天皇スキル2");
        }

        //段付きスキル1
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 3)
        {
            Debug.LogError("段付きスキル1");
        }

        //段付きスキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 4)
        {
            Debug.LogError("段付きスキル2");
        }

        //武官スキル1
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 1)
        {
            Debug.LogError("武官スキル1");
        }

        //武官スキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 2)
        {
            Debug.LogError("武官スキル2");
        }

        //弓持ちスキル1
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti &&
            RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 3)
        {
            Debug.LogError("弓持ちスキル1");
        }

        //蝉丸スキル2
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 1)
        {
            Debug.LogError("蝉丸スキル2");
        }

        //蝉丸スキル3
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 2)
        {
            Debug.LogError("蝉丸スキル3");
        }

        //蝉丸スキル4
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 3)
        {
            Debug.LogError("蝉丸スキル4");
        }

        //蝉丸スキル5
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 4)
        {
            Debug.LogError("蝉丸スキル5");
        }

        //蝉丸スキル6
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] == 5)
        {
            Debug.LogError("蝉丸スキル6");
        }
        else
        {
            Debug.LogError("もうわけわかめ");
            Debug.LogError("引いたカードは" + deck.drawcard + "だよね？");
        }
    }


    /*雛形
    public void Anime()
        animeEnd = false;
        movePlace = deck.Count;

        //山札1から各プレイヤーに移動
        if (draw.drowYama1 == true)
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
