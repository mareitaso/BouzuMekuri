using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    List<int> cards;//リストの宣言
    private int drawcard;//引いたカード
    public int handCount;//手札の枚数
    public int DiscardCount;//捨て札の枚数
    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)//cardsの要素
        {
            yield return i;//要素を戻り値に返す
        }
    }

    public void Shuffle()
    {
        if(cards == null)
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
    }
    public void Draw()
    {
        if(cards.Count > 0)
        {
            drawcard = cards[0];//0番目を引いたカードとして登録
            if(drawcard< 11)
            {
                Debug.Log("坊主");
                handCount++;
                DiscardCount+= handCount;//手札を捨て札に加算
                handCount = 0;//手札を初期化
            }else if(drawcard < 32)
            {
                Debug.Log("姫");
                if (DiscardCount > 0)
                {
                    handCount += DiscardCount;//捨て札を回収
                    handCount++;
                    DiscardCount = 0;//捨て札を初期化

                }
                else
                {
                    handCount++;
                }
            }
            else
            {
                Debug.Log("殿");
                handCount++;//手札に追加
            }
            cards.RemoveAt(0);//0番目を削除
        }
        else
        {
            Debug.LogError("終わり");
        }
    }
}
