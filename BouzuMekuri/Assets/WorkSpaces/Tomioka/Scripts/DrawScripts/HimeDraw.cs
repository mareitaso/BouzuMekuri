using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HimeDraw : SingletonMonoBehaviour<HimeDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
<<<<<<< .merge_file_a21288
    private HandCount hand;
    [SerializeField]
    private Test test;
=======
    private Draw draw;
>>>>>>> .merge_file_a14256
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
<<<<<<< .merge_file_a21288
                MasterList.Instance.list[deck.Count].Add(y);//捨て札を回収
                deck.DiscardCount.RemoveAt(0);//捨て札を初期化
            }
            MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            //test.ImageChangeHime();
=======
                MasterList.instance.list[deck.Count].Add(y);//捨て札を回収
                deck.DiscardCount.RemoveAt(0);//捨て札を初期化
            }
            MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            cardAnime.movePlace = deck.Count;
            //draw.ImageChangeHime();
>>>>>>> .merge_file_a14256
            cardAnime.AnimeHime();

        }
        //捨て札がないので山から1枚引いて効果発動
        else
        {
<<<<<<< .merge_file_a21288
            test.drawAgain = true;
            MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            //test.ImageChangeHime();
            cardAnime.AnimeTono();
            
            //deck.cards1.RemoveAt(0);//0番目を削除

            //if (test.drowYama1 == true)
            //{
            //    test.Draw1();
=======
            draw.drawAgain = true;
            MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
            cardAnime.movePlace = deck.Count;
            //draw.ImageChangeHime();
            cardAnime.AnimeOneDraw();
            
            //deck.cards1.RemoveAt(0);//0番目を削除

            //if (draw.drowYama1 == true)
            //{
            //    draw.Draw1();
>>>>>>> .merge_file_a14256
            //    deck.Count--;
            //}
            //else
            //{
<<<<<<< .merge_file_a21288
            //    test.Draw2();
=======
            //    draw.Draw2();
>>>>>>> .merge_file_a14256
            //    deck.Count--;
            //}
        }
    }
}
