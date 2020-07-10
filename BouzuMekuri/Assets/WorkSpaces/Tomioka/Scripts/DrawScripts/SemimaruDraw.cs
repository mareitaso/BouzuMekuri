using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemimaruDraw : SingletonMonoBehaviour<SemimaruDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;

    //現状のカードの総数
    private int allYamahuda;
    //捨てる札の総数
    private int allSutehuda;

    //それぞれ山札から捨てる枚数
    private int halfYamahuda1;
    private int halfYamahuda2 = 1;

    public void Semimaru_Draw()
    {
        hand.handCount[deck.Count] += 1;//手札に追加

        //山札の半分を場に置く
        allYamahuda = deck.cards1.Count + deck.cards2.Count - 1;

        //繰り下げになってるはず
        allSutehuda = allYamahuda / 2;

        halfYamahuda1 = allSutehuda / 2;
        halfYamahuda2 = allSutehuda / 2;



        Debug.Log("残りの山札は" + allYamahuda + "枚です");

        Debug.Log("捨てるカードの合計は" + allSutehuda + "枚です");

        Debug.Log("山札は1は" + halfYamahuda1 + "枚捨てる");
        Debug.Log("山札は2は" + halfYamahuda2 + "枚捨てる");

        if (deck.cards1.Count <= 1 && deck.cards2.Count <= 1)
        {
            //ないもない
            Debug.Log("何もおきなかった");
        }
        else
        {
            //捨てるカードのほうが大きいなら
            if (deck.cards1.Count < halfYamahuda1)
            {
                if (deck.cards1.Count == 1)
                {
                    halfYamahuda2 += halfYamahuda1 - deck.cards1.Count + 1;
                    halfYamahuda1 = 0;
                }
                else
                {
                    halfYamahuda2 += halfYamahuda1 - deck.cards1.Count;
                    halfYamahuda1 = deck.cards1.Count;
                }
            }
            if (deck.cards2.Count < halfYamahuda2)
            {
                if (deck.cards2.Count == 1)
                {
                    halfYamahuda1 += halfYamahuda2 - deck.cards2.Count;
                    halfYamahuda2 = 0;
                }
                else
                {
                    halfYamahuda1 += halfYamahuda2 - deck.cards2.Count;
                    halfYamahuda2 = deck.cards2.Count;
                }
            }

            Debug.Log("山札は1は" + halfYamahuda1 + "枚捨てる");
            Debug.Log("山札は2は" + halfYamahuda2 + "枚捨てる");


            for (int i = 0; i < halfYamahuda1; i++)
            {
                int q = deck.cards1[0];
                deck.DiscardCount.Add(q);
                deck.cards1.RemoveAt(0);//0番目を削除
            }
            for (int i = 0; i < halfYamahuda2; i++)
            {
                int g = deck.cards2[0];
                deck.DiscardCount.Add(g);
                deck.cards2.RemoveAt(0);//0番目を削除
            }

        }

        test.ImageChangeTono();
        test.ImageChangeSemimaru();
        //deck.DiscardCount

    }
}
