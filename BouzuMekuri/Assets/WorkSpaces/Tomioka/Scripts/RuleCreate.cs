using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleCreate : SingletonMonoBehaviour<RuleCreate>
{
    //カードの種類(天皇・段付き・武官・弓持ち・偉い姫の順で1～5)
    [Header("天皇・段付き・武官・弓持ち・偉い姫の順で1～5")]
    public List<int> cardType;

    //カードの効果(カードをもらう・カードを引く・場に置く・一回休み・逆回り・効果無効の順で1～6)
    [Header("もらう・引く・捨てさせる・休み・逆回り・効果無効の順で1～6")]
    public List<int> cardEffect;

    //スキルの対象枚数
    [Header("対象枚数(休み・逆回り・効果無効のみ例外)")]
    [Header("※引くの場合0で1枚引く")]
    public List<int> cardNum;

    //スキルの対象人数
    [Header("対象人数(引く・逆回り・効果無効のみ例外)")]
    public List<int> playerNum;

    [Header("自作ルールを持っているか")]
    public List<bool> myRule;


    public int PlayerNumber = 0;

    private void Start()
    {
        if (instance != null)
        {
            DontDestroyOnLoad(this);
        }
    }
}
