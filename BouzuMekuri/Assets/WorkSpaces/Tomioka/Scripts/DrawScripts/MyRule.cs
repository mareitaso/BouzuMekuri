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
                if (MasterList.Instance.list[k].Count > moveNCards)
                {
                    for (int t = 0; t < moveNCards; t++)
                    {
                        int y = MasterList.Instance.list[k][0];//k番目の人の一番上の札を格納
                        MasterList.Instance.list[deck.Count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                        MasterList.Instance.list[k].RemoveAt(0);//k番目の人の札の初期化
                    }
                    Debug.Log(k + 1 + "番の人が" + (deck.Count + 1) + "番目の人に" + moveNCards + "枚渡す");
                }
                //N枚以下なら
                else
                {
                    for (int t = 0; t < MasterList.Instance.list[k].Count; t++)
                    {
                        int y = MasterList.Instance.list[k][0];//k番目の人の一番上の札を格納
                        MasterList.Instance.list[deck.Count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                        MasterList.Instance.list[k].RemoveAt(0);//k番目の人の札の初期化
                    }
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
                if (MasterList.Instance.list[k].Count > moveNCards)
                {
                    for(int f = 0; f < moveNCards; f++)
                    {
                        int v = MasterList.Instance.list[k][0];
                        deck.DiscardCount.Add(v);
                        MasterList.Instance.list[k].RemoveAt(0);
                    }
                    //deck.DiscardCount += moveNCards;//N枚を捨て札に加算
                    //hand.handCount[k] -= moveNCards;//手札からN枚捨てる
                    Debug.Log(k + 1 + "番の人が" + moveNCards + "枚捨てる");
                }
                else
                {
                    for (int f = 0; f < MasterList.Instance.list[k].Count; f++)
                    {
                        int v = MasterList.Instance.list[k][0];
                        deck.DiscardCount.Add(v);
                        MasterList.Instance.list[k].RemoveAt(0);
                    }
                    //deck.DiscardCount += hand.handCount[deck.Count];//手札をすべて捨て札に加算
                    //hand.handCount[deck.Count] = 0;//手札を初期化
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
