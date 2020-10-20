using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Dynamic;
using Unity.Collections.LowLevel.Unsafe;

public class HandCount : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Image image1;
    [SerializeField]
    private Image image2;
    [SerializeField]
    private Image image3;


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
        string txt = "";

        foreach (var rank in ranking.Select((data,index) => new { index,data }))
        {
            if (rank.data.Rank == 1)
            {
                image1.sprite = Resources.Load<Sprite>("Images/goldcrown");
                image2.sprite = Resources.Load<Sprite>("Images/goldcrown");
                image3.sprite = Resources.Load<Sprite>("Images/goldcrown");
            }
            else if(rank.data.Rank == 2)
            {
                image1.sprite = Resources.Load<Sprite>("Images/slivercrown");
                image2.sprite = Resources.Load<Sprite>("Images/slivercrown");
                image3.sprite = Resources.Load<Sprite>("Images/slivercrown");
            }
            else if (rank.data.Rank == 3)
            {
                image2.sprite = Resources.Load<Sprite>("Images/bronzecrown");
                image3.sprite = Resources.Load<Sprite>("Images/bronzecrown");
            }
            else
            {
                image3.sprite = Resources.Load<Sprite>("Images/Null");
            }

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