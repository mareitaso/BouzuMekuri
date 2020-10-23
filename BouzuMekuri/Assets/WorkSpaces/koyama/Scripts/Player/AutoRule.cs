using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRule : MonoBehaviour
{
    [SerializeField]
    private RulePullDown rulePullDown;
    public void Auto()
    {
        rulePullDown.AutoFlag = true;
        RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = Random.Range(0, 5);
        RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = Random.Range(0, 4);
        RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = Random.Range(0, 6);

    }
}
