﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RulePullDown : MonoBehaviour
{
    //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown1;
    [SerializeField] private Dropdown dropdown2;
    [SerializeField] private Dropdown dropdown3;

    [SerializeField] private Dropdown Skilldown1;
    [SerializeField] private Dropdown Skilldown2;

    [SerializeField] private UnityEngine.UI.Button s;

    [SerializeField] private Dropdown SemimaruDrop;


    public int PlayerNumber = 0;

    // 天皇　段付き判定
    public void ChangeRule1()
    {
        //Dropdown1のValueが0のとき
        if (dropdown1.value == 0)
        {
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 0;
        }
        //Dropdown1のValueが1のとき
        else if (dropdown1.value == 1)
        {
            //隠しドロップダウン表示
            ChangeSkill1();
        }
        //Dropdown1のValueが2のとき
        else if (dropdown1.value == 2)
        {
            //隠しドロップダウン表示
            ChangeSkill1();
        }
        //PlayerNumber++;
    }

    // 武官　弓持ち判定
    public void ChangeRule2()
    {
        //Dropdown2のValueが0のとき
        if (dropdown2.value == 0)
        {
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 0;
        }
        //Dropdown2のValueが1のとき
        else if (dropdown2.value == 1)
        {
            //隠しドロップダウン表示
            ChangeSkill2();
        }
        //Dropdown2のValueが2のとき
        else if (dropdown2.value == 2)
        {
            //隠しドロップダウン表示
            ChangeSkill2();
        }
    }

    // 天皇　段付き判定
    public void ChangeRule3()
    {
        //Dropdown3のValueが0のとき
        if (dropdown3.value == 0)
        {
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[2].RuleEfect[0] = 0;
        }
        //Dropdown3のValueが1のとき
        else if (dropdown3.value == 1)
        {
            //隠しドロップダウン表示
            //Semimaru();
        }
        //PlayerNumber++;
    }

    public void ChangeSkill1()
    {
        if(Skilldown1.value == 0)
        {
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 0;
        }
        //Skilldown1のValueが1のとき
        else if (Skilldown1.value == 1)
        {
            //山札から2枚引く
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 1;
        }
        //Skilldown1のValueが2のとき
        else if (Skilldown1.value == 2)
        {
            //全員の手札と捨て札を回収
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 2;
        }
        //Skilldown1のValueが3のとき
        else if (Skilldown1.value == 3)
        {
            //全員から5枚もらえる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 3;
        }
        //Skilldown1のValueが4のとき
        else if (Skilldown1.value == 4)
        {
            //全員の手札を回収
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 4;
        }
    }

    public void ChangeSkill2()
    {
        if (Skilldown2.value == 0)
        {
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 0;
        }
        //Skilldown2のValueが1のとき
        else if (Skilldown2.value == 1)
        {
            //全員から4枚もらえる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 1;
        }
        //Skilldown2のValueが2のとき
        else if (Skilldown2.value == 2)
        {
            //山札を引く順番が逆になる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 2;
        }
        //Skilldown2のValueが3のとき
        else if (Skilldown2.value == 3)
        {
            //左隣のプレイヤーから5枚手札に加える
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 3;
        }
    }
    /*
    private void Tennou()
    {
        //TennouDropのValueが0のとき
        if (TennouDrop.value == 0)
        {
            //山札から2枚引く
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 1;
        }
        //TennouDropのValueが1のとき
        else if (TennouDrop.value == 1)
        {
            //全員の手札と捨て札を回収
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 2;
        }
    }

    private void Dantuki()
    {
        //DantukiDropのValueが0のとき
        if (DantukiDrop.value == 0)
        {
            //全員から5枚もらえる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 3;
        }
        //DantukiDropのValueが1のとき
        else if (DantukiDrop.value == 1)
        {
            //全員の手札と捨て札を回収
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 4;
        }
    }

    private void Bukan()
    {
        //BukanDropのValueが0のとき
        if (BukanDrop.value == 0)
        {
            //全員から1枚もらえる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 1;
        }
        //BukanDropのValueが1のとき
        else if (BukanDrop.value == 1)
        {
            //山札を引く順番が逆になる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 2;
        }
    }

    private void Yumimoti()
    {
        //YumimotiDropのValueが0のとき
        if (YumimotiDrop.value == 0)
        {
            //左隣のプレイヤーから5枚手札に加える
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[1].RuleEfect[0] = 3;
        }
    }
    private void Semimaru()
    {
        //SemimaruDropのValueが0のとき
        if (SemimaruDrop.value == 0)
        {
            //1回休み
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[2].RuleEfect[0] = 1;
        }
        //SemimaruDropのValueが1のとき
        else if (SemimaruDrop.value == 1)
        {
            //他のプレイヤーの手札を回収
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[2].RuleEfect[0] = 2;
        }
        //SemimaruDropのValueが2のとき
        else if (SemimaruDrop.value == 2)
        {
            //他のプレイヤーの手札を捨て札に
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[2].RuleEfect[0] = 3;
        }
        //SemimaruDropのValueが3のとき
        else if (SemimaruDrop.value == 3)
        {
            //坊主として扱う
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[2].RuleEfect[0] = 4;
        }
        //SemimaruDropのValueが4のとき
        else if (SemimaruDrop.value == 4)
        {
            //山札の半分を捨てる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[2].RuleEfect[0] = 5;
        }
    }
    */
    public void Semimaru()
    {
        if (SemimaruDrop.value == 0)
        {
            //山札の半分を捨てる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[2].RuleEfect[0] = 0;
        }
    }

    public void Update()
    {
        if (Skilldown1.value == 0 && Skilldown2.value == 0)
        {
            //確認ボタンが押せない
            //s.gameObject.SetActive(false);
            s.interactable = false;
        }
        else
        {
            s.interactable = true;
        }
    }
    public void Down()
    {
        PlayerNumber++;
        if (PlayerNumber > 3)
        {
            PlayerNumber = 0;
        }
    }
}
