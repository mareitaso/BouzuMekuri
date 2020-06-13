using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandCount : MonoBehaviour
{
    [SerializeField]
    public int[] handCount; //4人分の手札
    [SerializeField]
    private Deck deck;
    private int player;
    private const int Max = 100;//所持札の最大数
    private static int num =4;//参加最大人数
    private int[] score = new int[num];//人数分の点数データ
    private int[] rank = new int[num];//人数分の順位データ
    private int[] count = new int[Max + 1];//A点の人の数
    private int[] Rank = new int[Max + 1];//A点の人の順位

    public void Settlement()//順位決定
    {
        Result();
        Array.Clear(count, 0, num);//得点別の配列をクリア
        for(int i = 0; i < num; i++)//全員に対して得点事の配列をカウント
            count[score[i]]++;
        int j = 0;//最高得点の人の順位
        for(int i = Max; i >= 0; i--)//最高得点から順位付け
        {
            Rank[i] = j;
            j += count[i];
        }
        for (int i = 0; i < num; i++)
            rank[i] = Rank[score[i]];//得点別順位の振り分け
        for (int i = 0; i < num; i++)
            Debug.LogFormat("#{0}P: {1}枚 ... {2}位", i+1, score[i], rank[i]+1);
        /*for (int i = 0; i < handCount.Length; i++)
        {
            
            Debug.LogFormat("{0}Pは{1}枚です。", i + 1, handCount[i]);
        }
        Debug.Log("捨て札は" + deck.DiscardCount + "枚です");


        Array.Sort(handCount);
        foreach(int n in handCount)
        {
            Debug.Log(n + "位 " + "{0}P " + n + "枚\n",  handCount.Length[]-1);
        }*/
        return;
    }

    public void h()
    {
        player = 4;
        Array.Resize(ref handCount, player);//人数変更
    }
    private void Result()
    {
        for (int i = 0; i < num; i++)
            score[i] = handCount[i];
    }
}
