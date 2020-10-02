using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    CardAnimation cardAnime;

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
    private Text skill1, skill2, skill1Text, skill2Text, skill3Text, myRule1, myRule2, myRule3;

    [SerializeField]
    private Text fieldEffectText;

    [SerializeField]
    private Text playerNumber;

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
        if (cardAnime.animeEnd == true)
        {
            MenuPanel.SetActive(true);
        }
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
        playerNumber.text = "プレイヤー1";
        PlayerRuleText();
    }
    public void Player2RuleButton()
    {
        playerRule = 1;
        playerNumber.text = "プレイヤー2";
        PlayerRuleText();
    }
    public void Player3RuleButton()
    {
        playerRule = 2;
        playerNumber.text = "プレイヤー3";
        PlayerRuleText();
    }
    public void Player4RuleButton()
    {
        playerRule = 3;
        playerNumber.text = "プレイヤー4";
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

        if (RuleCreate.instance.myRule[playerRule] == true)
        {
            MyRuleSwitch();
        }
        else
        {
            myRule1.text = "なし";
            myRule2.text = "";
            myRule3.text = "";
        }
    }

    private void MyRuleSwitch()
    {
        //int cardEffect = RuleCreate.instance.cardEffect[playerRule];
        //int playerNum = RuleCreate.instance.playerNum[playerRule];
        //int cardNum = RuleCreate.instance.cardNum[playerRule];
        //int cardType = RuleCreate.instance.cardType[playerRule];

        //効果内容
        switch (RuleCreate.instance.cardEffect[playerRule])
        {
            case 1:
                myRule1.text = "カードをもらう";
                break;

            case 2:
                myRule1.text = "カードを引く";
                break;

            case 3:
                myRule1.text = "カードを場に置く";
                break;

            case 4:
                myRule1.text = "1回休み";
                break;

            case 5:
                myRule1.text = "引く順番が逆周りになる";
                break;

            case 6:
                myRule1.text = "効果無効";
                break;

            default:
                myRule1.text = "？？？";
                break;
        }


        string myRule2Text = "";


        //対象人数と対象枚数
        switch (RuleCreate.instance.cardEffect[playerRule])
        {
            case 1:
            case 3:
            case 4:
                myRule2Text += "対象人数 : " + RuleCreate.instance.playerNum[playerRule] + "人";
                break;

            case 2:
            case 5:
            case 6:
                myRule2Text += "対象人数 : なし";
                break;

            default:
                myRule2Text += "対象人数 : えらいこっちゃ";
                break;
        }

        if (RuleCreate.instance.cardEffect[playerRule] <= 3)
        {
            switch (RuleCreate.instance.cardNum[playerRule])
            {
                case 1:
                    myRule2Text += "　対象枚数 : " + (RuleCreate.instance.cardNum[playerRule] + 1) + "枚";
                    break;

                case 2:
                case 3:
                    myRule2Text += "　対象枚数 : " + RuleCreate.instance.cardNum[playerRule] + "枚";
                    break;

                default:
                    myRule2Text += "　対象枚数 : 謎";
                    break;
            }
        }
        else
        {
            myRule2Text += "　対象枚数 : なし";
        }

        myRule2.text = myRule2Text;

        //カードの種類
        switch (RuleCreate.instance.cardType[playerRule])
        {
            case 1:
                myRule3.text = "対象カード : 天皇";
                break;

            case 2:
                myRule3.text = "対象カード : 段付き";
                break;

            case 3:
                myRule3.text = "対象カード : 武官";
                break;

            case 4:
                myRule3.text = "対象カード : 弓持ち";
                break;

            case 5:
                myRule3.text = "対象カード : 偉い姫";
                break;

            case 6:
                myRule3.text = "対象カード : 坊主";
                break;

            default:
                myRule3.text = "対象カード : XXX";
                break;
        }
    }
}
