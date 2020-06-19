using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldFlag : MonoBehaviour
{
    public static FieldFlag instance;

    [SerializeField]
    private bool AllDrawAdd1;//すべての引く数が+1
    [SerializeField]
    private bool HandDistribution;//手札入れ替え
    [SerializeField]
    private bool CemeteryAdd3;//山札引いた後捨て札+3

    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;

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

    //フラグの初期化
    public void reset()
    {
        AllDrawAdd1 = false;
        HandDistribution = false;
        CemeteryAdd3 = false;
    }
    /// <summary>
    /// 手札シャッフル
    /// </summary>
    public void Distribution()
    {
        //for(hand.handCount.Length)
    }
}
