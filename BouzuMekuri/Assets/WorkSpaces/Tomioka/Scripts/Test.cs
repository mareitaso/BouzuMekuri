using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [HideInInspector]
    public bool drowYama1;

    //富岡編集
    [SerializeField]
    private CardDataBase cardDataBase;
    [SerializeField]
    private Image Yamahuda1, Yamahuda2, Sutehuda, Hikihuda;

    public List<Image> Player;

    [Header("ここにはプレイヤーと捨て札と山札の枚数を入れる")]
    [SerializeField]
    private List<Text> PlayerCards;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    [SerializeField]
    CardAnimation cardAnimation;

    private void Start()
    {
        TextChange();
    }

    public void Draw1()
    {
        if (deck.cards1.Count > 0)//山札1があるとき
        {
            
            //山札1がラストの時
            if (deck.cards1.Count == 1)
            {
                Yamahuda1.sprite = Resources.Load<Sprite>("Images/Null");
            }

            drowYama1 = true;
            deck.drawcard = deck.cards1[0];//0番目を引いたカードとして登録
            
            cardAnimation.AnimeYamaToPlayer();
            
            Debug.LogError(deck.drawcard);
            Hikihuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard + 1));

            /// <summary>
            /// ここにスキル判別してifで囲む
            /// </summary>

            //デバッグ用
            if (cardDataBase.YamahudaLists()[deck.drawcard].GetOtherJob() == Card.OtherJob.Debug)
            {
                MyRule.instance.DisNCard();
            }



            //武官を引くかつ武官スキルあり
            if (cardDataBase.YamahudaLists()[deck.drawcard].GetSecondJob() == Card.SecondJob.Bukan)
            {
                BukanDraw.instance.Bukan_Draw();
                ImageChangeTono();
            }
            //弓持ちを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetThirdJob() == Card.ThirdJob.Yumimoti)
            {
                YumimotiDraw.instance.Yumimoti_Draw();
                ImageChangeTono();
            }


            /// <summary>
            /// ここにスキル判別してifで囲む
            /// </summary>

            //天皇を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetSecondJob() == Card.SecondJob.Tennou)
            {
                TennouDraw.instance.Tennou_Draw();
            }
            //段付きを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetThirdJob() == Card.ThirdJob.Dantuki)
            {
                DantukiDraw.instance.Dantuki_Draw();
            }


            ////偉い姫を引く
            //else if (cardDataBase.YamahudaLists()[deck.drawcard].GetOtherJob() == Card.OtherJob.GreatHime)
            //{
            //    GreatHimeDraw.instance.GreatHime_Draw();
            //}

            //蝉丸を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetSecondJob() == Card.SecondJob.Semimaru)
            {
                SemimaruDraw.instance.Semimaru_Draw();
            }
            //坊主を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bouzu)
            {
                BouzuDraw.instance.Bouzu_Draw();
            }
            //姫を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Hime)
            {
                HimeDraw.instance.Hime_Draw();
            }
            //殿を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tono)
            {
                TonoDraw.instance.Tono_Draw();
            }
            else
            {
                Debug.LogError("カードの種類がおかしい");
            }

            deck.cards1.RemoveAt(0);//0番目を削除
            BukanDraw.instance.ReverseRotation();
            TextChange();
        }
        //山札2にカードがある場合
        else if (deck.cards2.Count > 0)
        {
            //まだ片方の山札が残っているからそっちを引こう
        }
        else
        {
            GameEnd();
        }
    }
    public void Draw2()
    {
        if (deck.cards2.Count > 0)//山札2があるとき
        {
            //山札2がラストの時
            if (deck.cards2.Count == 1)
            {
                Yamahuda2.sprite = Resources.Load<Sprite>("Images/Null");
            }

            drowYama1 = false;
            deck.drawcard = deck.cards2[0];//0番目を引いたカードとして登録
            Debug.LogError(deck.drawcard);
            Hikihuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard + 1));

            //デバッグ用
            if (cardDataBase.YamahudaLists()[deck.drawcard].GetOtherJob() == Card.OtherJob.Debug)
            {
                MyRule.instance.SomeoneToMe();
            }


            //武官を引くかつ武官スキルあり
            if (cardDataBase.YamahudaLists()[deck.drawcard].GetSecondJob() == Card.SecondJob.Bukan)
            {
                BukanDraw.instance.Bukan_Draw();
                ImageChangeTono();
            }
            //弓持ちを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetThirdJob() == Card.ThirdJob.Yumimoti)
            {
                YumimotiDraw.instance.Yumimoti_Draw();
                ImageChangeTono();
            }
            //天皇を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetSecondJob() == Card.SecondJob.Tennou)
            {
                TennouDraw.instance.Tennou_Draw();
            }
            //段付きを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetThirdJob() == Card.ThirdJob.Dantuki)
            {
                DantukiDraw.instance.Dantuki_Draw();
            }

            ////偉い姫を引く
            //else if (cardDataBase.YamahudaLists()[deck.drawcard].GetOtherJob() == Card.OtherJob.GreatHime)
            //{

            //}

            //蝉丸を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetSecondJob() == Card.SecondJob.Semimaru)
            {
                SemimaruDraw.instance.Semimaru_Draw();
            }
            //坊主を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bouzu)
            {
                BouzuDraw.instance.Bouzu_Draw();
            }
            //姫を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Hime)
            {
                HimeDraw.instance.Hime_Draw();
            }
            //殿を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tono)
            {
                TonoDraw.instance.Tono_Draw();
            }
            else
            {
                Debug.LogError("カードの種類がおかしい");
            }

            deck.cards2.RemoveAt(0);//0番目を削除
            BukanDraw.instance.ReverseRotation();
            TextChange();
        }
        //山札2にカードがある場合
        else if (deck.cards1.Count > 0)
        {
            //まだ片方の山札が残っているからそっちを引こう
        }
        else
        {
            GameEnd();
        }
    }
    public void S()
    {
        MasterList.Instance.Shuffle2();
        TextChange();
        Debug.LogError("");
    }

    public void ImageChangeTono()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard +1));
    }
    public void ImageChangeHime()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard + 1));
        Sutehuda.sprite = Resources.Load<Sprite>("Images/Null"); ;
    }

    public void ImageChangeBouzu()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/Null");
        Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard + 1));
    }

    public void ImageChangeSemimaru()
    {
        Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount);
    }

    public void TextChange()
    {
        PlayerCards[0].text = MasterList.Instance.list[0].Count.ToString();
        PlayerCards[1].text = MasterList.Instance.list[1].Count.ToString();
        PlayerCards[2].text = MasterList.Instance.list[2].Count.ToString();
        PlayerCards[3].text = MasterList.Instance.list[3].Count.ToString();
        PlayerCards[4].text = deck.DiscardCount.Count.ToString();
        PlayerCards[5].text = deck.cards1.Count.ToString();
        PlayerCards[6].text = deck.cards2.Count.ToString();
    }


    //どちらの山札もカードがなくなったときの処理
    private void GameEnd()
    {
        //Yamahuda1.sprite = Resources.Load<Sprite>("Images/Null");
        //Yamahuda2.sprite = Resources.Load<Sprite>("Images/Null");
        Debug.LogError("終わり");
        hand.Settlement();
    }


    public void MockShuffle()
    {
        if (hand.handCount[0] == 0)
        {
            Player[0].sprite = Resources.Load<Sprite>("Images/Null");
        }
        else
        {
            Player[0].sprite = Resources.Load<Sprite>("Images/MainCards/" + (hand.handCount[0] + 1));
        }

        if (hand.handCount[1] == 0)
        {
            Player[1].sprite = Resources.Load<Sprite>("Images/Null");
        }
        else
        {
            Player[1].sprite = Resources.Load<Sprite>("Images/MainCards/" + (hand.handCount[1] + 1));
        }

        if (hand.handCount[2] == 0)
        {
            Player[2].sprite = Resources.Load<Sprite>("Images/Null");
        }
        else
        {
            Player[2].sprite = Resources.Load<Sprite>("Images/MainCards/" + (hand.handCount[2] + 1));
        }

        if (hand.handCount[3] == 0)
        {
            Player[3].sprite = Resources.Load<Sprite>("Images/Null");
        }
        else
        {
            Player[3].sprite = Resources.Load<Sprite>("Images/MainCards/" + (hand.handCount[3] + 1));
        }
    }
}
