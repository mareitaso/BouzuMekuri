using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukanDraw : SingletonMonoBehaviour<BukanDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
<<<<<<< .merge_file_a19316
    private HandCount hand;
    [SerializeField]
    private Test test;
=======
    private Draw draw;
>>>>>>> .merge_file_a19484
    [SerializeField]
    CardAnimation cardAnime;

    //trueの時は時計回り順
<<<<<<< .merge_file_a19316
    private bool clockWise = true;

=======
    private bool beforeClockWise = true;
    public bool clockWise = true;
>>>>>>> .merge_file_a19484

    private int playerSkill = 0;
    private bool fieldEffectOnOff = false;

    //武官のカードを引いた
    public void Bukan_Draw()
    {
        playerSkill = RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0];

        Debug.Log(deck.Count + "のばん");
        switch (playerSkill)
        {
            //スキル無し
            case 0:
                Debug.Log("武官のスキルはなし");
                break;

<<<<<<< .merge_file_a19316
            //case 1:
            //    //左隣からカードを5枚
            //    if (deck.Count == 0)
            //    {
            //        //5枚以上あるか確認
            //        if (hand.handCount[3] > 5)
            //        {
            //            hand.handCount[deck.Count] += 5;
            //            hand.handCount[3] -= 5;
            //        }
            //        else
            //        {
            //            hand.handCount[deck.Count] += hand.handCount[3];
            //            hand.handCount[3] = 0;
            //        }
            //    }
            //    else
            //    {
            //        //Count-1の人から5枚もらう
            //        if (hand.handCount[deck.Count - 1] > 5)
            //        {
            //            hand.handCount[deck.Count] += 5;
            //            hand.handCount[deck.Count - 1] -= 5;
            //        }
            //        else
            //        {
            //            hand.handCount[deck.Count] += hand.handCount[deck.Count - 1];
            //            hand.handCount[deck.Count - 1] = 0;
            //        }
            //    }
            //    Debug.Log("武官のスキル1発動");
            //    break;

=======
>>>>>>> .merge_file_a19484
            //全員から4枚もらえる
            case 1:
                for (int i = deck.Count; i < 4 + deck.Count + 1; i++)
                {
                    int k = i % 4;
                    if (k != deck.Count)
                    {
                        //N枚以上もってたら
<<<<<<< .merge_file_a19316
                        if (MasterList.Instance.list[k].Count > 4)
                        {
                            Debug.Log(i + "は" + MasterList.Instance.list[k].Count);
                            for (int t = 0; t < 4; t++)
                            {
                                int y = MasterList.Instance.list[k][0];//k番目の人の一番上の札を格納
                                MasterList.Instance.list[deck.Count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                                MasterList.Instance.list[k].RemoveAt(0);//k番目の人の札の初期化
=======
                        if (MasterList.instance.list[k].Count > 4)
                        {
                            Debug.Log(i + "は" + MasterList.instance.list[k].Count);
                            for (int t = 0; t < 4; t++)
                            {
                                int y = MasterList.instance.list[k][0];//k番目の人の一番上の札を格納
                                MasterList.instance.list[deck.Count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                                MasterList.instance.list[k].RemoveAt(0);//k番目の人の札の初期化
>>>>>>> .merge_file_a19484
                                Debug.Log(i % 4 + "は" + t + "回");
                            }
                            Debug.Log(k + 1 + "番の人が" + (deck.Count + 1) + "番目の人に4枚渡す");
                        }
                        //N枚以下なら
                        else
                        {
<<<<<<< .merge_file_a19316
                            int w = MasterList.Instance.list[k].Count;
                            for (int t = 0; t < w; t++)
                            {
                                int y = MasterList.Instance.list[k][0];//k番目の人の一番上の札を格納
                                MasterList.Instance.list[deck.Count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                                MasterList.Instance.list[k].RemoveAt(0);//k番目の人の札の初期化
=======
                            int w = MasterList.instance.list[k].Count;
                            for (int t = 0; t < w; t++)
                            {
                                int y = MasterList.instance.list[k][0];//k番目の人の一番上の札を格納
                                MasterList.instance.list[deck.Count].Add(y);//count番目の人がk番目の一番上のカードをもらう
                                MasterList.instance.list[k].RemoveAt(0);//k番目の人の札の初期化
>>>>>>> .merge_file_a19484
                            }
                            Debug.Log(k + 1 + "番の人が" + (deck.Count + 1) + "番目の人に4枚渡せないから全部渡す");
                        }
                    }
                }
<<<<<<< .merge_file_a19316
                cardAnime.AnimeCardNMove();
=======
                cardAnime.animeFunctionNum = 5;
                cardAnime.AnimeSkillCutIn();
                //cardAnime.AnimeCardNMove();
>>>>>>> .merge_file_a19484
                Debug.Log("武官のスキル1発動");
                break;

            //逆回転
            case 2:
                clockWise = !clockWise;
<<<<<<< .merge_file_a19316
=======
                cardAnime.animeFunctionNum = 6;
                cardAnime.AnimeSkillCutIn();
>>>>>>> .merge_file_a19484
                Debug.Log("武官のスキル2発動");
                break;

            default:
                Debug.LogError("武官スキルの値がおかしいよ");
                break;
        }

<<<<<<< .merge_file_a19316
        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
=======
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
>>>>>>> .merge_file_a19484
    }
    //回る順逆転
    public void ReverseRotation()
    {
<<<<<<< .merge_file_a19316
        if (test.drawAgain == true)
        {
            if (test.drowYama1 == true)
            {
                test.drawAgain = false;
                test.Draw1();
            }
            else
            {
                test.drawAgain = false;
                test.Draw2();
=======
        if (draw.drawAgain == true)
        {
            if (draw.drowYama1 == true)
            {
                draw.drawAgain = false;
                //draw.Draw1();
            }
            else
            {
                draw.drawAgain = false;
                //draw.Draw2();
>>>>>>> .merge_file_a19484
            }
        }
        else
        {
<<<<<<< .merge_file_a19316
            if (clockWise == true)
            {
                deck.Count++;
                if (deck.Count == 4)
                {
                    //モック用にフィールド効果追加
                    FieldEffect();
                    deck.Count = 0;
=======
            if (beforeClockWise == clockWise)
            {
                if (clockWise == true)
                {
                    deck.Count++;
                    draw.drawNum++;
                    if (deck.Count == 4)
                    {
                        //モック用にフィールド効果追加
                        FieldEffect();
                        deck.Count = 0;
                    }
                    PlayerBreak();
                }
                else
                {
                    deck.Count--;
                    draw.drawNum++;
                    if (deck.Count < 0)
                    {
                        deck.Count = 3;
                    }
                    PlayerBreak();
>>>>>>> .merge_file_a19484
                }
            }
            else
            {
<<<<<<< .merge_file_a19316
                deck.Count--;
                if (deck.Count < 0)
                {
                    deck.Count = 3;
                }
            }
        }
        //ImageNull();
=======
                beforeClockWise = clockWise;
                if (clockWise == true)
                {
                    draw.drawNum++;
                    PlayerBreak();
                }
                else
                {
                    draw.drawNum++;
                    PlayerBreak();
                }
            }
        }

        if (draw.drawNum == 4 && draw.fieldEffectNum == 3)
        {
            draw.drawNum = 0;
            draw.fieldEffect = true;
        }
    }


    //プレイヤー1回休みの処理
    private void PlayerBreak()
    {
        if (clockWise == true)
        {
            for (int i = deck.Count; i < 4 + deck.Count; i++)
            {
                if (draw.playerBreak[i] == false)
                {
                    break;
                }
                else
                {
                    draw.playerBreak[i] = false;
                    deck.Count++;
                    deck.Count %= 4;
                }
            }
        }
        else
        {
            for (int i = deck.Count; i < 4 + deck.Count; i++)
            {
                if (draw.playerBreak[i] == false)
                {
                    break;
                }
                else
                {
                    draw.playerBreak[i] = false;
                    deck.Count--;
                    if (deck.Count < 0)
                    {
                        deck.Count = 0;
                    }
                }
            }
        }
>>>>>>> .merge_file_a19484
    }

    private void ImageNull()
    {
        for (int i = 0; i < 4; i++)
        {
<<<<<<< .merge_file_a19316
            if (MasterList.Instance.list[i].Count == 0)
            {
                test.Player[i].sprite = Resources.Load<Sprite>("Images/Null");
=======
            if (MasterList.instance.list[i].Count == 0)
            {
                draw.Player[i].sprite = Resources.Load<Sprite>("Images/Null");
>>>>>>> .merge_file_a19484
            }
        }
    }

    private void FieldEffect()
    {
        if (fieldEffectOnOff == true)
        {
<<<<<<< .merge_file_a19316
            if (test.drowYama1 == true && deck.cards1.Count > 3)
=======
            if (draw.drowYama1 == true && deck.cards1.Count > 3)
>>>>>>> .merge_file_a19484
            {
                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("山札1にフィールド効果発動");
                    int z = deck.cards1[0];
                    deck.DiscardCount.Add(z);
                    deck.cards1.RemoveAt(0);//0番目を削除
                }
            }

<<<<<<< .merge_file_a19316
            if (test.drowYama1 == false && deck.cards2.Count > 3)
=======
            if (draw.drowYama1 == false && deck.cards2.Count > 3)
>>>>>>> .merge_file_a19484
            {
                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("山札2にフィールド効果発動");
                    int x = deck.cards1[0];
                    deck.DiscardCount.Add(x);
                    deck.cards2.RemoveAt(0);//0番目を削除
                }
            }
<<<<<<< .merge_file_a19316
            test.ImageChangeSemimaru();
=======
            draw.ImageChangeSemimaru();
>>>>>>> .merge_file_a19484
        }
    }

    public void FieldEffectOn()
    {
        fieldEffectOnOff = true;
    }
    public void FieldEffectOFF()
    {
        fieldEffectOnOff = false;
    }

}
