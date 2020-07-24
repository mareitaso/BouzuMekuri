using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RuleData",menuName ="Data/RuleData")]
public class RuleData : ScriptableObject
{
    public List<Rule> ruleDataList = new List<Rule>();
    public List<Rule> RulesList()
    {
        return ruleDataList;
    }
}
[System.Serializable]
public class Rule
{
    public string ruleName; //ルール名
    public string Name => ruleName;

    public First first;
    //public First GetFirst => first;
    public First GetFirst()
    {
        return first;
    }

    public Second second;
    //public Second GetSecond => second;
    public Second GetSecond()
    {
        return second;
    }
    
    public Third third;
    //public Third GetThird => third;
    public Third GetThird()
    {
        return third;
    }
    
    public int no;//ルール番号
    public int No => no;
}

public enum First
{
    None = 0,
    Tennou,
    Dantuki
}
public enum Second
{
    None = 0,
    Bukan,
    Yumimoti
}
public enum Third
{
    None = 0,
    Semimaru
}
