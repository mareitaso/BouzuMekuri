using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrowCrad : MonoBehaviour
{

    [SerializeField]
    private Image Yamahuda;
    [SerializeField]
    private Image Sutehuda;
    [SerializeField]
    private List<Image> Player;

    public int DiscardCount;//捨て札の枚数
    private int drawcard;//引いたカード

    public Test deck;
    public HandCount hand;

    public int Count;

    // Start is called before the first frame update
    public void Draw()
    {
        NormalRule();
    }

    private void NormalRule()
    {
        if (Count <= 3)//4人(仮)
        {
            if (deck.cards.Count > 0)//山札があるとき
            {
                drawcard = deck.cards[0];//0番目を引いたカードとして登録
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
            deck.cards.RemoveAt(0);//0番目を削除

            Count++;
            if (Count == 4)
            {
                Count = 0;
            }
            //ReverseRotation();
        }
    }

    //回る順逆転
    //private void ReverseRotation()
    //{
    //    if (bukan == true)
    //    {
    //        Count++;
    //        if (Count == 4)
    //        {
    //            Count = 0;
    //        }
    //    }
    //    else
    //    {
    //        Count--;
    //        if (Count < 0)
    //        {
    //            Count = 3;
    //        }
    //    }
    //}

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
