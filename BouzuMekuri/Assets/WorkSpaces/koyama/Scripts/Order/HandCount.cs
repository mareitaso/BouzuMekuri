using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class HandCount : MonoBehaviour
{
    public GameObject score_object1 = null;//テキスト
    public GameObject score_object2 = null;//テキスト
    public GameObject score_object3 = null;//テキスト
    public GameObject score_object4 = null;//テキスト

    //private const int Max = 100;//所持札の最大数
    private static int num =4;//参加最大人数
    private int[] score = new int[num];//人数分の点数データ
    //private int[] rank = new int[num];//人数分の順位データ
    //private int[] count = new int[Max + 1];//A点の人の数
    //private int[] Rank = new int[Max + 1];//A点の人の順位
    //private int[] player = new int[num];


    public void Settlement()//順位決定
    {
        Result();

        var rankings = new Ranking[]
        {
            new Ranking()
            {
                Name = "P1",
                Score = score[0],
            },
            new Ranking()
            {
                Name = "P2",
                Score = score[1],
            },
            new Ranking()
            {
                Name = "P3",
                Score = score[2],
            },
            new Ranking()
            {
                Name = "P4",
                Score = score[3],
            },
        };

        var ranking = from s1 in rankings
                      let higher = from s2 in rankings //現在のプレイヤーより点数がよいプレイヤーを取得
                                   where s2.Score > s1.Score
                                   select s2
                      select new
                      {
                          s1.Name,
                          s1.Score,
                          Rank = higher.Count() + 1,//現在の点数より高い点数の人数+1が順位
                      } into s3
                      orderby s3.Rank//順位で並べ替え
                      select s3;

        Text text1 = score_object1.GetComponent<Text>();
        Text text2 = score_object2.GetComponent<Text>();
        Text text3 = score_object3.GetComponent<Text>();
        Text text4 = score_object4.GetComponent<Text>();

        foreach (var Rankings in ranking)
        {
            Debug.LogFormat("{0}位 {1} {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);

            if(Rankings.Rank == 1)
            {
                text1.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
            }
            if(Rankings.Rank == 2)
            {
                text2.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
            }
            if (Rankings.Rank == 3)
            {
                text3.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
            }
            if (Rankings.Rank == 4)
            {
                text4.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
            }
            /*
            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                {
                    text1.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
                }
                else if (i == 1)
                {
                    text2.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
                }
                else if (i == 2)
                {
                    text3.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
                }
                else if (i == 3)
                {
                    text4.text = string.Format("{0}位 {1} ... {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
                }
            }*/
        }
        /*
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
        {
            player[i] = score[i];
        }

         Array.Sort(score);
         Array.Reverse(score);

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
        }*/
        return;

    }
    private void Start()
    {
        Settlement();
    }
    private void Result()
    {
        for (int i = 0; i < 4; i++)
            score[i] = MasterList.instance.list[i].Count;
    }
    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            ReSetCommand.instance.ReSet();
        }
    }
}

class Ranking
{
    public string Name { get; set; }
    public int Score { get; set; }
}