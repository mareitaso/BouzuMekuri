﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YumimotiDraw : SingletonMonoBehaviour<YumimotiDraw>
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private CardAnimation cardAnime;
    [SerializeField]
    private Draw draw;

    [HideInInspector]
    public int YumimotiNum;

    public void Yumimoti_Draw()
    {
        //左隣から5枚もらう
        Debug.Log("弓持ち" + deck.Count + "のばん");

        int drawNum = 5 + draw.effect1Num;

        int g = deck.Count + 1;
        for (int w = 0; w < 4; w++)
        {
            g %= 4;
            if (MasterList.instance.list[g].Count != 0)
            {
                if (MasterList.instance.list[g].Count > drawNum)
                {
                    for (int t = 0; t < drawNum; t++)
                    {
                        int y = MasterList.instance.list[g][0];//次の人の一番上の札を格納
                        MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                        MasterList.instance.list[g].RemoveAt(0);//i番目の人の札の初期化
                    }
                }
                else if (MasterList.instance.list[g].Count > 0)
                {
                    int m = MasterList.instance.list[g].Count;
                    for (int t = 0; t < m; t++)
                    {
                        int y = MasterList.instance.list[g][0];//i番目の人の一番上の札を格納
                        MasterList.instance.list[deck.Count].Add(y);//count番目の人がi番目の一番上のカードをもらう
                        MasterList.instance.list[g].RemoveAt(0);//i番目の人の札の初期化
                    }
                }
                YumimotiNum = g;
                break;
            }
            g++;
            g %= 4;
        }

        cardAnime.animeFunctionNum = 7;
        cardAnime.AnimeSkillCutIn();
        //cardAnime.AnimeLeftToRight();
        Debug.Log("最終的にカードを渡す人は" + (YumimotiNum + 1) + "→" + (deck.Count + 1));
        Debug.Log("弓持ちのスキル発動");

        MasterList.instance.list[deck.Count].Add(deck.drawcard);//手札に追加
    }
}
