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
    private Image Yamahuda1, Yamahuda2, Sutehuda;//, Hikihuda;

    public List<Image> Player;

    [Header("ここにはプレイヤーと捨て札と山札の枚数を入れる")]
    [SerializeField]
    private List<Text> PlayerCards;
    [SerializeField]
    private Deck deck;
    //[SerializeField]
    //private HandCount hand;

    [SerializeField]
    CardAnimation cardAnimation;

    [HideInInspector]
    public bool drawAgain = false;

    [SerializeField]
    Text drawType;

    private void Start()
    {
        SoundManager.instance.BgmApply(Bgm.Main);
        TextChange();
        drawType.text = "";
    }

    public void Draw1()
    {
        SoundManager.instance.SeApply(Se.cardOpen);
        if (deck.cards1.Count > 0)//山札1があるとき
        {

            //山札1がラストの時
            if (deck.cards1.Count == 1)
            {
                Yamahuda1.sprite = Resources.Load<Sprite>("Images/Null");
            }

            drowYama1 = true;
            deck.drawcard = deck.cards1[0];//0番目を引いたカードとして登録


            Debug.LogError(deck.drawcard);
            //Hikihuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard + 1));

            /// <summary>
            /// ここにスキル判別してifで囲む
            /// </summary>

            //デバッグ用
            if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.Debug)
            {
                MyRule.instance.DisNCard();
                drawType.text = "デバッグ";
            }


            /// <summary>
            /// ここにスキル判別してifで囲む
            /// </summary>

            //天皇を引く
            if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou &&
                (RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 1 ||
                RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 2))
            {
                TennouDraw.instance.Tennou_Draw();
                drawType.text = "天皇";
            }
            //段付きを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki &&
                (RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 3 ||
                RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 4))
            {
                DantukiDraw.instance.Dantuki_Draw();
                drawType.text = "段付き";
            }



            //武官を引くかつ武官スキルあり
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan &&
                (RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 1 ||
                RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 2))
            {
                BukanDraw.instance.Bukan_Draw();
                drawType.text = "武官";
            }

            //弓持ちを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 3)
            {
                YumimotiDraw.instance.Yumimoti_Draw();
                drawType.text = "弓持ち";
            }


            ////偉い姫を引く
            //else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.GreatHime)
            //{
            //    GreatHimeDraw.instance.GreatHime_Draw();
            //}

            //蝉丸を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru /*&&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] >= 1*/)
            {
                SemimaruDraw.instance.Semimaru_Draw();
                drawType.text = "蝉丸";
            }

            //坊主を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetFirstJob() == Card.FirstJob.Bouzu)
            {
                BouzuDraw.instance.Bouzu_Draw();
                drawType.text = "坊主";
            }
            //姫を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetFirstJob() == Card.FirstJob.Hime)
            {
                HimeDraw.instance.Hime_Draw();
                drawType.text = "姫";
            }
            //殿を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetFirstJob() == Card.FirstJob.Tono)
            {
                TonoDraw.instance.Tono_Draw();
                drawType.text = "殿";
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
        SoundManager.instance.SeApply(Se.cardOpen);
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
            //Hikihuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard));

            //cardAnimation.AnimeYamaToPlayer();

            //デバッグ用
            if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.Debug)
            {
                MyRule.instance.SomeoneToMe();
                drawType.text = "デバッグ";
            }


            //天皇を引く
            if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou &&
                (RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 1 ||
                RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 2))
            {
                TennouDraw.instance.Tennou_Draw();
                drawType.text = "天皇";
            }
            //段付きを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki &&
                (RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 3 ||
                RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 4))
            {
                DantukiDraw.instance.Dantuki_Draw();
                drawType.text = "段付き";
            }



            //武官を引くかつ武官スキルあり
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan &&
                (RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 1 ||
                RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 2))
            {
                BukanDraw.instance.Bukan_Draw();
                drawType.text = "武官";
            }

            //弓持ちを引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 3)
            {
                YumimotiDraw.instance.Yumimoti_Draw();
                drawType.text = "弓持ち";
            }


            ////偉い姫を引く
            //else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.GreatHime)
            //{
            //    GreatHimeDraw.instance.GreatHime_Draw();
            //}

            //蝉丸を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] >= 1)
            {
                SemimaruDraw.instance.Semimaru_Draw();
                drawType.text = "蝉丸";
            }

            //坊主を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetFirstJob() == Card.FirstJob.Bouzu)
            {
                BouzuDraw.instance.Bouzu_Draw();
                drawType.text = "坊主";
            }
            //姫を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetFirstJob() == Card.FirstJob.Hime)
            {
                HimeDraw.instance.Hime_Draw();
                drawType.text = "姫";
            }
            //殿を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetFirstJob() == Card.FirstJob.Tono)
            {
                TonoDraw.instance.Tono_Draw();
                drawType.text = "殿";
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
        MasterList.instance.Shuffle2();
        TextChange();
        Debug.LogError("");
    }

    public void Image()
    {
        //ListAの長さの所にListBの長さを入れるのはやめよう!!
        if (MasterList.instance.list[deck.Count].Count != 0)
        {
            try
            {
                Player[deck.Count].sprite = Resources.Load<Sprite>("Images/MainCards/" +
                MasterList.instance.list[deck.Count][MasterList.instance.list[deck.Count].Count - 1]);
            }
            catch
            {
                Debug.Log("例外発生　" + deck.Count + "  " + MasterList.instance.list[deck.Count].Count + " " + MasterList.instance.list.Count);
            }

        }
        else
        {
            Player[deck.Count].sprite = Resources.Load<Sprite>("Images/Null");
        }
        //int x = MasterList.instance.list[deck.Count]
        //Debug.Log(MasterList.instance.list[deck.Count][MasterList.instance.list[deck.Count].Count-1]);
    }

    public void ImageChangeTono()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard));
    }
    public void ImageChangeHime()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard));
        Sutehuda.sprite = Resources.Load<Sprite>("Images/Null");
    }

    public void ImageChangeBouzu()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/Null");
        Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + (deck.drawcard));
    }

    public void ImageChangeSemimaru()
    {
        Sutehuda.sprite = Resources.Load<Sprite>("Images/MainCards/" + deck.DiscardCount[0]);
    }

    public void TextChange()
    {
        PlayerCards[0].text = MasterList.instance.list[0].Count.ToString();
        PlayerCards[1].text = MasterList.instance.list[1].Count.ToString();
        PlayerCards[2].text = MasterList.instance.list[2].Count.ToString();
        PlayerCards[3].text = MasterList.instance.list[3].Count.ToString();
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
        SceneController.instance.LoadScene(SceneController.SceneName.Result);
        //hand.Settlement();
    }

    public void MockShuffle()
    {
        MasterList.instance.Shuffle2();
        /*
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
        }*/
    }

}
