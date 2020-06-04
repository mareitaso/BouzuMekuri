using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    /// <summary>
    /// それぞれのルールを追加
    /// ただしのちに場所を変えpublicにする予定
    /// </summary>
    private bool BukanRule = true;
    //private bool DantukiRule = true;
    private bool TennouRule = true;



    //富岡編集
    [SerializeField]
    private Image Yamahuda;
    [SerializeField]
    private Image Sutehuda;
    [SerializeField]
    private List<Image> Player;

    [SerializeField]
    private bool bukan = true;


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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            bukan = !bukan;
        }
    }

    public void Draw()
    {
        NormalRule();
    }

    private void NormalRule()
    {
        if (Count <= 3)//4人(仮)
        {
            if (cards.Count > 0)//山札があるとき
            {
                drawcard = cards[0];//0番目を引いたカードとして登録
                Yamahuda.sprite = Resources.Load<Sprite>("Images/" + drawcard);
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
                ////武官ルール
                //if (BukanRule == true)
                //{
                //    Bukan();
                //}
                ////天皇ルール
                //if (TennouRule == true)
                //{
                //    Tennou();
                //}
                else
                {
                    Debug.Log("殿" + Count + "のばん");
                    hand.handCount[Count] += 1;//手札に追加
                    ImageChangeTono();
                }
            }
            else
            {
                Yamahuda.sprite = null;
                Debug.LogError("終わり");
                ImageChangeTono();
            }
            cards.RemoveAt(0);//0番目を削除

            ReverseRotation();
        }
    }


    /// <summary>
    /// 回る順番を変える処理
    /// 現状10キーの0で反対になるが
    /// この関数が呼ばれる前にboolを反対にすれば10キーは必要ない
    /// </summary>
    private void ReverseRotation()
    {
        if (bukan == true)
        {
            Count++;
            if (Count == 4)
            {
                Count = 0;
            }
        }
        else
        {
            Count--;
            if (Count < 0)
            {
                Count = 3;
            }
        }
    }

    //武官ルールがオンの時かつ武官を引いた時の処理
    private void Bukan()
    {
        if (drawcard < 41)
        {
            Debug.Log("武官" + Count + "のばん");
            hand.handCount[Count] += 1;//手札に追加
                                       //↓ここを動作すればOK
            bukan = !bukan;
        }
    }

    private void Tennou()
    {
        switch (drawcard)
        {
            case 12:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
                Debug.Log("天皇" + Count + "のばん");

                //1番
                //hand.handCount[Count] += 2;//手札に追加;

                //2番
                for (int i = Count; i < 0; i--)
                {
                    Debug.Log(Count);
                    hand.handCount[Count] += hand.handCount[i];
                }
                for (int i = Count; i < 4; i++)
                {
                    Debug.Log(Count);
                    hand.handCount[Count] += hand.handCount[i];
                }

                //捨て札回収
                hand.handCount[Count] += DiscardCount;



                break;

            default:
                //特になし
                break;

        }
    }


    private void ImageChangeTono()
    {
        Player[Count].sprite = Resources.Load<Sprite>("Images/" + drawcard);
    }
    private void ImageChangeHime()
    {
        Player[Count].sprite = Resources.Load<Sprite>("Images/" + drawcard);
        Sutehuda.sprite = null;
    }
    private void ImageChangeBouzu()
    {
        Player[Count].sprite = null;
        Sutehuda.sprite = Resources.Load<Sprite>("Images/" + drawcard);
    }
}
