using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonoDraw : SingletonMonoBehaviour<TonoDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;
    [SerializeField]
    CardAnimation cardAnime;

    //殿を引いた処理
    public void Tono_Draw()
    {
        Debug.Log("殿" + deck.Count + "のばん");
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        cardAnime.movePlace = deck.Count;
        cardAnime.AnimeTono();
    }

}
