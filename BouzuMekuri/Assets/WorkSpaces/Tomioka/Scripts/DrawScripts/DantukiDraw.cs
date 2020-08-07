using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DantukiDraw : SingletonMonoBehaviour<DantukiDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Test test;
    [SerializeField]
    private CardAnimation cardAnime;

    private int playerSkill = 0;

    //段付きカードを引いた
    public void Dantuki_Draw()
    {
        playerSkill = RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0];

        Debug.Log(deck.Count + "のばん");
        switch (playerSkill)
        {
            //スキル無し
            case 0:
                //test.ImageChangeTono();
                Debug.Log("段付きのスキルは無し");
                break;

            case 3:
                //全員から5枚もらえる
                for (int i = 0; i < 4; i++)
                {
                    if (i != deck.Count)
                    {
                        //5枚以上持っていたら
                        if (MasterList.instance.list[i].Count > 5)
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に5枚渡す");
                            for (int t = 0; t < 5; t++)
                            {
                                int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                                MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                                MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                            }
                            //hand.handCount[deck.Count] += 5;
                            //hand.handCount[i] -= 5;
                        }
                        else
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に持っている枚数渡す");
                            int p = MasterList.instance.list[i].Count;
                            for (int t = 0; t < p; t++)
                            {
                                int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                                MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                                MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                            }
                            //hand.handCount[deck.Count] += hand.handCount[i];
                            //hand.handCount[i] = 0;
                        }
                    }
                }
                cardAnime.animeFunctionNum = 3;
                cardAnime.AnimeSkillCutIn();
                //cardAnime.AnimeCardNMove();
                break;

            case 4:
                //他のプレイヤーすべての手札を自分の手札に加える
                for (int i = 0; i < 4; i++)
                {
                    //全員の札をもらう
                    if (i != deck.Count)
                    {
                        Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
                        int l = MasterList.instance.list[i].Count;
                        for (int t = 0; t < l; t++)
                        {
                            int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                            MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                            MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                        }
                        //hand.handCount[deck.Count] += hand.handCount[i];
                        //hand.handCount[i] = 0;
                    }
                }
                cardAnime.animeFunctionNum = 4;
                cardAnime.AnimeSkillCutIn();
                //cardAnime.AnimeHandCardGet();
                Debug.Log("段付きのスキル2発動");
                break;

            default:
                Debug.LogError("段付きスキルの値がおかしいよ");
                break;

        }

        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
    }
}
