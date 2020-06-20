using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HimeDraw : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    //姫を引いた処理
    public void Hime_Draw()
    {
        Debug.Log("姫" + deck.Count + "のばん");
        //捨て札がある場合
        if (deck.DiscardCount > 0)
        {
            hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
            deck.DiscardCount = 0;//捨て札を初期化
            hand.handCount[deck.Count] += 1;
            ImageChangeHime();
        }
        //捨て札がないので山から1枚引いて効果発動
        else
        {
            hand.handCount[deck.Count] += 1;
            ImageChangeHime();
        }
    }
}
