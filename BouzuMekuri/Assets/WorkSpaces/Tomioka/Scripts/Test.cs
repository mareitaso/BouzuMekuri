using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private int playerSkill;
    private bool bukan = true;

    //富岡編集
    [SerializeField]
    private CardDataBase cardDataBase;
    [SerializeField]
    private Image Yamahuda;
    [SerializeField]
    private Image Sutehuda;
    [SerializeField]
    private List<Image> Player;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    public void draw()
    {
        if (deck.Count <= 3)//4人(仮)
        {
            if (deck.cards.Count > 0)//山札があるとき
            {
                deck.drawcard = deck.cards[0];//0番目を引いたカードとして登録
                Yamahuda.sprite = Resources.Load<Sprite>("Images/" + deck.drawcard);

                //坊主を引く
                if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bouzu)
                //if (deck.drawcard < 12)
                {
                    Debug.Log("坊主" + deck.Count + "のばん");
                    hand.handCount[deck.Count] += 1;
                    deck.DiscardCount += hand.handCount[deck.Count];//手札を捨て札に加算
                    hand.handCount[deck.Count] = 0;//手札を初期化
                    ImageChangeBouzu();
                }
                //姫を引く
                else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Hime)
                //else if (deck.drawcard < 33)
                {
                    Debug.Log("姫" + deck.Count + "のばん");
                    if (deck.DiscardCount > 0)
                    {
                        hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
                        deck.DiscardCount = 0;//捨て札を初期化
                        hand.handCount[deck.Count] += 1;
                        ImageChangeHime();
                    }
                    else
                    {
                        hand.handCount[deck.Count] += 1;
                        ImageChangeHime();
                    }
                }
                //殿を引く
                else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tono)
                {
                    Debug.Log("殿" + deck.Count + "のばん");
                    hand.handCount[deck.Count] += 1;//手札に追加
                    ImageChangeTono();
                }
                //武官を引く
                else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bukan)
                {
                    BukanDraw();
                }
                //deck.Count++;
                deck.cards.RemoveAt(0);//0番目を削除

                //下の代わり
                ReverseRotation();
                //if (deck.Count == 4)
                //{
                //    deck.Count = 0;
                //}

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
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/Tono/" + deck.drawcard);
    }
    private void ImageChangeHime()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/Hime/" + deck.drawcard);
        Sutehuda.sprite = null;
    }

    private void ImageChangeBouzu()
    {
        Player[deck.Count].sprite = null;
        Sutehuda.sprite = Resources.Load<Sprite>("Images/Bouzu/" + (deck.drawcard));
    }

    private void BukanDraw()
    {
        switch (playerSkill)
        {
            case 1:
                //左隣からカードを5枚
                break;

            case 2:
                //全員から1枚もらえる
                break;

            case 3:
                //逆回転
                bukan = !bukan;
                break;

            default:
                Debug.LogError("武官スキルの値がおかしいよ");
                break;
        }
    }

    private void TennouDraw()
    {
        switch (playerSkill)
        {
            case 1:
                //
                break;

            case 2:
                //
                break;

            default:
                Debug.LogError("天皇スキルの値がおかしいよ");
                break;
        }
    }

    //回る順逆転
    private void ReverseRotation()
    {
        if (bukan == true)
        {
            deck.Count++;
            if (deck.Count == 4)
            {
                deck.Count = 0;
            }
        }
        else
        {
            deck.Count--;
            if (deck.Count < 0)
            {
                deck.Count = 3;
            }
        }
    }
}
