﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennouDraw : SingletonMonoBehaviour<TennouDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;
    [SerializeField]
    private CardDataBase cardDataBase;


    private int playerSkill = 0;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Keypad0))
        //{
        //    playerSkill = 0;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    playerSkill = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    playerSkill = 2;
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad3))
        //{
        //    playerSkill = 3;
        //}

    }

    public void TennouSkillOn()
    {
        playerSkill = 2;
    }
    public void TennouSkillOFF()
    {
        playerSkill = 0;
    }

    //天皇カードを引いた
    public void Tennou_Draw()
    {
        Debug.Log(deck.Count + "のばん");
        switch (playerSkill)
        {
            //スキル無し
            case 0:
                Debug.Log("天皇のスキルは無し");
                break;

            case 1:
                //山札1から引く場合
                if (test.drowYama1 == true)
                {
                    //山札から2枚引く
                    for (int i = 0; i < 2; i++)
                    {
                        deck.drawcard = deck.cards1[0];//いらないかも
                        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
                        deck.cards1.RemoveAt(0);
                    }
                }
                else
                {
                    //山札から2枚引く
                    for (int i = 0; i < 2; i++)
                    {
                        deck.drawcard = deck.cards2[0];//いらないかも
                        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加;
                        deck.cards2.RemoveAt(0);
                    }
                }
                Debug.Log("天皇のスキル1発動");
                break;

            case 2:
                //全員の札と場の札をすべてもらう
                for (int i = 0; i < 4; i++)
                {
                    //全員の札をもらう
                    if (i != deck.Count)
                    {
                        Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
                        for (int t = 0; t < MasterList.Instance.list[i].Count; t++)
                        {
                            int y = MasterList.Instance.list[i][0];//i番目の人の一番上の札を格納
                            MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                            MasterList.Instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                        }
                        //hand.handCount[deck.Count] += hand.handCount[i];
                        //hand.handCount[i] = 0;
                    }
                }
                //場の札をもらう
                if (deck.DiscardCount.Count > 0)
                {
                    for (int t = 0; t < deck.DiscardCount.Count; t++)
                    {
                        int y = deck.DiscardCount[0];//捨て札を格納
                        MasterList.Instance.list[deck.Count].Add(y);//捨て札を回収
                        deck.DiscardCount.RemoveAt(0);//捨て札を初期化
                    }
                    //hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
                    //deck.DiscardCount = 0;//捨て札を初期化
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
                    //全員の札をもらう
                    if (i != deck.Count)
                    {
                        Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
                        for (int t = 0; t < MasterList.Instance.list[i].Count; t++)
                        {
                            int y = MasterList.Instance.list[i][0];//i番目の人の一番上の札を格納
                            MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                            MasterList.Instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                        }
                        //hand.handCount[deck.Count] += hand.handCount[i];
                        //hand.handCount[i] = 0;
                    }
                }
                Debug.Log("天皇のスキル3発動");
                break;

            default:
                Debug.LogError("天皇スキルの値がおかしいよ");
                break;
        }

        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        test.ImageChangeTono();
    }
}
