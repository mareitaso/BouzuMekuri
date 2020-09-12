using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class HandCount : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private List<Ranking> rankLists = new List<Ranking>()
    {
        new Ranking(){Name = "P1",Score = MasterList.instance.list[0].Count},
        new Ranking(){Name = "P2",Score = MasterList.instance.list[1].Count},
        new Ranking(){Name = "P3",Score = MasterList.instance.list[2].Count},
        new Ranking(){Name = "P4",Score = MasterList.instance.list[3].Count},
    };
    public void Settlement()//順位決定
    {
        var rankSort = rankLists.OrderBy(x => x.Name)
            .OrderByDescending(x => x.Score)
            .ToList();
        string txt = "";
        foreach (var rank in rankSort.Select((data, index) => new { index, data }))
        {
            txt += string.Format("{0} 位  {1} ... {2} 枚", rank.index + 1,
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
}