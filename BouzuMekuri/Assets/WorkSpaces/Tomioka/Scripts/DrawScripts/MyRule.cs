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
    private int moveNCards = 1;

    //自分のルールの対象人数
    private int somePlayer = 1;


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
        if (Input.GetKeyDown(KeyCode.D))
        {
            deck.cards1[0] = 100;
            deck.cards2[0] = 100;
        }
    }

    //n枚みんなからもらう
    public void SomeoneToMe()
    {
        int j = somePlayer;

        //全員からN枚もらえる
        for (int i = deck.Count; i < j + deck.Count + 1; i++)
        {
            int k = i % 4;
            if (k != deck.Count)
            {
                //N枚以上もってたら
                if (hand.handCount[k] > moveNCards)
                {
                    hand.handCount[deck.Count] += moveNCards;
                    hand.handCount[k] -= moveNCards;
                    Debug.Log(k + 1 + "番の人が" + (deck.Count + 1) + "番目の人に" + moveNCards + "枚渡す");
                }
                //N枚以下なら
                else
                {
                    hand.handCount[deck.Count] += hand.handCount[k];
                    hand.handCount[k] = 0;
                    Debug.Log(k + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
                }
            }
        }


    }

    //n枚捨札に置く
    public void DisNCard()
    {
        int j = somePlayer;
        //全員がN枚捨てる
        for (int i = deck.Count; i < j + deck.Count + 1; i++)
        {
            int k = i % 4;
            if (k != deck.Count)
            {
                //1枚でも持っていたら
                if (hand.handCount[k] > moveNCards)
                {
                    deck.DiscardCount += moveNCards;//N枚を捨て札に加算
                    hand.handCount[k] -= moveNCards;//手札からN枚捨てる
                    Debug.Log(k + 1 + "番の人が" + moveNCards + "枚捨てる");
                }
                else
                {
                    deck.DiscardCount += hand.handCount[deck.Count];//手札をすべて捨て札に加算
                    hand.handCount[deck.Count] = 0;//手札を初期化
                    Debug.Log(k + 1 + "番の人が全部捨てる");
                }
            }
        }
    }

    //n枚山札から引く
    public void DrawnNCards()
    {

    }



}
