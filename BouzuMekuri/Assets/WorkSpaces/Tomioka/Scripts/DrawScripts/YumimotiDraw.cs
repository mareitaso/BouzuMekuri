using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YumimotiDraw : SingletonMonoBehaviour<YumimotiDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private CardAnimation cardAnime;

    [HideInInspector]
    public int YumimotiNum;

    public void Yumimoti_Draw()
    {

        Debug.Log("弓持ち" + deck.Count + "のばん");

        int g = deck.Count + 1;
        for (int w = 0; w < 4; w++)
        {
            g %= 4;
            if (MasterList.Instance.list[g].Count != 0)
            {
                if (MasterList.Instance.list[g].Count > 5)
                {
                    for (int t = 0; t < 5; t++)
                    {
                        int y = MasterList.Instance.list[g][0];//次の人の一番上の札を格納
                        MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                        MasterList.Instance.list[g].RemoveAt(0);//i番目の人の札の初期化
                    }
                }
                else if (MasterList.Instance.list[g].Count > 0)
                {
                    int m = MasterList.Instance.list[g].Count;
                    for (int t = 0; t < m; t++)
                    {
                        int y = MasterList.Instance.list[g][0];//i番目の人の一番上の札を格納
                        MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                        MasterList.Instance.list[g].RemoveAt(0);//i番目の人の札の初期化
                    }
                }
                YumimotiNum = g;
                break;
            }
            g++;
            g %= 4;
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

        cardAnime.AnimeLeftToRight();
        Debug.Log("最終的にカードを渡す人は" + (YumimotiNum + 1) + "→" + (deck.Count + 1));
        Debug.Log("弓持ちのスキル発動");

        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
    }
}
