using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

<<<<<<< .merge_file_a06252
public class MasterList : MonoBehaviour
{
    public static MasterList Instance;

=======
public class MasterList : SingletonMonoBehaviour<MasterList>
{
>>>>>>> .merge_file_a08540
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

<<<<<<< .merge_file_a06252
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
=======
>>>>>>> .merge_file_a08540
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
<<<<<<< .merge_file_a06252
=======
        if(instance != null)
        {
            DontDestroyOnLoad(this);
        }
>>>>>>> .merge_file_a08540

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
<<<<<<< .merge_file_a06252
            ////範囲内の値を移動させるまでループ
            //while (index>0) 
            //{
            //    //index番目の値をコピーする
            //    int r = totalList[0];
            //    //index番目を中身に入れる
            //    list[i].Add(r);
            //    //index番目を除外する
            //    totalList.RemoveAt(0);
            //    index--;
            //}
=======
>>>>>>> .merge_file_a08540
        }
        //余りを全部4Pへ
        list[3].Clear();
        list[3].AddRange(totalList);
        totalList.Clear();
<<<<<<< .merge_file_a06252
        //for (int z = 0; z < totalList.Count; z++)
        //{
        //    int r = totalList[0];
        //    list[3].Add(r);
        //    totalList.RemoveAt(0);
        //}

=======
>>>>>>> .merge_file_a08540
    }
}
