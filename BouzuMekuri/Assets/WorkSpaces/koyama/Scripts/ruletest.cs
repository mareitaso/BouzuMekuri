using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ruletest : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    public void Emperor()
    {
        RuleFlag.Instance.Emperor = true;
        RuleFlag.Instance.Emperors = true;

        hand.h();
    }

    public void Button()
    {
        if(RuleFlag.Instance.Emperors = true)
        {
            if(deck.Count<= hand.handCount.Length)//カウントが人数以下だった時
            {
                if (deck.cards.Count > 0)//デッキあり
                {
                    deck.drawcard = deck.cards[0];
                    if (deck.drawcard < 12)
                    {
                        bouzu();
                    }
                    else if (deck.drawcard < 33)
                    {
                        hime();
                    }
                    else
                    {
                        tono();
                    }
                    deck.Count++;
                    deck.cards.RemoveAt(0);
                    if (deck.Count == hand.handCount.Length)
                    {
                        deck.Count = 0;
                    }
                }
                else
                {
                    Debug.LogError("終わり");
                    hand.Settlement();
                }
            }
        }
        else
        {
            Debug.LogError("ルール指定して");
        }
    }

    public void bouzu()
    {
        Debug.Log("坊主" + deck.Count + "のばん");
        hand.handCount[deck.Count] += 1;
        deck.DiscardCount += hand.handCount[deck.Count];//手札を捨て札に加算
        hand.handCount[deck.Count] = 0;//手札を初期化
    }
    public void hime()
    {
        Debug.Log("姫" + deck.Count + "のばん");
        if (deck.DiscardCount > 0)
        {
            hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
            deck.DiscardCount = 0;//捨て札を初期化
            hand.handCount[deck.Count] += 1;
        }
        else
        {
            hand.handCount[deck.Count] += 1;
        }
    }
    public void tono()
    {
        Debug.Log("殿" + deck.Count + "のばん");
        hand.handCount[deck.Count] += 1;//手札に追加
    }
}
