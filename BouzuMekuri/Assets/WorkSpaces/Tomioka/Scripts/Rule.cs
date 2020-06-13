using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    private int playerSkill = 1;

    private bool bukan = true;

    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private CardDataBase cardDataBase;
    [SerializeField]
    private Test test;

    private void Update()
    {
        SkillChange();
    }

    //武官のカードを引いた
    public void BukanDraw()
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

            //全員から1枚もらえる
            case 2:
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

            //逆回転
            case 3:
                bukan = !bukan;
                Debug.Log("武官のスキル3発動");
                break;

            default:
                Debug.LogError("武官スキルの値がおかしいよ");
                break;
        }

    }

    //天皇カードを引いた
    public void TennouDraw()
    {
        switch (playerSkill)
        {
            case 1:
                //山札1から引く場合
                if (test.drowYama1 == true)
                {
                    //山札から2枚引く
                    for (int i = 0; i < 2; i++)
                    {
                        deck.drawcard = deck.cards1[0];//いらないかも
                        hand.handCount[deck.Count] += 1;
                        deck.cards1.RemoveAt(0);
                    }
                }
                else
                {
                    //山札から2枚引く
                    for (int i = 0; i < 2; i++)
                    {
                        deck.drawcard = deck.cards2[0];//いらないかも
                        hand.handCount[deck.Count] += 1;
                        deck.cards2.RemoveAt(0);
                    }
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
                    test.ImageChangeHime();
                }
                else
                {
                    test.ImageChangeHime();
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
            test.ImageChangeTono();
        }
        //天皇のカードが姫の場合
        else
        {
            if (deck.DiscardCount > 0)
            {
                hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
                deck.DiscardCount = 0;//捨て札を初期化
            }
            test.ImageChangeHime();
        }
    }

    //回る順逆転
    public void ReverseRotation()
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

    private void ImageNull()
    {
        for (int i = 0; i < 4; i++)
        {
            if (hand.handCount[i] == 0)
            {
                test.Player[i].sprite = null;
            }
        }
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
}
