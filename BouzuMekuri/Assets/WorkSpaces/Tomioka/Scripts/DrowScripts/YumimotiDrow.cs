using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YumimotiDrow : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    public void Yumimoti_Drow() 
    {
        //左隣からカードを5枚
        if (deck.Count == 0)
        {
            //5枚以上あるか確認
            if (hand.handCount[3] > 5)
            {
                hand.handCount[deck.Count] += 5;
                hand.handCount[3] -= 5;
            }
            else
            {
                hand.handCount[deck.Count] += hand.handCount[3];
                hand.handCount[3] = 0;
            }
        }
        else
        {
            //Count-1の人から5枚もらう
            if (hand.handCount[deck.Count - 1] > 5)
            {
                hand.handCount[deck.Count] += 5;
                hand.handCount[deck.Count - 1] -= 5;
            }
            else
            {
                hand.handCount[deck.Count] += hand.handCount[deck.Count - 1];
                hand.handCount[deck.Count - 1] = 0;
            }
        }
        Debug.Log("弓持ちのスキル発動");

    }
}
