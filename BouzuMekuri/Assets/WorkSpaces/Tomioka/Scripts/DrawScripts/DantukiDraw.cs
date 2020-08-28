using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DantukiDraw : SingletonMonoBehaviour<DantukiDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
<<<<<<< .merge_file_a05864
    private HandCount hand;
    [SerializeField]
    private Test test;
=======
    private Draw draw;
>>>>>>> .merge_file_a20872
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
<<<<<<< .merge_file_a05864
                //test.ImageChangeTono();
=======
                //draw.ImageChangeTono();
>>>>>>> .merge_file_a20872
                Debug.Log("段付きのスキルは無し");
                break;

            case 3:
                //全員から5枚もらえる
                for (int i = 0; i < 4; i++)
                {
                    if (i != deck.Count)
                    {
                        //5枚以上持っていたら
<<<<<<< .merge_file_a05864
                        if (MasterList.Instance.list[i].Count > 5)
=======
                        if (MasterList.instance.list[i].Count > 5)
>>>>>>> .merge_file_a20872
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に5枚渡す");
                            for (int t = 0; t < 5; t++)
                            {
<<<<<<< .merge_file_a05864
                                int y = MasterList.Instance.list[i][0];//i番目の人の一番上の札を格納
                                MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                                MasterList.Instance.list[i].RemoveAt(0);//i番目の人の札の初期化
=======
                                int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                                MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                                MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
>>>>>>> .merge_file_a20872
                            }
                            //hand.handCount[deck.Count] += 5;
                            //hand.handCount[i] -= 5;
                        }
                        else
                        {
                            Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に持っている枚数渡す");
<<<<<<< .merge_file_a05864
                            int p = MasterList.Instance.list[i].Count;
                            for (int t = 0; t < p; t++)
                            {
                                int y = MasterList.Instance.list[i][0];//i番目の人の一番上の札を格納
                                MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                                MasterList.Instance.list[i].RemoveAt(0);//i番目の人の札の初期化
=======
                            int p = MasterList.instance.list[i].Count;
                            for (int t = 0; t < p; t++)
                            {
                                int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                                MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                                MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
>>>>>>> .merge_file_a20872
                            }
                            //hand.handCount[deck.Count] += hand.handCount[i];
                            //hand.handCount[i] = 0;
                        }
                    }
                }
<<<<<<< .merge_file_a05864
                cardAnime.AnimeCardNMove();
=======
                cardAnime.animeFunctionNum = 3;
                cardAnime.AnimeSkillCutIn();
                //cardAnime.AnimeCardNMove();
>>>>>>> .merge_file_a20872
                break;

            case 4:
                //他のプレイヤーすべての手札を自分の手札に加える
                for (int i = 0; i < 4; i++)
                {
                    //全員の札をもらう
                    if (i != deck.Count)
                    {
                        Debug.Log(i + 1 + "番の人が" + (deck.Count + 1) + "番目の人に全部渡す");
<<<<<<< .merge_file_a05864
                        int l = MasterList.Instance.list[i].Count;
                        for (int t = 0; t < l; t++)
                        {
                            int y = MasterList.Instance.list[i][0];//i番目の人の一番上の札を格納
                            MasterList.Instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                            MasterList.Instance.list[i].RemoveAt(0);//i番目の人の札の初期化
=======
                        int l = MasterList.instance.list[i].Count;
                        for (int t = 0; t < l; t++)
                        {
                            int y = MasterList.instance.list[i][0];//i番目の人の一番上の札を格納
                            MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                            MasterList.instance.list[i].RemoveAt(0);//i番目の人の札の初期化
>>>>>>> .merge_file_a20872
                        }
                        //hand.handCount[deck.Count] += hand.handCount[i];
                        //hand.handCount[i] = 0;
                    }
                }
<<<<<<< .merge_file_a05864
                cardAnime.AnimeHandCardGet();
=======
                cardAnime.animeFunctionNum = 4;
                cardAnime.AnimeSkillCutIn();
                //cardAnime.AnimeHandCardGet();
>>>>>>> .merge_file_a20872
                Debug.Log("段付きのスキル2発動");
                break;

            default:
                Debug.LogError("段付きスキルの値がおかしいよ");
                break;

        }

<<<<<<< .merge_file_a05864
        MasterList.Instance.list[deck.Count].Add(deck.drawcard);//手札に追加
=======
        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
>>>>>>> .merge_file_a20872
    }
}
