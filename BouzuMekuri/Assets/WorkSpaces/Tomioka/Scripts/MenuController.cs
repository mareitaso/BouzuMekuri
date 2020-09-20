using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Draw draw;

    [SerializeField]
    private GameObject MenuPanel;

    [SerializeField]
    private GameObject titlePanel;

    [SerializeField]
    private GameObject ruleCheckPanel;

    [SerializeField]
    private GameObject EachPlayerRulePanel;

    [SerializeField]
    private Text skill1, skill2, skill1Text, skill2Text, skill3Text, myRule;

    [SerializeField]
    private Text fieldEffectText;

    private int playerRule;

    private void Start()
    {
        switch (draw.fieldEffectNum)
        {
            case 1:
                fieldEffectText.text = "引く枚数が+1される";
                break;

            case 2:
                fieldEffectText.text = "20枚引くごとに手札シャッフル";
                break;

            case 3:
                fieldEffectText.text = "プレイヤーが4回ひいたら\n山札から捨て場に３枚置く";
                break;

            default:
                fieldEffectText.text = "ERROR!! ERROR!!";
                break;
        }
    }


    //メニューをオンにする
    public void MenuOn()
    {
        MenuPanel.SetActive(true);
    }


    //メニューをオフにする
    public void MenuOff()
    {
        MenuPanel.SetActive(false);
    }


    /// <summary>
    ///タイトルに戻るを押すと「本当に戻りますか」
    ///と聞くパネルを出す
    /// </summary>
    public void TitleButton()
    {
        titlePanel.SetActive(true);
    }

    //タイトルに戻る
    public void LoadTitle()
    {
        SoundManager.instance.FadeOutBgm(1f);
        ReSetCommand.instance.ReSet();
    }

    //タイトルの戻る？からメニューに戻る
    public void MenuBack()
    {
        titlePanel.SetActive(false);
    }

    //ルール確認のオン
    public void RuleCheckOn()
    {
        ruleCheckPanel.SetActive(true);
    }

    //ルール確認のオフ
    public void RuleCheckOff()
    {
        ruleCheckPanel.SetActive(false);
    }

    //フィールド効果の確認のオン
    public void PlayerRuleOn()
    {
        ruleCheckPanel.SetActive(true);
    }

    //フィールド効果のオフ
    public void PlayerRuleOff()
    {
        ruleCheckPanel.SetActive(false);
    }

    //各々のプレイヤーのルール確認のオン
    public void EachPlayerRulePanelOn()
    {
        EachPlayerRulePanel.SetActive(true);
    }

    //各々のプレイヤーのルール確認のオフ
    public void EachPlayerRulePanelOff()
    {
        EachPlayerRulePanel.SetActive(false);
    }


    public void Player1RuleButton()
    {
        playerRule = 0;
        PlayerRuleText();
    }
    public void Player2RuleButton()
    {
        playerRule = 1;
        PlayerRuleText();
    }
    public void Player3RuleButton()
    {
        playerRule = 2;
        PlayerRuleText();
    }
    public void Player4RuleButton()
    {
        playerRule = 3;
        PlayerRuleText();
    }


    public void PlayerRuleText()
    {

        switch (RuleManager.instance.PlayerList[playerRule].RuleList[0].RuleEfect[0])
        {
            case 0:
                skill1.text = "スキルなし";
                skill1Text.text = "";
                break;

            case 1:
                skill1.text = "天皇スキル";
                skill1Text.text = "山札から2枚引く";
                break;

            case 2:
                skill1.text = "天皇スキル";
                skill1Text.text = "全プレイヤーの手札と捨て札を全てもらう";
                break;

            case 3:
                skill1.text = "段付きスキル";
                skill1Text.text = "全員から5枚もらう";
                break;

            case 4:
                skill1.text = "段付きスキル";
                skill1Text.text = "全プレイヤーの手札をもらう";
                break;

            default:
                skill1.text = "エラー";
                skill1Text.text = "なんで？";
                break;
        }

        switch (RuleManager.instance.PlayerList[playerRule].RuleList[1].RuleEfect[0])
        {
            case 0:
                skill2.text = "スキルなし";
                skill2Text.text = "";
                break;

            case 1:
                skill2.text = "武官スキル";
                skill2Text.text = "全員から4枚もらう";
                break;

            case 2:
                skill2.text = "武官スキル";
                skill2Text.text = "山札を引く順番が逆周りになる";
                break;

            case 3:
                skill2.text = "弓持ちスキル";
                skill2Text.text = "左隣のプレイヤーから5枚もらう";
                break;

            default:
                skill2.text = "エラー";
                skill2Text.text = "なんで？";
                break;
        }

        //蝉丸の効果
        switch (RuleManager.instance.PlayerList[playerRule].RuleList[2].RuleEfect[0])
        {
            case 0:
                skill3Text.text = "坊主として扱う";
                break;

            case 1:
                skill3Text.text = "次のプレイヤーは1回休み";
                break;

            case 2:
                skill3Text.text = "全プレイヤーの手札をもらう";
                break;

            case 3:
                skill3Text.text = "他のプレイヤーは全ての手札を捨て札ヘ";
                break;

            case 4:
                skill3Text.text = "山札の半分を捨て札へ";
                break;

            case 5:
                skill3Text.text = "次に発動するスキルを無効化する";
                break;

            default:
                skill3Text.text = "なんで？";
                break;
        }

        /*
        //天皇ルールも段付きルールもない時
        if (RuleManager.instance.PlayerList[playerRule].RuleList[0].RuleEfect[0] == 0)
        {

        }
        //天皇ルールの時
        else if (RuleManager.instance.PlayerList[playerRule].RuleList[0].RuleEfect[0] == 1 ||
            RuleManager.instance.PlayerList[playerRule].RuleList[0].RuleEfect[0] == 2)
        {

        }
        //段付きルールの時
        else if (RuleManager.instance.PlayerList[playerRule].RuleList[0].RuleEfect[0] == 3 ||
            RuleManager.instance.PlayerList[playerRule].RuleList[0].RuleEfect[0] == 4)
        {

        }


        //武官ルールも弓持ちルールもない時
        if (RuleManager.instance.PlayerList[playerRule].RuleList[1].RuleEfect[0] == 0)
        {

        }
        //武官ルールの時
        else if (RuleManager.instance.PlayerList[playerRule].RuleList[1].RuleEfect[0] == 1 ||
            RuleManager.instance.PlayerList[playerRule].RuleList[1].RuleEfect[0] == 2)
        {

        }
        //弓持ちルールの時
        else if (RuleManager.instance.PlayerList[playerRule].RuleList[1].RuleEfect[0] == 3)
        {

        }
        */

    }

    /*/
    //天皇を引く
                if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou &&
                    (RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 1 ||
                    RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 2))
                {
                    TennouDraw.instance.Tennou_Draw();
                    drawType.text = "天皇";
                }
                //段付きを引く
                else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki &&
                    (RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 3 ||
                    RuleManager.instance.PlayerList[deck.Count].RuleList[0].RuleEfect[0] == 4))
                {
                    DantukiDraw.instance.Dantuki_Draw();
                    drawType.text = "段付き";
                }



                //武官を引くかつ武官スキルあり
                else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan &&
                    (RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 1 ||
                    RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 2))
                {
                    BukanDraw.instance.Bukan_Draw();
                    drawType.text = "武官";
                }

                //弓持ちを引く
                else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti &&
                    RuleManager.instance.PlayerList[deck.Count].RuleList[1].RuleEfect[0] == 3)
                {
                    YumimotiDraw.instance.Yumimoti_Draw();
                    drawType.text = "弓持ち";
                }


                ////偉い姫を引く
                //else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.GreatHime)
                //{
                //    GreatHimeDraw.instance.GreatHime_Draw();
                //}

                //蝉丸を引く
                else if (cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Semimaru &&
                    RuleManager.instance.PlayerList[deck.Count].RuleList[2].RuleEfect[0] >= 1)
                {
                    SemimaruDraw.instance.Semimaru_Draw();
                    drawType.text = "蝉丸";
                }

                //自作ルール(天皇)
                else if (RuleCreate.instance.myRule[deck.Count] == true && RuleCreate.instance.cardType[deck.Count] == 1 &&
                    cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Tennou)
                {
                    MyRule.instance.CardTypeCheck();
                    drawType.text = "自作ルール";
                }

                //自作ルール(段付き)
                else if (RuleCreate.instance.myRule[deck.Count] == true && RuleCreate.instance.cardType[deck.Count] == 2 &&
                    cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Dantuki)
                {
                    MyRule.instance.CardTypeCheck();
                    drawType.text = "自作ルール";
                }

                //自作ルール(武官)
                else if (RuleCreate.instance.myRule[deck.Count] == true && RuleCreate.instance.cardType[deck.Count] == 3 &&
                    cardDataBase.YamahudaLists()[deck.drawcard - 1].GetSecondJob() == Card.SecondJob.Bukan)
                {
                    MyRule.instance.CardTypeCheck();
                    drawType.text = "自作ルール";
                }

                //自作ルール(弓持ち)
                else if (RuleCreate.instance.myRule[deck.Count] == true && RuleCreate.instance.cardType[deck.Count] == 4 &&
                    cardDataBase.YamahudaLists()[deck.drawcard - 1].GetThirdJob() == Card.ThirdJob.Yumimoti)
                {
                    MyRule.instance.CardTypeCheck();
                    drawType.text = "自作ルール";
                }

                //自作ルール(偉い姫)
                else if (RuleCreate.instance.myRule[deck.Count] == true && RuleCreate.instance.cardType[deck.Count] == 5 &&
                    cardDataBase.YamahudaLists()[deck.drawcard - 1].GetOtherJob() == Card.OtherJob.GreatHime)
                {
                    MyRule.instance.CardTypeCheck();
                    drawType.text = "自作ルール";
                }*/
}
