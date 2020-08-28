using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonoDraw : SingletonMonoBehaviour<TonoDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
<<<<<<< .merge_file_a12296
    private HandCount hand;
    [SerializeField]
    private Test test;
=======
    private Draw draw;
>>>>>>> .merge_file_a19944
    [SerializeField]
    CardAnimation cardAnime;

    //殿を引いた処理
    public void Tono_Draw()
    {
        Debug.Log("殿" + deck.Count + "のばん");
<<<<<<< .merge_file_a12296
        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        //test.ImageChangeTono();
=======
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        cardAnime.movePlace = deck.Count;
>>>>>>> .merge_file_a19944
        cardAnime.AnimeTono();
    }

}
