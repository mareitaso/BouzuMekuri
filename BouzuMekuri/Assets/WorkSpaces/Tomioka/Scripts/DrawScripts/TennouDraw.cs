using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennouDraw : SingletonMonoBehaviour<TennouDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;
    [SerializeField]
    private CardAnimation cardAnime;


    private int playerSkill = 0;


    //天皇カードを引いた
    public void Tennou_Draw()
    {
        playerSkill = RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0];

        Debug.Log(deck.Count + "のばん");
        switch (playerSkill)
        {
            //スキル無し
            case 0:
                Debug.Log("天皇のスキルは無し");
                break;

            case 1:
                draw.drawAgain = true;
                //山札1から引く場合
                if (draw.drowYama1 == true)
                {
                    //山札から2枚引く
                    for (int i = 0; i < 1; i++)
                    {
                        deck.drawcard = deck.cards1[0];//いらないかも
                        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
                        deck.cards1.RemoveAt(0);
                    }
                    cardAnime.animeFunctionNum = 1;
                    cardAnime.AnimeSkillCutIn();
                    //cardAnime.AnimeOneDraw();
                }
                else
                {
                    //山札から2枚引く
                    for (int i = 0; i < 1; i++)
                    {
                        deck.drawcard = deck.cards2[0];//いらないかも
                        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加;
                        deck.cards2.RemoveAt(0);
                    }
                    cardAnime.animeFunctionNum = 1;
                    cardAnime.AnimeSkillCutIn();
                    //cardAnime.AnimeOneDraw();
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
                        Debug.Log(i + 1 + "番目の人は" + MasterList.instance.list[i].Count + "枚");
                        int q = MasterList.instance.list[i].Count;
                        for (int t = 0; t < q; t++)
                        {
                            Debug.Log(i + 1 + "番目の人は" + t + "回目");
                            int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                            MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                            MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
                        }
                        //hand.handCount[deck.Count] += hand.handCount[i];
                        //hand.handCount[i] = 0;
                    }
                }
                //場の札をもらう
                if (deck.DiscardCount.Count > 0)
                {
                    //for (int t = 0; t < deck.DiscardCount.Count; t++)
                    //{
                    //    int y = deck.DiscardCount[0];//捨て札を格納
                    //    MasterList.instance.list[deck.Count].Add(y);//捨て札を回収
                    //    deck.DiscardCount.RemoveAt(0);//捨て札を初期化
                    //}
                    int r = deck.DiscardCount.Count;
                    for (int t = 0; t < r; t++)
                    {
                        int y = deck.DiscardCount[0];//捨て札を格納
                        MasterList.instance.list[deck.Count].Add(y);//捨て札を回収
                        deck.DiscardCount.RemoveAt(0);//捨て札を初期化
                    }
                    //hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
                    //deck.DiscardCount = 0;//捨て札を初期化
                    //draw.ImageChangeHime();
                }
                else
                {
                    //draw.ImageChangeHime();
                }
                //cardAnime.AnimeAllGet();
                cardAnime.animeFunctionNum = 2;
                cardAnime.AnimeSkillCutIn();

                Debug.Log("天皇のスキル2発動");
                break;
            default:
                Debug.LogError("天皇スキルの値がおかしいよ");
                break;
        }

        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
        //draw.ImageChangeTono();
    }
}
