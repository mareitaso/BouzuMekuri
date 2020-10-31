using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoRule : MonoBehaviour
{
    private int TDnum, BYnum, Snum;

    [SerializeField]
    private Dropdown TDmenu, BYmenu, Teffect, Deffect, Beffect, Yeffect, Seffect;

    [SerializeField]
    private RulePullDown rulePullDown;
    public void Auto()
    {
        rulePullDown.AutoFlag = true;
        RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = Random.Range(0, 5);
        RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = Random.Range(0, 4);
        RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = Random.Range(0, 6);
        TDnum = RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0];
        BYnum = RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0];
        Snum = RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0];
        ActiveMenu();
        if (TDnum == 0 && BYnum == 0)
        {
            rulePullDown.AutoFlag = false;
        }
    }

    private void ActiveMenu()
    {
        switch (TDnum)
        {
            case 0:
                TDmenu.value = 0;
                Teffect.value = 0;
                break;

            case 1:
                TDmenu.value = 1;
                Teffect.value = 1;
                break;
                
            case 2:
                TDmenu.value = 1;
                Teffect.value = 2;
                break;
                
            case 3:
                TDmenu.value = 2;
                Teffect.value = 1;
                break;

            case 4:
                TDmenu.value = 2;
                Teffect.value = 2;
                break;

            default:
                Debug.LogError("天皇段付きの値がおかしい");
                break;
        }

        switch (BYnum)
        {
            case 0:
                BYmenu.value = 0;
                Beffect.value = 0;
                break;

            case 1:
                BYmenu.value = 1;
                Beffect.value = 1;
                break;

            case 2:
                BYmenu.value = 1;
                Beffect.value = 2;
                break;

            case 3:
                BYmenu.value = 2;
                Yeffect.value = 1;
                break;

            default:
                Debug.LogError("武官弓持ちの値がおかしい");
                break;
        }

        switch (Snum)
        {

            case 0:
                Seffect.value = 0;
                break;

            case 1:
                Seffect.value = 1;
                break;

            case 2:
                Seffect.value = 2;
                break;

            case 3:
                Seffect.value = 3;
                break;

            case 4:
                Seffect.value = 4;
                break;

            case 5:
                Seffect.value = 5;
                break;
        }
    }
}
