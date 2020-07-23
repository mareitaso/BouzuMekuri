using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonoDraw : SingletonMonoBehaviour<TonoDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;
    [SerializeField]
    CardAnimation cardAnime;

    //殿を引いた処理
    public void Tono_Draw()
    {
        Debug.Log("殿" + deck.Count + "のばん");
        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        //test.ImageChangeTono();
        cardAnime.AnimeYamaToPlayer();
    }

}
