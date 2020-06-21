using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    /*
    //富岡編集
    [SerializeField]
    private Image Yamahuda;
    [SerializeField]
    private Image Sutehuda;
    [SerializeField]
    private List<Image> Player;
    */

    public int drawcard;//引いたカード
    public int DiscardCount;//捨て札の枚数
    [SerializeField]
    public List<int> cards1, cards2;//リストの宣言
    public int Count;//ターンのカウント

    public HandCount hand;
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

        for (int i = 0; i < 100; i++)
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
    /*
    public void Draw()
    {
        if (Count <= 3)//4人(仮)
        {
            if (cards.Count > 0)//山札があるとき
            {
                drawcard = cards[0];//0番目を引いたカードとして登録
                Yamahuda.sprite = Resources.Load<Sprite>("Images/Cards" + drawcard);
                if (drawcard < 12)
                {
                    Debug.Log("坊主" + Count + "のばん");
                    hand.handCount[Count] += 1;
                    DiscardCount += hand.handCount[Count];//手札を捨て札に加算
                    hand.handCount[Count] = 0;//手札を初期化
                    ImageChangeBouzu();
                }
                else if (drawcard < 33)
                {
                    Debug.Log("姫" + Count + "のばん");
                    if (DiscardCount > 0)
                    {
                        hand.handCount[Count] += DiscardCount;//捨て札を回収
                        DiscardCount = 0;//捨て札を初期化
                        hand.handCount[Count] += 1;
                        ImageChangeHime();
                    }
                    else
                    {
                        hand.handCount[Count] += 1;
                        ImageChangeHime();
                    }
                }
                else
                {
                    Debug.Log("殿" + Count + "のばん");
                    hand.handCount[Count] += 1;//手札に追加
                    ImageChangeTono();
                }
                cards.RemoveAt(0);//0番目を削除
                Count++;
                if (Count == 4)
                {
                    Count = 0;
                }
            }
            else
            {
                Yamahuda.sprite = null;
                Debug.LogError("終わり");
                ImageChangeTono();
                hand.Settlement();
            }
        }
    }

    private void ImageChangeTono()
    {
        Player[Count].sprite = Resources.Load<Sprite>("Images/Cards" + drawcard);
    }
    private void ImageChangeHime()
    {
        Player[Count].sprite = Resources.Load<Sprite>("Images/Cards" + drawcard);
        Sutehuda.sprite = null;
    }

    private void ImageChangeBouzu()
    {
        Player[Count].sprite = null;
        Sutehuda.sprite = Resources.Load<Sprite>("Images/Cards" + drawcard);
    }*/
}
