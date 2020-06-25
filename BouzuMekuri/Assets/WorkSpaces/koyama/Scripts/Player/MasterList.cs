using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MasterList : MonoBehaviour
{
    [SerializeField]
    private Player_1 _1;
    [SerializeField]
    private Player_2 _2;
    [SerializeField]
    private Player_3 _3;
    [SerializeField]
    private Playey_4 _4;

    [SerializeField]
    List<string> list;

    //手札の数の枚数をランダムに並び替え
    public void Shuffle1()
    {   
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
            Debug.LogFormat("#{0}P:{1}枚",i+1,list4[i]);
        }
        //人数をカウント
        int count = list4.Count;

        for(int s = 0; s < count; s++)
        {
            //ランダムで値を結果リストに入れる
            var list5 = list4[UnityEngine.Random.Range(0, list4.Count)];
            //上記の値を全体リストから消去
            list4.Remove(list5);
            Debug.LogFormat("#{0}P:{1}枚", s + 1, list5);
        }
        
    }
    //未完成
    public void Shuffle2()
    {
        //リストをランダムに並べ替える
        list = list.OrderBy(a => Guid.NewGuid()).ToList();
        foreach(var item in list)
        {
            Debug.Log(item);
        }
    }
}
