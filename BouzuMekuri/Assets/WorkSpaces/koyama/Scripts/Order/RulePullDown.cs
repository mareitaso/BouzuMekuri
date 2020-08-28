using System.Collections;
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

    [SerializeField] private Dropdown Skilldown3;
    [SerializeField] private Dropdown Skilldown4;

    [SerializeField] private UnityEngine.UI.Button s;
    //[SerializeField] private UnityEngine.UI.Button k;

    [SerializeField] private Text text;

    [SerializeField] private Dropdown SemimaruDrop;


    /*
    // 天皇　段付き判定
    public void ChangeRule1()
    {
        //Dropdown1のValueが0のとき
        if (dropdown1.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
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
        //RuleCreate.instance.PlayerNumber++;
    }

    // 武官　弓持ち判定
    public void ChangeRule2()
    {
        //Dropdown2のValueが0のとき
        if (dropdown2.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 0;
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
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = 0;
        }
        //Dropdown3のValueが1のとき
        else if (dropdown3.value == 1)
        {
            //隠しドロップダウン表示
            //Semimaru();
        }
        //RuleCreate.instance.PlayerNumber++;
    }

    public void ChangeSkill1()
    {
        if(Skilldown1.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
        }
        //Skilldown1のValueが1のとき
        else if (Skilldown1.value == 1)
        {
            //山札から2枚引く
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 1;
        }
        //Skilldown1のValueが2のとき
        else if (Skilldown1.value == 2)
        {
            //全員の手札と捨て札を回収
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 2;
        }
        //Skilldown1のValueが3のとき
        else if (Skilldown1.value == 3)
        {
            //全員から5枚もらえる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 3;
        }
        //Skilldown1のValueが4のとき
        else if (Skilldown1.value == 4)
        {
            //全員の手札を回収
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 4;
        }
    }

    public void ChangeSkill2()
    {
        if (Skilldown2.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 0;
        }
        //Skilldown2のValueが1のとき
        else if (Skilldown2.value == 1)
        {
            //全員から4枚もらえる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 1;
        }
        //Skilldown2のValueが2のとき
        else if (Skilldown2.value == 2)
        {
            //山札を引く順番が逆になる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 2;
        }
        //Skilldown2のValueが3のとき
        else if (Skilldown2.value == 3)
        {
            //左隣のプレイヤーから5枚手札に加える
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 3;
        }
    }
    */

    public void Tennou()
    {
        if(Skilldown1.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
        }
        //TennouDropのValueが0のとき
        else if (Skilldown1.value == 1)
        {
            //山札から2枚引く
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 1;
        }
        //TennouDropのValueが1のとき
        else if (Skilldown1.value == 2)
        {
            //全員の手札と捨て札を回収
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 2;
        }
    }

    public void Dantuki()
    {
        if(Skilldown2.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
        }
        //DantukiDropのValueが0のとき
        if (Skilldown2.value == 1)
        {
            //全員から5枚もらえる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 3;
        }
        //DantukiDropのValueが1のとき
        else if (Skilldown2.value == 2)
        {
            //全員の手札と捨て札を回収
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 4;
        }
    }

    public void Bukan()
    {
        if(Skilldown3.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 0;
        }
        //BukanDropのValueが0のとき
        else if (Skilldown3.value == 1)
        {
            //全員から1枚もらえる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 1;
        }
        //BukanDropのValueが1のとき
        else if (Skilldown3.value == 2)
        {
            //山札を引く順番が逆になる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 2;
        }
    }

    public void Yumimoti()
    {
        if(Skilldown4.value == 0)
        {
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 0;
        }
        //YumimotiDropのValueが0のとき
        else if (Skilldown4.value == 1)
        {
            //左隣のプレイヤーから5枚手札に加える
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 3;
        }
    }
    public void Semimaru()
    {
        if(SemimaruDrop.value == 0)
        {
            //坊主として扱う
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = 4;
        }
        //SemimaruDropのValueが0のとき
        else if (SemimaruDrop.value == 1)
        {
            //1回休み
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = 1;
        }
        //SemimaruDropのValueが1のとき
        else if (SemimaruDrop.value == 2)
        {
            //他のプレイヤーの手札を回収
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = 2;
        }
        //SemimaruDropのValueが2のとき
        else if (SemimaruDrop.value == 3)
        {
            //他のプレイヤーの手札を捨て札に
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = 3;
        }
        //SemimaruDropのValueが4のとき
        else if (SemimaruDrop.value == 4)
        {
            //山札の半分を捨てる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = 5;
        }
    }
    /*
    public void Semimaru()
    {
        if (SemimaruDrop.value == 0)
        {
            //山札の半分を捨てる
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[2].RuleEfect[0] = 0;
        }
    }
    */
    public void Update()
    {
        if ((Skilldown1.value == 0&&Skilldown2.value ==0) &&
            (Skilldown3.value == 0&&Skilldown4.value ==0))
        {
            //確認ボタンが押せない
            //s.gameObject.SetActive(false);
            s.interactable = false;
        }
        else
        {
            s.interactable = true;
        }

        if (RuleCreate.instance.PlayerNumber == 0)
        {
            text.text = "P2へ";
        }
        else if (RuleCreate.instance.PlayerNumber == 1)
        {
            text.text = "P3へ";
        }
        else if (RuleCreate.instance.PlayerNumber == 2)
        {
            text.text = "P4へ";
        }
        else if (RuleCreate.instance.PlayerNumber == 3)
        {
            text.text = "試合へ";
        }
    }
    public void Down()
    {
        RuleCreate.instance.PlayerNumber++;
        //if (RuleCreate.instance.PlayerNumber > 3)
        //{
        //    RuleCreate.instance.PlayerNumber = 0;
        //}
        if (RuleCreate.instance.PlayerNumber == 1)
        {
            text.text = "P3へ";
        }
        else if (RuleCreate.instance.PlayerNumber == 2)
        {
            text.text = "P4へ";
        }
        else if (RuleCreate.instance.PlayerNumber == 3)
        {
            text.text = "試合へ";
        }
        else if (RuleCreate.instance.PlayerNumber == 4)
        {
            RuleCreate.instance.PlayerNumber = 0;
            SceneController.instance.LoadScene(SceneController.SceneName.Main);
        }
        s.interactable = false;
        Skilldown1.value = 0;
        Skilldown2.value = 0;
        Skilldown3.value = 0;
        Skilldown4.value = 0;
    }


}
