using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public partial class RuleFlag : MonoBehaviour
{
    public static RuleFlag Instance;

    /// <summary>
    /// ルールフラグ
    /// </summary>
    public bool Emperor = false;//天皇ルール
    public bool MilitaryOfficer = false;//武官ルール
    public bool Stepped = false;//段付きルール
    public bool Original = false;//オリジナルルール
    /// <summary>
    /// 自作ルール用の札フラグ
    /// </summary>
    public bool Emperors = false;//天皇札
    public bool MilitaryOfficers = false;//武官札
    public bool Steppeds = false;//段付き札
    public bool GreatPrincess = false;//偉い姫札
    public bool Holding_a_Bow = false;//弓持ちの男

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

    public void reset()//フラグの初期化
    {
        //ルール
        Emperor = false;
        MilitaryOfficer = false;
        Stepped = false;
        Original = false;
        //自作用の札
        Emperors = false;
        MilitaryOfficers = false;
        Steppeds = false;
        GreatPrincess = false;
        Holding_a_Bow = false;
    }
}