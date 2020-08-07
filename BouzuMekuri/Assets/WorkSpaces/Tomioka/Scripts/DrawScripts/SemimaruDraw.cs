using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemimaruDraw : SingletonMonoBehaviour<SemimaruDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;
    [SerializeField]
    private CardAnimation cardAnime;

    //現状のカードの総数
    //private int allYamahuda;
    //捨てる札の総数
    private int allSutehuda;

    //それぞれ山札から捨てる枚数
    public int halfYamahuda1;
    public int halfYamahuda2;

    public void Semimaru_Draw()
    {
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加

        halfYamahuda1 = deck.cards1.Count / 2;
        halfYamahuda2 = deck.cards2.Count / 2;

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
                    halfYamahuda2 += halfYamahuda1 - deck.cards1.Count;
                    halfYamahuda1 = 0;
                }
                else
                {
                    halfYamahuda2 += halfYamahuda1 - deck.cards1.Count + 1;
                    halfYamahuda1 = deck.cards1.Count - 1;
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
                    halfYamahuda1 += halfYamahuda2 - deck.cards2.Count + 1;
                    halfYamahuda2 = deck.cards2.Count - 1;
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
        cardAnime.animeFunctionNum = 7;
        cardAnime.AnimeSkillCutIn();
    }

    //坊主として扱う
    private void SemimaruSkill1()
    {
        BouzuDraw.instance.Bouzu_Draw();
    }

    //1回休み
    private void SemimaruSkill2()
    {

    }

    //自分の手札に関係なく最下位になる
    private void SemimaruSkill3()
    {

    }

    //他のプレイヤーの全ての手札を自分の手札に加える
    private void SemimaruSkill4()
    {
        for (int i = 0; i < 4; i++)
        {
            //全員の札をもらう
            if (i != deck.Count)
            {
                Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
                for (int t = 0; t < MasterList.instance.list[i].Count; t++)
                {
                    int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                    MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                    MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                }
            }
        }
    }

    //他のプレイヤーは全ての手札を捨て札に置く
    private void SemimaruSkill5()
    {
        for (int i = 0; i < 4; i++)
        {
            //全員の札をもらう
            if (i != deck.Count)
            {
                int e = MasterList.instance.list[deck.Count].Count;
                //手札を捨て札に加算
                for (int t = 0; t < e; t++)
                {
                    int y = MasterList.instance.list[deck.Count][0];
                    deck.DiscardCount.Add(y);
                    MasterList.instance.list[deck.Count].RemoveAt(0);
                }
            }
        }
    }

    //山札の数を半分にする(半分になるときに山札のCountを-1)
    private void SemimaruSkill6()
    {
        //上に書いてあるやつ
    }

    //次に発動するスキルを無効化する
    private void SemimaruSkill7()
    {

    }
}
