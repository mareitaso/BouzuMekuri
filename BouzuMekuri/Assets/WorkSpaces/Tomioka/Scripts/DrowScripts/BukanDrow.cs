﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukanDraw : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

    //trueの時は時計回り順
    private bool clockWise = true;

    //武官のカードを引いた
    public void Bukan_Draw()
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
                clockWise = !clockWise;
                Debug.Log("武官のスキル3発動");
                break;

            default:
                Debug.LogError("武官スキルの値がおかしいよ");
                break;
        }

    }
    //回る順逆転
    public void ReverseRotation()
    {
        if (clockWise == true)
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

}