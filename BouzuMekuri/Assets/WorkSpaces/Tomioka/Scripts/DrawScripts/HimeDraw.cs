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
    [SerializeField]
    private CardAnimation cardAnime;

    //姫を引いた処理
    public void Hime_Draw()
    {
        Debug.Log("姫" + deck.Count + "のばん");
        //捨て札がある場合
        if (deck.DiscardCount.Count > 0)
        {
            Debug.Log(deck.DiscardCount.Count);
            int r = deck.DiscardCount.Count;
            for (int t = 0; t < r; t++)
            {
                Debug.Log(deck.DiscardCount[0]);
                Debug.Log(deck.DiscardCount[0]);
                int y = deck.DiscardCount[0];//捨て札を格納
                MasterList.Instance.list[deck.Count].Add(y);//捨て札を回収
                deck.DiscardCount.RemoveAt(0);//捨て札を初期化
            }
            MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            //test.ImageChangeHime();
            cardAnime.AnimeHime();

        }
        //捨て札がないので山から1枚引いて効果発動
        else
        {
            test.drawAgain = true;
            MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            //test.ImageChangeHime();
            cardAnime.AnimeYamaToPlayer();
            
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
