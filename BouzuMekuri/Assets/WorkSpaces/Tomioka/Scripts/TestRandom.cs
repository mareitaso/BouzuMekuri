using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TestRandom : MonoBehaviour
{
    private int allNum;

    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;
    [SerializeField]
    private Deck deck;


    public void DivideButton()
    {
        allNum = hand.handCount[0] + hand.handCount[1] + hand.handCount[2] + hand.handCount[3];

        int i = Random.Range(0, allNum);
        int j = Random.Range(0, allNum - i);
        int k = Random.Range(0, allNum - i - j);

        hand.handCount[0] = i;
        hand.handCount[1] = j;
        hand.handCount[2] = k;
        hand.handCount[3] = allNum - i - j - k;

        test.TextChange();
        test.MockShuffle();
    }

    /// <summary>
    /// 自分の手札を全部捨て場に置き
    /// １位のプレイヤーは手札の半分を捨て場に置く
    /// </summary>
    public void PlayerSkill2()
    {
        //プレイヤーの手札全捨て
        deck.DiscardCount += hand.handCount[deck.Count];//手札を捨て札に加算
        hand.handCount[deck.Count] = 0;//手札を初期化

        //最大値を出す
        int j = Mathf.Max(hand.handCount[0], hand.handCount[1], hand.handCount[2], hand.handCount[3]);

        for (int i = 0; i < 4; i++)
        {
            //1札を半分捨てる
            if (j == hand.handCount[i])
            {
                int k = j;
                if (j % 2 == 0)
                {
                    hand.handCount[i] = j / 2;
                    deck.DiscardCount += j / 2;
                }
                else
                {
                    //残る手札を繰り上げ
                    hand.handCount[i] = j / 2 + 1;
                    deck.DiscardCount += j / 2;
                }
            }
        }
        test.TextChange();
        test.MockShuffle();
    }



    /// <summary>
    /// 全てのプレイヤーは最下位と同じ枚数になるように
    /// 捨て場にカードを置く
    /// </summary>
    public void PlayerSkill3()
    {
        //最小値を出す
        int j = Mathf.Min(hand.handCount[0], hand.handCount[1], hand.handCount[2], hand.handCount[3]);


        for (int i = 0; i < 4; i++)
        {
            //最小値じゃない場合、最小値
            if (j != hand.handCount[i])
            {
                int k = hand.handCount[i] - j;
                hand.handCount[i] = j;
                deck.DiscardCount += k;
            }
        }
        test.TextChange();
        test.MockShuffle();
    }
}