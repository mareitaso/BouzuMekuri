using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Dynamic;

public class HandCount : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private List<Ranking> rankLists = new List<Ranking>()
    {
        new Ranking(){Name = "プレイヤー1",Score = MasterList.instance.list[0].Count,Rank = 0},
        new Ranking(){Name = "プレイヤー2",Score = MasterList.instance.list[1].Count,Rank  =0},
        new Ranking(){Name = "プレイヤー3",Score = MasterList.instance.list[2].Count,Rank = 0},
        new Ranking(){Name = "プレイヤー4",Score = MasterList.instance.list[3].Count,Rank = 0},
    };
    public void Settlement()//順位決定
    {
        //点数順、名前順

        /*
        var rankSort = rankLists.OrderBy(x => x.Name)
            .OrderByDescending(x => x.Score)
            .ToList();

        */
        var ranking = from s1 in rankLists
                      let higher = from s2 in rankLists //現在のプレイヤーより点数がよいプレイヤーを取得
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
        /*
        foreach(var Rankings in ranking)
        {
            Debug.LogFormat("{0}位 {1} {2} 点", Rankings.Rank, Rankings.Name, Rankings.Score);
        }
        */
        string txt = "";

        foreach (var rank in ranking.Select((data,index) => new { index,data }))
        {
            txt += string.Format("{0}位\n {1}... {2}枚",rank.data.Rank ,
                rank.data.Name, rank.data.Score) + Environment.NewLine;
        }
        text.text = txt;
    }
    private void Start()
    {
        Settlement();
    }
    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            ReSetCommand.instance.ReSet();
        }
    }
}

class Ranking
{
    public string Name { get; set; } = "";
    public int Score { get; set; } = 0;
    public int Rank { get; set; } = 0;
}