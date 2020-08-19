using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MasterList : SingletonMonoBehaviour<MasterList>
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

    public void Start()
    {
        //リストの初期化
        if (list.Count > 0)
        {
            list.ForEach(cardList => cardList.Clear());
            list.Clear();
        }
        //リストに追加
        foreach (var pmodel in playerModels)
        {
            list.Add(pmodel.Card);
        }
        if(instance != null)
        {
            DontDestroyOnLoad(this);
        }

    }
    //手札のカード番号と枚数をランダムに並び替え
    public void Shuffle1()
    {
        //countListにcardListの数を格納
        var countList = list.Select(cardList => cardList.Count).ToList();
        //要素の格納リストの宣言
        List<int> totalList = new List<int>();
        //リストに要素を全部格納
        list.ForEach(cardList => totalList.AddRange(cardList));
    }
    //ランダムに振り分け
    public void Shuffle2()
    {
        //要素の格納リストの宣言
        List<int> totalList = new List<int>();
        //リストに要素を全部格納
        list.ForEach(cardList => totalList.AddRange(cardList));
        //シャッフル用の乱数
        System.Random rnd = new System.Random();
        //長さをコピー
        int n = totalList.Count;
        //シャッフル
        while(n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            int tmp = totalList[k];
            totalList[k] = totalList[n];
            totalList[n] = tmp;
        }
        //1Pから3P分のランダム判定
        for(int i = 0; i <3; i++)
        {
            //範囲を決める
            int index = UnityEngine.Random.Range(0,totalList.Count);
            //中身を空にする
            list[i].Clear();
            list[i].AddRange(totalList.GetRange(0, index));
            totalList.RemoveRange(0, index);
        }
        //余りを全部4Pへ
        list[3].Clear();
        list[3].AddRange(totalList);
        totalList.Clear();
    }
}
