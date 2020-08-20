using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleCreate : SingletonMonoBehaviour<RuleCreate>
{
    //カードの種類(天皇・段付き・武官・弓持ち・偉い姫の順)
    public List<int> cardType;
    //カードの効果(何枚引く等)
    public List<int> cardEffect;
    //スキルの対象枚数
    public List<int> cardNum;
    //スキルの対象人数
    public List<int> playerNum;

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
