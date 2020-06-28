using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DantukiDraw : SingletonMonoBehaviour<DantukiDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;


    private int playerSkill = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            playerSkill = 0;
        }
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

    //段付きカードを引いた
    public void Dantuki_Draw()
    {
        Debug.Log(deck.Count + "のばん");
        switch (playerSkill)
        {
            //スキル無し
            case 0:
                Debug.Log("段付きのスキルは無し");
                break;

            case 1:
                //全員から5枚もらえる
                for (int i = 0; i < 4; i++)
                {
                    if (i != deck.Count)
                    {
                        //5枚以上持っていたら
                        if (hand.handCount[i] > 5)
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に5枚渡す");
                            hand.handCount[deck.Count] += 5;
                            hand.handCount[i] -= 5;
                        }
                        else
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に持っている枚数渡す");
                            hand.handCount[deck.Count] += hand.handCount[i];
                            hand.handCount[i] = 0;
                        }
                    }
                }
                break;

            case 2:
                //全員の札と場の札をすべてもらう
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
                Debug.Log("段付きのスキル3発動");
                break;

            default:
                Debug.LogError("段付きスキルの値がおかしいよ");
                break;

        }

        hand.handCount[deck.Count] += 1;//手札に追加
    }
}
