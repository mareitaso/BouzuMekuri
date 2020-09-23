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
        RuleCreate.instance.PlayerNumber = 0;
        SoundManager.instance.FadeOutBgm(0);
        SceneController.instance.LoadScene(SceneController.SceneName.Title);
    }
}
