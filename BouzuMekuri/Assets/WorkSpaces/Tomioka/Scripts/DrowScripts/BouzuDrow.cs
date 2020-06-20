using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouzuDraw : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    //坊主を引いた処理
    public void Bouzu_Draw()
    {
        Debug.Log("坊主" + deck.Count + "のばん");
        hand.handCount[deck.Count] += 1;
        deck.DiscardCount += hand.handCount[deck.Count];//手札を捨て札に加算
        hand.handCount[deck.Count] = 0;//手札を初期化
        ImageChangeBouzu();
    }
}
