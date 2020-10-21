using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCommand : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;

    void Update()
    {
        PlayerSkillChange();
        TonoOnly();
        CardChange();
    }

    private void PlayerSkillChange()
    {
        //デバッグコマンド天皇
        if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.Keypad1))
        {
            RuleManager.instance.PlayerList[0].RuleList[0].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[1].RuleList[0].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[2].RuleList[0].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[3].RuleList[0].RuleEfect[0] = 1;
        }
        if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.Keypad2))
        {
            RuleManager.instance.PlayerList[0].RuleList[0].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[1].RuleList[0].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[2].RuleList[0].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[3].RuleList[0].RuleEfect[0] = 2;
        }

        //デバッグコマンド段付き
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Keypad1))
        {
            RuleManager.instance.PlayerList[0].RuleList[0].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[1].RuleList[0].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[2].RuleList[0].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[3].RuleList[0].RuleEfect[0] = 3;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Keypad2))
        {
            RuleManager.instance.PlayerList[0].RuleList[0].RuleEfect[0] = 4;
            RuleManager.instance.PlayerList[1].RuleList[0].RuleEfect[0] = 4;
            RuleManager.instance.PlayerList[2].RuleList[0].RuleEfect[0] = 4;
            RuleManager.instance.PlayerList[3].RuleList[0].RuleEfect[0] = 4;
        }

        //デバッグコマンド武官
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.Keypad1))
        {
            RuleManager.instance.PlayerList[0].RuleList[1].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[1].RuleList[1].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[2].RuleList[1].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[3].RuleList[1].RuleEfect[0] = 1;
        }
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.Keypad2))
        {
            RuleManager.instance.PlayerList[0].RuleList[1].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[1].RuleList[1].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[2].RuleList[1].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[3].RuleList[1].RuleEfect[0] = 2;
        }

        //デバッグコマンド弓持ち
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RuleManager.instance.PlayerList[0].RuleList[1].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[1].RuleList[1].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[2].RuleList[1].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[3].RuleList[1].RuleEfect[0] = 3;
        }

        //デバッグコマンド蝉丸
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Keypad0))
        {
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 0;
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 0;
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 0;
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 0;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Keypad1))
        {
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 1;
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 1;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Keypad2))
        {
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 2;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Keypad3))
        {
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 3;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Keypad4))
        {
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 4;
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 4;
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 4;
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 4;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Keypad5))
        {
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 5;
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 5;
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 5;
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 5;
        }
    }

    private void TonoOnly()
    {
        if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.C))
        {
            for (int i = 0; i < deck.cards1.Count; i++)
            {
                deck.cards1[i] = Random.Range(22, 30);
            }
        }
    }


    private void CardChange()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            draw.effect1Num = 0;
            draw.fieldEffectNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.T))
        {
            deck.cards1[0] = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.D))
        {
            deck.cards1[0] = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.B))
        {
            deck.cards1[0] = 11;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Y))
        {
            deck.cards1[0] = 11;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.S))
        {
            deck.cards1[0] = 10;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.H))
        {
            deck.cards1[0] = 9;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.T))
        {
            deck.cards2[0] = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.D))
        {
            deck.cards2[0] = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.B))
        {
            deck.cards2[0] = 11;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.Y))
        {
            deck.cards2[0] = 11;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.S))
        {
            deck.cards2[0] = 10;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.H))
        {
            deck.cards2[0] = 9;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Keypad0))
        {
            int x = deck.cards1.Count;
            for (int i = 0; i < x; i++)
            {
                deck.cards1.RemoveAt(0);//0番目を削除
            }
            draw.TextChange();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.Keypad0))
        {
            int y = deck.cards2.Count;
            for (int i = 0; i < y; i++)
            {
                deck.cards2.RemoveAt(0);//0番目を削除
            }
            draw.TextChange();
        }
    }

    //private void FieldSkill3Debug()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        int c1 = deck.cards1.Count;
    //        for (int i = 4; i < c1; i++)
    //        {
    //            deck.cards1.RemoveAt(0);
    //        }
    //        for (int i = 0; i < deck.cards1.Count; i++)
    //        {
    //            deck.cards1[i] = Random.Range(22, 30);
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        int c2 = deck.cards2.Count;
    //        for (int i = 4; i < c2; i++)
    //        {
    //            deck.cards2.RemoveAt(0);
    //        }
    //        for (int i = 0; i < deck.cards2.Count; i++)
    //        {
    //            deck.cards2[i] = Random.Range(22, 30);
    //        }
    //    }
    //}

    //private void ReverseArrowDebug()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        draw.fieldEffectNum = 0;

    //        RuleCreate.instance.cardType[0] = 1;
    //        RuleCreate.instance.cardType[1] = 1;
    //        RuleCreate.instance.cardType[2] = 1;
    //        RuleCreate.instance.cardType[3] = 1;

    //        RuleCreate.instance.cardEffect[0] = 5;
    //        RuleCreate.instance.cardEffect[1] = 5;
    //        RuleCreate.instance.cardEffect[2] = 5;
    //        RuleCreate.instance.cardEffect[3] = 5;

    //        RuleCreate.instance.myRule[0] = true;
    //        RuleCreate.instance.myRule[1] = true;
    //        RuleCreate.instance.myRule[2] = true;
    //        RuleCreate.instance.myRule[3] = true;
    //    }
    //}

    //private void MyRule()
    //{
    //    RuleManager.instance.PlayerList[0].RuleList[1].RuleEfect[0] = 2;
    //    RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 2;

    //    RuleManager.instance.PlayerList[1].RuleList[0].RuleEfect[0] = 2;
    //    RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 3;

    //    RuleManager.instance.PlayerList[2].RuleList[1].RuleEfect[0] = 2;
    //    RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 4;

    //    RuleManager.instance.PlayerList[3].RuleList[0].RuleEfect[0] = 4;
    //    RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 0;


    //    //Debug.LogError("");
    //    RuleCreate.instance.cardType[0] = 1;
    //    RuleCreate.instance.cardType[1] = 3;
    //    RuleCreate.instance.cardType[2] = 2;
    //    RuleCreate.instance.cardType[3] = 4;

    //    RuleCreate.instance.cardEffect[0] = 6;
    //    RuleCreate.instance.cardEffect[1] = 5;
    //    RuleCreate.instance.cardEffect[2] = 2;
    //    RuleCreate.instance.cardEffect[3] = 5;

    //    //RuleCreate.instance.cardNum[0] = 5;
    //    //RuleCreate.instance.cardNum[1] = 5;
    //    RuleCreate.instance.cardNum[2] = 0;
    //    //RuleCreate.instance.cardNum[3] = 5;

    //    //RuleCreate.instance.playerNum[0] = 5;
    //    //RuleCreate.instance.playerNum[1] = 5;
    //    //RuleCreate.instance.playerNum[2] = 5;
    //    //RuleCreate.instance.playerNum[3] = 5;

    //    RuleCreate.instance.myRule[0] = true;
    //    RuleCreate.instance.myRule[1] = true;
    //    RuleCreate.instance.myRule[2] = true;
    //    RuleCreate.instance.myRule[3] = true;

    //    RuleCreate.instance.ruleName[0] = "自作壱";
    //    RuleCreate.instance.ruleName[1] = "自作弐";
    //    RuleCreate.instance.ruleName[2] = "自作参";
    //    RuleCreate.instance.ruleName[3] = "自作肆";

    //}
}