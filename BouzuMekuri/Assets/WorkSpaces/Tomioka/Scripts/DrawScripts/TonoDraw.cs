using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonoDraw : SingletonMonoBehaviour<TonoDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;

    //殿を引いた処理
    public void Tono_Draw()
    {
        Debug.Log("殿" + deck.Count + "のばん");
        hand.handCount[deck.Count] += 1;//手札に追加
        test.ImageChangeTono();
    }

}
