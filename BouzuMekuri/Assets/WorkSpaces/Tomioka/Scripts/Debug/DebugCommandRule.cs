using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCommandRule : MonoBehaviour
{
    void Update()
    {
        Debug();
    }

    private void Debug()
    {
        //
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneController.instance.LoadScene(SceneController.SceneName.Main);

            RuleManager.instance.PlayerList[0].RuleList[0].RuleEfect[0] = Random.Range(0, 5);
            RuleManager.instance.PlayerList[0].RuleList[1].RuleEfect[0] = Random.Range(0, 4);
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = Random.Range(0, 6);

            RuleManager.instance.PlayerList[1].RuleList[0].RuleEfect[0] = Random.Range(0, 5);
            RuleManager.instance.PlayerList[1].RuleList[1].RuleEfect[0] = Random.Range(0, 4);
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = Random.Range(0, 6);

            RuleManager.instance.PlayerList[2].RuleList[0].RuleEfect[0] = Random.Range(0, 5);
            RuleManager.instance.PlayerList[2].RuleList[1].RuleEfect[0] = Random.Range(0, 4);
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = Random.Range(0, 6);

            RuleManager.instance.PlayerList[3].RuleList[0].RuleEfect[0] = Random.Range(0, 5);
            RuleManager.instance.PlayerList[3].RuleList[1].RuleEfect[0] = Random.Range(0, 4);
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = Random.Range(0, 6);

        }
        //
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneController.instance.LoadScene(SceneController.SceneName.Main);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SoundManager.instance.SeApply(Se.semimaruSkill);
        }
    }
}
