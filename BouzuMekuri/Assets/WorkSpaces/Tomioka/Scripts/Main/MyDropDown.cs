using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDropDown : MonoBehaviour
{
    [SerializeField]
    private Dropdown CardType;
    [SerializeField]
    private Dropdown CardEffect;
    [SerializeField]
    private Dropdown CardNum;
    [SerializeField]
    private Dropdown PlayerNum;

    private void Start()
    {
        SoundManager.instance.BgmApply(Bgm.RuleEditor);
    }

    public void Type()
    {
        if (CardType.value == 0)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 1;
        }
        else if (CardType.value == 1)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 2;
        }
        else if (CardType.value == 2)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 3;
        }
        else if (CardType.value == 3)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 4;
        }
        else if (CardType.value == 4)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 5;
        }
    }

    public void Effect()
    {
        if (CardEffect.value == 0)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 0;
        }
        else if (CardEffect.value == 1)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 1;
        }
        else if (CardEffect.value == 2)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 2;
        }
        else if (CardEffect.value == 3)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 3;
        }
        else if (CardEffect.value == 4)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 4;
        }
        else if (CardEffect.value == 5)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 5;
        }
    }

    public void CardNumber()
    {
        if (CardNum.value == 0)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 0;
        }
        else if (CardNum.value == 1)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 1;
        }
        else if (CardNum.value == 2)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 2;
        }
        else if (CardNum.value == 3)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 3;
        }
        else if (CardNum.value == 4)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 4;
        }
        else if (CardNum.value == 5)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 5;
        }
    }

    public void PlayerNumber()
    {
        if (PlayerNum.value == 0)
        {
            RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 1;
        }
        else if (PlayerNum.value == 1)
        {
            RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 2;
        }
        else if (PlayerNum.value == 2)
        {
            RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 3;
        }
    }

    public void Decision()
    {
        RuleCreate.instance.myRule[RuleCreate.instance.PlayerNumber] = true;
        //SceneController.instance.LoadScene(SceneController.SceneName.Rule);
    }
    public void Back()
    {
        RuleCreate.instance.myRule[RuleCreate.instance.PlayerNumber] = false;
        //SceneController.instance.LoadScene(SceneController.SceneName.Rule);
        RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 0;
        RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 0;
        RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 0;
        RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 0;
    }

    /// <summary>
    /// 他の効果で対象人数を3にしてから
    /// 効果を一回休みに変えるとそのまま3人を一回休みにできるため
    /// 変更した際に戻す処理
    /// </summary>
    public void PlayerNumReset()
    {
        RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 1;
    }
}
