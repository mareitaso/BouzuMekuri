using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulePullDown : MonoBehaviour
{
    //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown1;
    [SerializeField] private Dropdown dropdown2;
    [SerializeField] private Dropdown dropdown3;

    [SerializeField] private Dropdown TennouDrop;
    [SerializeField] private Dropdown DantukiDrop;

    [SerializeField] private Dropdown YumimotiDrop;
    [SerializeField] private Dropdown BukanDrop;

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
            Tennou();
        }
        //Dropdown1のValueが2のとき
        else if (dropdown1.value == 2)
        {
            //隠しドロップダウン表示
            Dantuki();
        }
        PlayerNumber++;
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
            Bukan();
        }
        //Dropdown2のValueが2のとき
        else if (dropdown2.value == 2)
        {
            //隠しドロップダウン表示
            Yumimoti();
        }
        PlayerNumber++;
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
            Semimaru();
        }
        PlayerNumber++;
    }

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
        //TennouDropのValueが2のとき
        else if (TennouDrop.value == 2)
        {
            //他のプレイヤーの手札を全てを回収
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 3;
        }
    }

    private void Dantuki()
    {
        //DantukiDropのValueが0のとき
        if (DantukiDrop.value == 0)
        {
            //全員から5枚もらえる
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 4;
        }
        //DantukiDropのValueが1のとき
        else if (DantukiDrop.value == 1)
        {
            //全員の手札と捨て札を回収
            RuleManager.instance.PlayerList[PlayerNumber].RuleList[0].RuleEfect[0] = 5;
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
}
