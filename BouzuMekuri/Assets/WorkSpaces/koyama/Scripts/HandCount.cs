using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HandCount : MonoBehaviour
{
    //[SerializeField]
    //public int[] handCount; //4人分の手札
    //[SerializeField]
    //private Deck deck;
    public GameObject score_object1 = null;//テキスト
    public GameObject score_object2 = null;//テキスト
    public GameObject score_object3 = null;//テキスト
    public GameObject score_object4 = null;//テキスト

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
        Array.Clear(count, 0, Max);//得点別の配列をクリア
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

        Text text1 = score_object1.GetComponent<Text>();
        Text text2 = score_object2.GetComponent<Text>();
        Text text3= score_object3.GetComponent<Text>();
        Text text4 = score_object4.GetComponent<Text>();
        for (int i = 0; i < num; i++)
        {
            if(i == 0)
            {
                text1.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            }else if(i == 1)
            {
                text2.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            }else if(i == 2)
            {
                text3.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            }else if(i == 3)
            {
                text4.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            }

            /*
            text1.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            text2.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            text3.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            text4.text = string.Format("{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
            */
        }
            //text1.text = string.Format("#{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);

        //Debug.LogFormat("#{0}P: {1}枚 ... {2}位", i+1, score[i], rank[i]+1);
        //text.text = string.Format("#{0}P: {1}枚 ... {2}位", i + 1, score[i], rank[i] + 1);
        return;
    }
    private void Update()
    {
        Settlement();
    }
    private void Result()
    {
        for (int i = 0; i < num; i++)
            score[i] = MasterList.Instance.list[i].Count;
            //score[i] += i + 10; 
    }
}
