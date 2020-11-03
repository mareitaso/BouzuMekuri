using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDraw : SingletonMonoBehaviour<NormalDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;
    [SerializeField]
    private CardAnimation cardAnime;


    //殿を引いた処理
    public void Tono_Draw()
    {
        Debug.Log("殿" + deck.Count + "のばん");
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        cardAnime.movePlace = deck.Count;
        cardAnime.AnimeTono();
    }


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
                MasterList.instance.list[deck.Count].Add(y);//捨て札を回収
                deck.DiscardCount.RemoveAt(0);//捨て札を初期化
            }
            MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            cardAnime.movePlace = deck.Count;
            //draw.ImageChangeHime();
            cardAnime.AnimeHime();

        }
        //捨て札がないので山から1枚引いて効果発動
        else
        {
            draw.drawAgain = true;
            MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            cardAnime.movePlace = deck.Count;
            //draw.ImageChangeHime();
            cardAnime.AnimeOneDraw();
        }
    }


    //坊主を引いた処理
    public void Bouzu_Draw()
    {
        Debug.Log("坊主" + deck.Count + "のばん");

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
        cardAnime.AnimeBouzu();
    }
}
