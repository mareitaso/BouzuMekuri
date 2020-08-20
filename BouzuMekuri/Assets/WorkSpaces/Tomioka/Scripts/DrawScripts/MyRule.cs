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

    //カードの種類(天皇・段付き・武官・弓持ち・偉い姫の順)
    public List<int> cardType;
    //カードの効果(何枚引く等)
    public List<int> cardEffect;
    //スキルの対象枚数
    public List<int> cardNum;
    //スキルの対象人数
    public List<int> playerNum;

    //自分のルールのカードの枚数
    private int moveNCards = 1;

    //自分のルールの対象人数
    private int somePlayer = 1;

    private int count;


    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    somePlayer = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    somePlayer = 2;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    somePlayer = 3;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    moveNCards = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    moveNCards = 2;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad3))
        //{
        //    moveNCards = 3;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad4))
        //{
        //    moveNCards = 4;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad5))
        //{
        //    moveNCards = 5;
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    deck.cards1[0] = 100;
        //    deck.cards2[0] = 100;
        //}
    }

    public void CardTypeCheck()
    {
        count = deck.Count;

        //天皇を引く
        if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou && cardType[count] == 1)
        {
            CardEffectCheck();
        }
        //段付きを引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki && cardType[count] == 2)
        {
            CardEffectCheck();
        }

        //武官を引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan && cardType[count] == 3)
        {
            CardEffectCheck();
        }

        //弓持ちを引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti && cardType[count] == 4)
        {
            CardEffectCheck();
        }

        //偉い姫を引く
        else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.GreatHime && cardType[count] == 5)
        {
            CardEffectCheck();
        }
        else
        {
            Debug.LogError(deck.drawcard);
            Debug.LogError(cardType[count]);
            Debug.LogError("この人の自作ルールがおかしい");
        }
    }

    private void CardEffectCheck()
    {
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        switch (cardEffect[count])
        {
            case 1:
                //カードをもらう
                moveNCards = cardNum[count];
                somePlayer = playerNum[count];
                SomeoneToMe();
                break;

            case 2:
                //カードを引く
                moveNCards = cardNum[count];
                somePlayer = playerNum[count];
                DrawnNCards();
                break;

            case 3:
                //場に置く
                moveNCards = cardNum[count];
                somePlayer = playerNum[count];
                DisNCard();
                break;

            case 4:
                //一回休み
                if (playerNum[count] == 1)
                {
                    int i = count + 1;
                    i %= 4;
                    draw.playerBreak[i] = true;
                }
                else
                {
                    int i = count + 1;
                    i %= 4;
                    draw.playerBreak[i] = true;
                    i++;
                    i %= 4;
                    draw.playerBreak[i] = true;
                }
                break;

            case 5:
                //逆回り
                BukanDraw.instance.clockWise = !BukanDraw.instance.clockWise;
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
                    for (int t = 0; t < MasterList.instance.list[k].Count; t++)
                    {
                        int y = MasterList.instance.list[k][0];//k番目の人の一番上の札を格納
                        MasterList.instance.list[count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                        MasterList.instance.list[k].RemoveAt(0);//k番目の人の札の初期化
                    }
                    Debug.Log(k + 1 + "番の人が" + (count + 1) + "番目の人に全部渡す");
                }
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
        }
    }

    //n枚山札から引く
    public void DrawnNCards()
    {
        int j = moveNCards;

        if (draw.drowYama1 == true)
        {
            //山札からj枚引く
            for (int i = 0; i < j; i++)
            {
                deck.drawcard = deck.cards1[0];//いらないかも
                MasterList.instance.list[count].Add(deck.drawcard);//手札に追加
                deck.cards1.RemoveAt(0);
            }
        }
        else
        {
            //山札から2枚引く
            for (int i = 0; i < j; i++)
            {
                deck.drawcard = deck.cards2[0];//いらないかも
                MasterList.instance.list[count].Add(deck.drawcard);//手札に追加;
                deck.cards2.RemoveAt(0);
            }
        }
    }



}
