using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YumimotiDraw : SingletonMonoBehaviour<YumimotiDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    public void Yumimoti_Draw()
    {
        Debug.Log(deck.Count + "のばん");
        //スキル有り無し
        //if ()
        //    else { }


        //左隣からカードを5枚
        //if (deck.Count == 0)
        //{
        //    //5枚以上あるか確認
        //    if (hand.handCount[3] > 5)
        //    {
        //        hand.handCount[deck.Count] += 5;
        //        hand.handCount[3] -= 5;
        //    }
        //    else
        //    {
        //        hand.handCount[deck.Count] += hand.handCount[3];
        //        hand.handCount[3] = 0;
        //    }
        //}
        //else
        //{

        //int u = (deck.Count+1 )% 4;//余り
        int r = 1;
        for (int w = 0; w < 4; w++)
        {
            if (MasterList.Instance.list[(deck.Count + r) % 4].Count != 0)
            {
                int u = (deck.Count + 1) % 4;//余り
                if (MasterList.Instance.list[u].Count > 5)
                {
                    for (int t = 0; t < 5; t++)
                    {
                        int y = MasterList.Instance.list[u][0];//次の人の一番上の札を格納
                        MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                        MasterList.Instance.list[u].RemoveAt(0);//i番目の人の札の初期化
                    }
                }
                else if (MasterList.Instance.list[u].Count > 0)
                {
                    for (int t = 0; t < MasterList.Instance.list[u].Count; t++)
                    {
                        int y = MasterList.Instance.list[u][0];//i番目の人の一番上の札を格納
                        MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                        MasterList.Instance.list[u].RemoveAt(0);//i番目の人の札の初期化
                    }
                }break;
            }
        }


        //Count-1の人から5枚もらう
        //if (hand.handCount[deck.Count - 1] > 5)
        //{
        //    hand.handCount[deck.Count] += 5;
        //    hand.handCount[deck.Count - 1] -= 5;
        //}
        //else
        //{
        //    hand.handCount[deck.Count] += hand.handCount[deck.Count - 1];
        //    hand.handCount[deck.Count - 1] = 0;
        //}
        //}
        Debug.Log("弓持ちのスキル発動");

        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
    }
}
