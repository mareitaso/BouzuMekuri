using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    CardDataBase cardDataBase;

    //富岡編集
    [SerializeField]
    private Image Yamahuda;
    [SerializeField]
    private Image Sutehuda;
    [SerializeField]
    private List<Image> Player;

    private int drawcard;//引いたカード
    public int DiscardCount;//捨て札の枚数
    //[SerializeField]
    //List<int> Playerhand = new List<int>();
    [SerializeField]
    List<int> cards;//リストの宣言
    public int Count;

    public HandCount hand;
    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)//cardsの要素
        {
            yield return i;//要素を戻り値に返す
        }
    }

    public void Shuffle()
    {
        if (cards == null)
        {
            cards = new List<int>();//初期化
        }
        else
        {
            cards.Clear();//cardsを空にする
        }

        for (int i = 0; i < 100; i++)
        {
            cards.Add(i);
        }

        int n = cards.Count;//nの初期値はカードの枚数
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);//
            int temp = cards[k];//k番目のカードをtempに追加
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }
    private void Start()
    {
        Shuffle();//実行

        for (int i = 0; i < 100; i++)
        {
            Debug.Log(cardDataBase.YamahudaLists()[i].GetFirstJob());
        }
    }


}
