using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HimeDraw : SingletonMonoBehaviour<HimeDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;

    //姫を引いた処理
    public void Hime_Draw()
    {
        Debug.Log("姫" + deck.Count + "のばん");
        //捨て札がある場合
        if (deck.DiscardCount > 0)
        {
            hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
            deck.DiscardCount = 0;//捨て札を初期化
            hand.handCount[deck.Count] += 1;//手札に追加
            test.ImageChangeHime();
        }
        //捨て札がないので山から1枚引いて効果発動
        else
        {
            hand.handCount[deck.Count] += 1;//手札に追加
            test.ImageChangeHime();
            //deck.cards1.RemoveAt(0);//0番目を削除

            //if (test.drowYama1 == true)
            //{
            //    test.Draw1();
            //    deck.Count--;
            //}
            //else
            //{
            //    test.Draw2();
            //    deck.Count--;
            //}
        }
    }
}
