using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private int playerSkill = 1;
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
    private List<Text> PlayerCards;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    private void Update()
    {
        SkillChange();
    }

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
                //天皇を引く
                else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tennnou)
                {
                    TennouDraw();
                    hand.handCount[deck.Count] += 1;//手札に追加
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
                    hand.handCount[deck.Count] += 1;//手札に追加
                }
                //deck.Count++;

                deck.cards.RemoveAt(0);//0番目を削除

                TextChange();
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
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/" + deck.drawcard);
    }
    private void ImageChangeHime()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/" + deck.drawcard);
        Sutehuda.sprite = null;
    }

    private void ImageChangeBouzu()
    {
        Player[deck.Count].sprite = null;
        Sutehuda.sprite = Resources.Load<Sprite>("Images/" + (deck.drawcard));
    }

    //武官のカードを引いた
    private void BukanDraw()
    {
        switch (playerSkill)
        {
            case 1:
                //左隣からカードを5枚
                if (deck.Count == 0)
                {
                    //5枚以上あるか確認
                    if (hand.handCount[3] > 5)
                    {
                        hand.handCount[deck.Count] += 5;
                        hand.handCount[3] -= 5;
                    }
                    else
                    {
                        hand.handCount[deck.Count] += hand.handCount[3];
                        hand.handCount[3] = 0;
                    }
                }
                else
                {
                    //Count-1の人から5枚もらう
                    if (hand.handCount[deck.Count - 1] > 5)
                    {
                        hand.handCount[deck.Count] += 5;
                        hand.handCount[deck.Count - 1] -= 5;
                    }
                    else
                    {
                        hand.handCount[deck.Count] += hand.handCount[deck.Count - 1];
                        hand.handCount[deck.Count - 1] = 0;
                    }
                }
                Debug.Log("武官のスキル1発動");
                break;

            case 2:
                //全員から1枚もらえる
                for (int i = 0; i < 4; i++)
                {
                    if (i != deck.Count)
                    {
                        //1枚でも持っていたら
                        if (hand.handCount[i] > 0)
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に1枚渡す");
                            hand.handCount[deck.Count] += 1;
                            hand.handCount[i] -= 1;
                        }
                    }
                }
                Debug.Log("武官のスキル2発動");
                break;

            case 3:
                //逆回転
                bukan = !bukan;
                Debug.Log("武官のスキル3発動");
                break;

            default:
                Debug.LogError("武官スキルの値がおかしいよ");
                break;
        }
        ImageChangeTono();
    }

    //天皇カードを引いた
    private void TennouDraw()
    {
        switch (playerSkill)
        {
            case 1:
                //山札から2枚引く
                for (int i = 0; i < 2; i++)
                {
                    deck.drawcard = deck.cards[0];//いらないかも
                    hand.handCount[deck.Count] += 1;
                    deck.cards.RemoveAt(0);
                }
                Debug.Log("天皇のスキル1発動");
                break;

            case 2:
                //全員の札と場の札すべてもらう
                for (int i = 0; i < 4; i++)
                {
                    //全員の札をもらう
                    if (i != deck.Count)
                    {
                        Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
                        hand.handCount[deck.Count] += hand.handCount[i];
                        hand.handCount[i] = 0;
                    }
                }
                //場の札をもらう
                if (deck.DiscardCount > 0)
                {
                    hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
                    deck.DiscardCount = 0;//捨て札を初期化
                    ImageChangeHime();
                }
                else
                {
                    ImageChangeHime();
                }
                Debug.Log("天皇のスキル2発動");
                break;
            case 3:
                //他のプレイヤーすべての手札を自分の手札に加える
                for (int i = 0; i < 4; i++)
                {
                    if (i != deck.Count)
                    {
                        Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
                        hand.handCount[deck.Count] += hand.handCount[i];
                        hand.handCount[i] = 0;
                    }
                }
                Debug.Log("天皇のスキル3発動");
                break;

            default:
                Debug.LogError("天皇スキルの値がおかしいよ");
                break;
        }
        if (cardDataBase.YamahudaLists()[deck.drawcard].GetSecondJob() == Card.SecondJob.Tono)
        {
            ImageChangeTono();
        }
        //天皇のカードが姫の場合
        else
        {
            if (deck.DiscardCount > 0)
            {
                hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
                deck.DiscardCount = 0;//捨て札を初期化
                hand.handCount[deck.Count] += 1;
            }
            else
            {
                hand.handCount[deck.Count] += 1;
            }
            ImageChangeHime();
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
        ImageNull();
    }


    private void SkillChange()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            playerSkill = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            playerSkill = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            playerSkill = 3;
        }
    }

    private void TextChange()
    {
        PlayerCards[0].text = hand.handCount[0].ToString();
        PlayerCards[1].text = hand.handCount[1].ToString();
        PlayerCards[2].text = hand.handCount[2].ToString();
        PlayerCards[3].text = hand.handCount[3].ToString();
        PlayerCards[4].text = deck.DiscardCount.ToString();
        PlayerCards[5].text = deck.cards.Count.ToString();
    }

    private void ImageNull()
    {
        for (int i = 0; i < 4; i++)
        {
            if (hand.handCount[i] == 0)
            {
                Player[i].sprite = null;
            }
        }
    }
}
