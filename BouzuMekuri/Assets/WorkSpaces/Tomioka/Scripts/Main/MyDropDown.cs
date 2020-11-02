using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDropDown : MonoBehaviour
{
    [SerializeField]
    private Dropdown CardType;
    [SerializeField]
    private Dropdown CardTypeT;
    [SerializeField]
    private Dropdown CardTypeB;
    [SerializeField]
    private Dropdown CardTypeAll;
    [SerializeField]
    private Dropdown CardEffect;
    [SerializeField]
    private Dropdown CardNum;
    [SerializeField]
    private Dropdown CardNum13;
    [SerializeField]
    private Dropdown PlayerNum;
    [SerializeField]
    private Dropdown PlayerNum12;

    private void Start()
    {
        SoundManager.instance.BgmApply(Bgm.RuleEditor);
    }

    public void Type()
    {
        if (CardType.value == 0)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 0;
        }
        //天皇
        else if (CardType.value == 1)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 1;
        }
        //段付き
        else if (CardType.value == 2)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 2;
        }
        //武官
        else if (CardType.value == 3)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 3;
        }
        //弓持ち
        else if (CardType.value == 4)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 4;
        }
        //偉い姫
        else if (CardType.value == 5)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 5;
        }
    }
    public void TypeT()
    {
        if (CardTypeT.value == 0)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 0;
        }
        //武官
        else if (CardTypeT.value == 1)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 3;
        }
        //弓持ち
        else if (CardTypeT.value == 2)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 4;
        }
        //偉い姫
        else if (CardTypeT.value == 3)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 5;
        }
    }
    public void TypeB()
    {
        if (CardTypeB.value == 0)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 0;
        }
        //天皇
        else if (CardTypeB.value == 1)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 1;
        }
        //段付き
        else if (CardTypeB.value == 2)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 2;
        }
        //偉い姫
        else if (CardTypeB.value == 3)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 5;
        }
    } 
    
    public void TypeAll()
    {
        if (CardTypeAll.value == 0)
        {
            RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 0;
        }
        //偉い姫
        else if (CardTypeAll.value == 1)
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
        //もらう
        else if (CardEffect.value == 1)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 1;
        }
        //引く
        else if (CardEffect.value == 2)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 2;
        }
        //捨てる
        else if (CardEffect.value == 3)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 3;
        }
        //休み
        else if (CardEffect.value == 4)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 4;
        }
        //逆回転
        else if (CardEffect.value == 5)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 5;
        }
        //効果無効
        else if (CardEffect.value == 6)
        {
            RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 6;
        }
    }

    public void CardNumber()
    {
        if (CardNum.value == 0)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 1;
        }
        else if (CardNum.value == 1)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 2;
        }
        else if (CardNum.value == 2)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 3;
        }
        else if (CardNum.value == 3)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 4;
        }
        else if (CardNum.value == 4)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 5;
        }
    }
    
    public void CardNumber13()
    {
        if (CardNum13.value == 0)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 1;
        }
        else if (CardNum13.value == 1)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 2;
        }
        else if (CardNum13.value == 2)
        {
            RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 3;
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
    public void PlayerNumber12()
    {
        if (PlayerNum12.value == 0)
        {
            RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 1;
        }
        else if (PlayerNum12.value == 1)
        {
            RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 2;
        }
    }

    public void Decision()
    {
        RuleCreate.instance.myRule[RuleCreate.instance.PlayerNumber] = true;
        SoundManager.instance.SeApply(Se.choice);
        //SceneController.instance.LoadScene(SceneController.SceneName.Rule);
    }
    public void Back()
    {
        RuleCreate.instance.myRule[RuleCreate.instance.PlayerNumber] = false;
        //SceneController.instance.LoadScene(SceneController.SceneName.Rule);
        RuleCreate.instance.cardType[RuleCreate.instance.PlayerNumber] = 0;
        RuleCreate.instance.cardNum[RuleCreate.instance.PlayerNumber] = 1;
        RuleCreate.instance.cardEffect[RuleCreate.instance.PlayerNumber] = 0;
        RuleCreate.instance.playerNum[RuleCreate.instance.PlayerNumber] = 1;
        SoundManager.instance.SeApply(Se.choice);
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
