﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;
    [SerializeField]
    private Touch touch;
    [SerializeField]
    private CardAnimation cardAnime;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    PlayerSkill2();
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad3))
        //{
        //    PlayerSkill3();
        //}
    }

    /// <summary>
    /// 自分の手札を全部捨て場に置き
    /// １位のプレイヤーは手札の半分を捨て場に置く
    /// </summary>
    public void PlayerSkill2()
    {

        int x = 0;//枚数比較用
        int b = 0;//半分捨てる人
        //誰が一番多く持っているか
        for (int i = 0; i < 4; i++)
        {
            if (x < MasterList.instance.list[i].Count)
            {
                x = MasterList.instance.list[i].Count;
                b = i;
            }
        }

        if (b != deck.Count)
        {
            cardAnime.skillPlayer = b;

            if (MasterList.instance.list[cardAnime.skillPlayer].Count < 1)
            {
                Debug.Log("1位の人が１枚のため何も起こらない");
            }
            else
            {

                int a = MasterList.instance.list[touch.touchPlayer].Count;
                //スキルを使った人の手札を捨て札に加算
                for (int t = 0; t < a; t++)
                {
                    int y = MasterList.instance.list[touch.touchPlayer][0];
                    deck.DiscardCount.Add(y);
                    MasterList.instance.list[touch.touchPlayer].RemoveAt(0);
                }
                MasterList.instance.list[touch.touchPlayer].Clear();//手札を初期化


                int g = MasterList.instance.list[b].Count;
                //一番っ持っている人の手札を捨て札に加算
                for (int m = 0; m < g / 2; m++)
                {
                    int z = MasterList.instance.list[b][0];
                    deck.DiscardCount.Add(z);
                    MasterList.instance.list[b].RemoveAt(0);
                }

                Debug.Log((touch.touchPlayer + 1) + "がスキルを使い全部捨てた");
                Debug.Log("Player" + (cardAnime.skillPlayer + 1) + "がスキル対象で半分捨てた");

                draw.TextChange();
                cardAnime.AnimePlayerSkill2();
            }
        }
        else
        {
            if (touch.touchPlayer == 0)
            {
                touch.Player1 = false;
            }
            if (touch.touchPlayer == 1)
            {
                touch.Player2 = false;
            }
            if (touch.touchPlayer == 2)
            {
                touch.Player3 = false;
            }
            if (touch.touchPlayer == 3)
            {
                touch.Player4 = false;
            }
            Debug.Log("スキルを使った人が1位なのだ、へケ");
        }
    }


    /// <summary>
    /// 全てのプレイヤーは最下位と同じ枚数になるように
    /// 捨て場にカードを置く(山札計10枚以上)
    /// </summary>
    public void PlayerSkill3()
    {
        int v = 100;//枚数比較用
        int s = 0;//一番少ない人
        for (int i = 0; i < 4; i++)
        {
            if (v >= MasterList.instance.list[i].Count)
            {
                v = MasterList.instance.list[i].Count;
                s = i;
            }
        }

        Debug.Log("最小枚数は" + v);

        int h;
        for (int i = s + 1; i < s + 4; i++)
        {
            h = i % 4;
            Debug.Log(h + "player");
            int d = MasterList.instance.list[h].Count;

            //スキルを使った人以外の手札を捨て札に加算
            for (int t = 0; t < (d - v); t++)
            {
                int y = MasterList.instance.list[h][0];
                deck.DiscardCount.Add(y);
                MasterList.instance.list[h].RemoveAt(0);
            }
            if (MasterList.instance.list[h].Count > v)
            {
                cardAnime.skillDamagePlayer = h;
            }
            Debug.Log("Player" + (h + 1) + "がスキル対象で" + (d - v) + "枚捨てた");
        }
        cardAnime.skillPlayer = s;
        draw.TextChange();
        cardAnime.AnimePlayerSkill3();
    }
}
