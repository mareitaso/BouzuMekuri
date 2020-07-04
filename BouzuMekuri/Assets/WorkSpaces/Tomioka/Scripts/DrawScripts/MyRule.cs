using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRule : SingletonMonoBehaviour<MyRule>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    //自分のルールのカードの枚数
    private int moveNCards;

    //自分のルールの対象人数
    private int somePlayer;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            somePlayer = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            somePlayer = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            somePlayer = 3;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            moveNCards = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            moveNCards = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            moveNCards = 3;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            moveNCards = 4;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            moveNCards = 5;
        }
    }

    //n枚みんなからもらう
    public void SomeoneToMe()
    {
        //全員からN枚もらえる
        for (int i = 0; i < somePlayer + 1; i++)
        {
            if (i != deck.Count)
            {
                //N枚以上もってたら
                if (hand.handCount[i] > moveNCards)
                {
                    Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に1枚渡す");
                    hand.handCount[deck.Count] += moveNCards;
                    hand.handCount[i] -= moveNCards;
                }
                //N枚以下なら
                else
                {
                    hand.handCount[deck.Count] += hand.handCount[i];
                    hand.handCount[i] = 0;
                }
            }
        }


    }

    //n枚捨札に置く
    public void DisNCard()
    {
        //全員がN枚捨てる
        for (int i = 0; i < 4; i++)
        {
            if (i != deck.Count)
            {
                //1枚でも持っていたら
                if (hand.handCount[i] > moveNCards)
                {
                    deck.DiscardCount += moveNCards;//N枚を捨て札に加算
                    hand.handCount[i] -= moveNCards;//手札からN枚捨てる
                }
                else
                {
                    deck.DiscardCount += hand.handCount[deck.Count];//手札をすべて捨て札に加算
                    hand.handCount[deck.Count] = 0;//手札を初期化
                }
            }
        }
    }

    //n枚山札から引く
    public void DrawnNCards()
    {

    }
}
