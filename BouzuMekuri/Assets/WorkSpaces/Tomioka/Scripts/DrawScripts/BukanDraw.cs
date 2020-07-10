using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukanDraw : SingletonMonoBehaviour<BukanDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;

    //trueの時は時計回り順
    private bool clockWise = true;


    private int playerSkill = 0;
    private bool fieldEffectOnOff = false;

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

    public void BukanSkillOn()
    {
        playerSkill = 1;
    }
    public void BukanSkillOFF()
    {
        playerSkill = 0;
    }

    //武官のカードを引いた
    public void Bukan_Draw()
    {
        Debug.Log(deck.Count + "のばん");
        switch (playerSkill)
        {
            //スキル無し
            case 0:
                Debug.Log("武官のスキルはなし");
                break;

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

            //全員から1枚もらえる
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    if (i != deck.Count)
                    {
                        //1枚でも持っていたら
                        if (MasterList.Instance.list[i].Count > 1)
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に5枚渡す");
                            for (int t = 0; t < 1; t++)
                            {
                                int y = MasterList.Instance.list[i][0];//i番目の人の一番上の札を格納
                                MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                                MasterList.Instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                            }
                            //hand.handCount[deck.Count] += 5;
                            //hand.handCount[i] -= 5;
                        }
                    }
                }
                Debug.Log("武官のスキル2発動");
                break;

            //逆回転
            case 2:
                clockWise = !clockWise;
                Debug.Log("武官のスキル3発動");
                break;

            default:
                Debug.LogError("武官スキルの値がおかしいよ");
                break;
        }

        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
    }
    //回る順逆転
    public void ReverseRotation()
    {
        if (clockWise == true)
        {
            deck.Count++;
            if (deck.Count == 4)
            {
                //モック用にフィールド効果追加
                FieldEffect();
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
            if (MasterList.Instance.list[i].Count == 0)
            {
                test.Player[i].sprite = Resources.Load<Sprite>("Images/Null");
            }
        }
    }

    private void FieldEffect()
    {
        if (fieldEffectOnOff == true)
        {
            if (test.drowYama1 == true && deck.cards1.Count > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("山札1にフィールド効果発動");
                    int z = deck.cards1[0];
                    deck.DiscardCount.Add(z);
                    deck.cards1.RemoveAt(0);//0番目を削除
                }
            }

            if (test.drowYama1 == false && deck.cards2.Count > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("山札2にフィールド効果発動");
                    int x = deck.cards1[0];
                    deck.DiscardCount.Add(x);
                    deck.cards2.RemoveAt(0);//0番目を削除
                }
            }
            test.ImageChangeSemimaru();
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
