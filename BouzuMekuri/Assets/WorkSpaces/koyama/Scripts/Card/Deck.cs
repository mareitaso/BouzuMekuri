using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int drawcard;//引いたカード
    public List<int> DiscardCount;//捨て札のリスト
    [SerializeField]
    public List<int> cards1, cards2;//リストの宣言
    public int Count;//ターンのカウント

    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards1)//cardsの要素
        {
            yield return i;//要素を戻り値に返す
        }
        foreach (int i in cards2)//cardsの要素
        {
            yield return i;//要素を戻り値に返す
        }
    }

    public void Shuffle()
    {
        if (cards1 == null)
        {
            cards1 = new List<int>();//初期化
        }
        else
        {
            cards1.Clear();//cardsを空にする
        }

        //α版のため計100枚に変更
        for (int i = 1; i < 101; i++)
        {
            cards1.Add(i);
        }

        int n = cards1.Count;//nの初期値はカードの枚数
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);//
            int temp = cards1[k];//k番目のカードをtempに追加
            cards1[k] = cards1[n];
            cards1[n] = temp;
        }

        if (cards2 == null)
        {
            cards2 = new List<int>();//初期化
        }
        else
        {
            cards2.Clear();//cardsを空にする
        }

        //α版のため50枚に変更
        for (int i = 0; i < 50; i++)
        {
            cards2.Add(cards1[i]);
            cards1.RemoveAt(i);
        }
    }
    private void Awake()
    {
        Shuffle();//実行
    }
}
