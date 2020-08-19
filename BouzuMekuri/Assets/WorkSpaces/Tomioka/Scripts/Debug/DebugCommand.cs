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

    [SerializeField]
    private Text count;

    void Update()
    {
        count.text = (deck.Count + 1).ToString();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            int x = deck.cards1.Count - 2;
            for (int i = 0; i < x; i++)
            {
                deck.cards1.RemoveAt(0);//0番目を削除
            }
            deck.cards2[0] = 10;
            draw.TextChange();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            deck.cards2[0] = 10;
            draw.TextChange();
        }

        PlayerSkillChange();
        TonoOnly();
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
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Keypad3))
        {
            RuleManager.instance.PlayerList[0].RuleList[2].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[1].RuleList[2].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[2].RuleList[2].RuleEfect[0] = 3;
            RuleManager.instance.PlayerList[3].RuleList[2].RuleEfect[0] = 3;
        }
    }

    private void TonoOnly()
    {
        if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.C))
        {
            for (int i = 0; i < deck.cards1.Count; i++)
            {
                deck.cards1[i] = Random.Range(22,30);
            }

            RuleManager.instance.PlayerList[0].RuleList[1].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[1].RuleList[1].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[2].RuleList[1].RuleEfect[0] = 2;
            RuleManager.instance.PlayerList[3].RuleList[1].RuleEfect[0] = 2;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            deck.cards1[0] = 30;
        }
    }
}
