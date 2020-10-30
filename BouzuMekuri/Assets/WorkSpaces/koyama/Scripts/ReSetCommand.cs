using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSetCommand : SingletonMonoBehaviour<ReSetCommand>
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void ReSet()
    {
        MasterList.instance.Start();
        RuleCreate.instance.PlayerNumber = 0;
        RuleManager.instance.PlayerList[0].RuleList[0].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[0].RuleList[1].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[1].RuleList[0].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[1].RuleList[1].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[2].RuleList[0].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[2].RuleList[1].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[3].RuleList[0].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[3].RuleList[1].RuleEfect[0] = 0;
        RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 0;

        RuleCreate.instance.myRule[0] = false;
        RuleCreate.instance.myRule[1] = false;
        RuleCreate.instance.myRule[2] = false;
        RuleCreate.instance.myRule[3] = false;

        RulePullDown.Pflag = false;

        SceneController.instance.LoadScene(SceneController.SceneName.Title);
    }
}
