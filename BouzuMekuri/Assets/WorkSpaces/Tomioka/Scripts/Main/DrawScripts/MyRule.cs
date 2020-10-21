using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRule : SingletonMonoBehaviour<MyRule>
{
    [SerializeField]
    CardDataBase cardDataBase;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;
    [SerializeField]
    CardAnimation cardAnime;



    //自分のルールのカードの枚数
    private int moveNCards = 1;

    //自分のルールの対象人数
    private int somePlayer = 1;

    private int count;

    //カードをもらうか捨てるの時のみ使用
    public List<int> cardN;

    public void CardTypeCheck()
    {
        count = deck.Count;

        //card123を初期化
        CardNull();

        //天皇を引く
        if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou && RuleCreate.instance.cardType[count] == 1)
        {
            CardEffectCheck();
        }
        //段付きを引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki && RuleCreate.instance.cardType[count] == 2)
        {
            CardEffectCheck();
        }

        //武官を引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan && RuleCreate.instance.cardType[count] == 3)
        {
            CardEffectCheck();
        }

        //弓持ちを引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti && RuleCreate.instance.cardType[count] == 4)
        {
            CardEffectCheck();
        }

        //偉い姫を引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.GreatHime && RuleCreate.instance.cardType[count] == 5)
        {
            CardEffectCheck();
        }
        else
        {
            Debug.LogError(deck.drawcard);
            Debug.LogError(RuleCreate.instance.cardType[count]);
            Debug.LogError("この人の自作ルールがおかしい");
        }
    }

    private void CardEffectCheck()
    {
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        switch (RuleCreate.instance.cardEffect[count])
        {
            case 1:
                //カードをもらう
                moveNCards = RuleCreate.instance.cardNum[count];
                somePlayer = RuleCreate.instance.playerNum[count];
                SomeoneToMe();
                cardAnime.animeFunctionNum = 13;
                cardAnime.AnimeSkillCutIn();
                break;

            case 2:
                //カードを引く
                moveNCards = RuleCreate.instance.cardNum[count];
                somePlayer = RuleCreate.instance.playerNum[count];
                DrawnNCards();
                cardAnime.animeFunctionNum = 14;
                cardAnime.AnimeSkillCutIn();
                break;

            case 3:
                //場に置く
                moveNCards = RuleCreate.instance.cardNum[count];
                somePlayer = RuleCreate.instance.playerNum[count];
                DisNCard();
                cardAnime.animeFunctionNum = 15;
                cardAnime.AnimeSkillCutIn();
                break;

            case 4:
                //一回休み
                if (RuleCreate.instance.playerNum[count] == 1)
                {
                    if (BukanDraw.instance.clockWise == true)
                    {
                        int i = count + 1;
                        i %= 4;
                        draw.playerBreak[i] = true;
                        draw.playerSkip[i].sprite = Resources.Load<Sprite>("Images/Skip");
                    }
                    else
                    {
                        int i = count - 1;
                        if (i < 0)
                        {
                            i = 3;
                        }
                        draw.playerBreak[i] = true;
                        draw.playerSkip[i].sprite = Resources.Load<Sprite>("Images/Skip");
                    }
                }
                else
                {
                    if (BukanDraw.instance.clockWise == true)
                    {
                        int i = count + 1;
                        i %= 4;
                        draw.playerBreak[i] = true;
                        draw.playerSkip[i].sprite = Resources.Load<Sprite>("Images/Skip");
                        i++;
                        i %= 4;
                        draw.playerBreak[i] = true;
                        draw.playerSkip[i].sprite = Resources.Load<Sprite>("Images/Skip");
                    }
                    else
                    {
                        int i = count - 1;
                        if (i < 0)
                        {
                            i = 3;
                        }
                        draw.playerBreak[i] = true;
                        draw.playerSkip[i].sprite = Resources.Load<Sprite>("Images/Skip");
                        i--;
                        if (i < 0)
                        {
                            i = 3;
                        }
                        draw.playerBreak[i] = true;
                        draw.playerSkip[i].sprite = Resources.Load<Sprite>("Images/Skip");
                    }
                }

                cardAnime.animeFunctionNum = 16;
                cardAnime.AnimeSkillCutIn();
                break;

            case 5:
                //逆回り
                BukanDraw.instance.clockWise = !BukanDraw.instance.clockWise;
                cardAnime.animeFunctionNum = 17;
                cardAnime.AnimeSkillCutIn();
                break;

            case 6:
                //効果無効
                draw.ruleBreak = true;
                cardAnime.animeFunctionNum = 18;
                cardAnime.AnimeSkillCutIn();
                break;
        }
    }

    //n枚みんなからもらう
    public void SomeoneToMe()
    {
        int j = somePlayer;

        //全員からN枚もらえる
        for (int i = count; i < j + count + 1; i++)
        {
            int k = i % 4;
            if (k != count)
            {
                //N枚以上もってたら
                if (MasterList.instance.list[k].Count > moveNCards)
                {
                    cardN[k] = moveNCards;
                    for (int t = 0; t < moveNCards; t++)
                    {
                        int y = MasterList.instance.list[k][0];//k番目の人の一番上の札を格納
                        MasterList.instance.list[count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                        MasterList.instance.list[k].RemoveAt(0);//k番目の人の札の初期化
                    }
                    Debug.Log(k + 1 + "番の人が" + (count + 1) + "番目の人に" + moveNCards + "枚渡す");
                }
                //N枚以下なら
                else
                {
                    cardN[k] = MasterList.instance.list[k].Count;
                    for (int t = 0; t < MasterList.instance.list[k].Count; t++)
                    {
                        int y = MasterList.instance.list[k][0];//k番目の人の一番上の札を格納
                        MasterList.instance.list[count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                        MasterList.instance.list[k].RemoveAt(0);//k番目の人の札の初期化
                    }
                    Debug.Log(k + 1 + "番の人が" + (count + 1) + "番目の人に全部渡す");
                }
            }
            else
            {
                cardN[k] = 0;
            }
        }

    }

    //n枚捨札に置く
    public void DisNCard()
    {
        int j = somePlayer;
        //全員がN枚捨てる
        for (int i = count; i < j + count + 1; i++)
        {
            int k = i % 4;
            if (k != count)
            {
                //1枚でも持っていたら
                if (MasterList.instance.list[k].Count > moveNCards)
                {
                    cardN[k] = moveNCards;
                    for (int f = 0; f < moveNCards; f++)
                    {
                        int v = MasterList.instance.list[k][0];
                        deck.DiscardCount.Add(v);
                        MasterList.instance.list[k].RemoveAt(0);
                    }
                    //deck.DiscardCount += moveNCards;//N枚を捨て札に加算
                    //hand.handCount[k] -= moveNCards;//手札からN枚捨てる
                    Debug.Log(k + 1 + "番の人が" + moveNCards + "枚捨てる");
                }
                else
                {
                    cardN[k] = moveNCards;
                    for (int f = 0; f < MasterList.instance.list[k].Count; f++)
                    {
                        int v = MasterList.instance.list[k][0];
                        deck.DiscardCount.Add(v);
                        MasterList.instance.list[k].RemoveAt(0);
                    }
                    //deck.DiscardCount += hand.handCount[count];//手札をすべて捨て札に加算
                    //hand.handCount[count] = 0;//手札を初期化
                    Debug.Log(k + 1 + "番の人が全部捨てる");
                }
            }
            else
            {
                cardN[k] = 0;
            }
        }
    }

    //n枚山札から引く
    public void DrawnNCards()
    {
        draw.drawAgain = true;
        int j = moveNCards;

        if (draw.drowYama1 == true)
        {
            //山札からj枚引く
            for (int i = 1; i < j; i++)
            {
                //deck.drawcard = deck.cards1[0];//いらないかも
                MasterList.instance.list[count].Add(deck.drawcard);//手札に追加
                deck.cards1.RemoveAt(0);
            }
        }
        else
        {
            //山札から2枚引く
            for (int i = 1; i < j; i++)
            {
                //deck.drawcard = deck.cards2[0];//いらないかも
                MasterList.instance.list[count].Add(deck.drawcard);//手札に追加;
                deck.cards2.RemoveAt(0);
            }
        }
    }

    private void CardNull()
    {
        cardN[0] = 0;
        cardN[1] = 0;
        cardN[2] = 0;
        cardN[3] = 0;
    }
}
