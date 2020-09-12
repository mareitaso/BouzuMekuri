using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RuleManager : SingletonMonoBehaviour<RuleManager>
{
    private void Start()
    {
        if(instance != null)
        {
            DontDestroyOnLoad(this);
        }
    }
    //Inspectorに複数データを表示するためのクラス
    [System.SerializableAttribute]
    public class ValueList
    {
        [Header ("カードの効果")]
        public List<int> RuleEfect = new List<int>();

        public ValueList(List<int> list)
        {
            RuleEfect = list;
        }
    }
    
    [System.SerializableAttribute]
    public class ValueList2
    {
        [Header("カードの種類")]
        public List<ValueList> RuleList = new List<ValueList>();

        public ValueList2(List<ValueList> list)
        {
            RuleList = list;
        }
    }

    //Inspectorに表示される
    [SerializeField]
    [Header("プレイヤー")]
    public List<ValueList2> PlayerList = new List<ValueList2>();
    //public List<List<int>> lists = new List<List<int>>();
    //ルールの列挙
}
