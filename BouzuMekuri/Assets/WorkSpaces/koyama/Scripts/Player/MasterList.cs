using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using System;

public class MasterList : MonoBehaviour
{
    public List<List<int>> list = new List<List<int>>();
    //人数の列挙
    public enum Player
    {
        player1 = 0,
        player2,
        player3,
        player4
    }
    //プレイヤーの人数分配列の宣言
    public PlayerModel[] playerModels = new PlayerModel[4]
    {
        new PlayerModel(),
        new PlayerModel(),
        new PlayerModel(),
        new PlayerModel()
    };
    private void Start()
    {
        foreach(var pmodel in playerModels)
        {
            var max = Random.Range(3, 6);
            for(int i = 0; i < max; i++)
            {
                pmodel.Card.Add(Random.Range(5, 10));
            }
        }
    }
    public void Awake()
    {/*
        //プレイヤーリスト
        foreach (var value in Enum.GetValues(typeof(Player)))
        {
            playerlist.Add((Player)value);
        }

        foreach (var num in playerlist)
        {
            UnityEngine.Debug.LogFormat("playerlist [{0}]:{1}",(int)num,num);
        }
        /*
        list.Add(new List<int>());
        for (int k = 0; k < 4; k++)
        {
            list[k].Add(k+1);
            UnityEngine.Debug.Log(list);
        }*/
    }
    //手札の数の枚数をランダムに並び替え
    public void Shuffle1()
    {
        if (list.Count > 0)
        {
            list.ForEach(cardList => cardList.Clear());
            list.Clear();
        }
        foreach (var pmodel in playerModels)
        {
            list.Add(pmodel.Card);
        }
        var countList = list.Select(cardList => cardList.Count).ToList();//countListにcardListの数を格納
        List<int> totalList = new List<int>();//要素の格納リストの宣言
        list.ForEach(cardList => totalList.AddRange(cardList));//リストに要素を全部格納
        /*
        //1pの1枚目を表示
        UnityEngine.Debug.Log(list[0][0]);
        //int count = playerlist.Count;

        for (int s = 0; s < playerlist.Count; s++)
        {
            list = list.OrderBy(a => Guid.NewGuid()).ToList();
            UnityEngine.Debug.LogFormat("#{0}P:{1}枚",s+1);
        }
        return;
        
        

        /*
        for (int i = 0; i < _1.card.Count; i++)
        {
            list[0].Add(_1.card[i]);
        }
        /*
        list[0] = _1.card;
        List<int> e = new List<int>();
        for(int i = 0; i < _1.card.count; i++)
        {
            e.Add(i);
        }
        list[1] = _2.card;
        list[2] = _3.card;
        list[3] = _4.card;
        for(int i = 0; i <4; i++)
        {
            UnityEngine.Debug.LogFormat("#{0}P:{1}", i + 1, list[i]);
        }*/

        /*
        //p1の枚数を追加
        var list1 = new List<int>();
        list1.Add(_1.card.Count);
        //p2の枚数を追加
        var list2 = new List<int>(list1);
        list2.Add(_2.card.Count);
        //p3の枚数を追加
        var list3 = new List<int>(list2);
        list3.Add(_3.card.Count);
        //p4の枚数を追加
        var list4 = new List<int>(list3);
        list4.Add(_4.card.Count);

         //現在枚数表示
        for (int i = 0; i < list4.Count; i++)
        {
            UnityEngine.Debug.LogFormat("#{0}P:{1}枚",i+1,list4[i]);
        }
        //人数をカウント
        int count = list4.Count;

        for(int s = 0; s < count; s++)
        {
            //ランダムで値を結果リストに入れる
            var list5 = list4[UnityEngine.Random.Range(0, list4.Count)];
            //上記の値を全体リストから消去
            list4.Remove(list5);
            UnityEngine.Debug.LogFormat("#{0}P:{1}枚", s + 1, list5);
            /*
            _1.card = list5;
            _2.card = list5;
            _3.card = list5;
            _4.card = list5;
            UnityEngine.Debug.Log(_1.card);
            UnityEngine.Debug.Log(_2.card);
            UnityEngine.Debug.Log(_3.card);
            UnityEngine.Debug.Log(_4.card);
       
        }
        //_1.card = list5[0];
        //_2.card = list5[1];
        //_3.card = list5[2];
        //_4.card = list5[3];
        //UnityEngine.Debug.Log(_1.card);
        //UnityEngine.Debug.Log(_2.card);
        //UnityEngine.Debug.Log(_3.card);
        //UnityEngine.Debug.Log(_4.card);
        //*/
    }
    //未完成
    public void Shuffle2()
    {

        //int[] list1 = new int[]
    }
}
