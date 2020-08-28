using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
<<<<<<< .merge_file_a06556
using System;

public class RuleManager : MonoBehaviour
{
    public static RuleManager instance;

=======

public class RuleManager : SingletonMonoBehaviour<RuleManager>
{
    private void Start()
    {
        if(instance != null)
        {
            DontDestroyOnLoad(this);
        }
    }
>>>>>>> .merge_file_a15532
    //Inspectorに複数データを表示するためのクラス
    [System.SerializableAttribute]
    public class ValueList
    {
        public List<int> RuleEfect = new List<int>();

        public ValueList(List<int> list)
        {
            RuleEfect = list;
        }
    }
    
    [System.SerializableAttribute]
    public class ValueList2
    {
        public List<ValueList> RuleList = new List<ValueList>();

        public ValueList2(List<ValueList> list)
        {
            RuleList = list;
        }
    }

    //Inspectorに表示される
    [SerializeField]
    public List<ValueList2> PlayerList = new List<ValueList2>();
    //public List<List<int>> lists = new List<List<int>>();
    //ルールの列挙
<<<<<<< .merge_file_a06556

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
=======
>>>>>>> .merge_file_a15532
}
