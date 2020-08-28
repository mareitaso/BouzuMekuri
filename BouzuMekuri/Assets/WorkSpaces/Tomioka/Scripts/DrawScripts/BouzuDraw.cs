using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouzuDraw : SingletonMonoBehaviour<BouzuDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
<<<<<<< .merge_file_a15480
    private HandCount hand;
    [SerializeField]
    private Test test;
=======
    private Draw draw;
>>>>>>> .merge_file_a06244
    [SerializeField]
    private CardAnimation cardAnime;

    //坊主を引いた処理
    public void Bouzu_Draw()
    {
        Debug.Log("坊主" + deck.Count + "のばん");

<<<<<<< .merge_file_a15480
        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加

        int e = MasterList.Instance.list[deck.Count].Count;
        //手札を捨て札に加算
        for (int t = 0; t < e; t++)
        {
            int y = MasterList.Instance.list[deck.Count][0];
            deck.DiscardCount.Add(y);
            MasterList.Instance.list[deck.Count].RemoveAt(0);
        }

        MasterList.Instance.list[deck.Count].Clear();//手札を初期化
        //test.ImageChangeBouzu();
=======
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加

        int e = MasterList.instance.list[deck.Count].Count;
        //手札を捨て札に加算
        for (int t = 0; t < e; t++)
        {
            int y = MasterList.instance.list[deck.Count][0];
            deck.DiscardCount.Add(y);
            MasterList.instance.list[deck.Count].RemoveAt(0);
        }

        MasterList.instance.list[deck.Count].Clear();//手札を初期化
        cardAnime.movePlace = deck.Count;
>>>>>>> .merge_file_a06244
        cardAnime.AnimeBouzu();
    }
}
