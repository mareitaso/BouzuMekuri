using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DoropdownManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel1;
    [SerializeField]
    private GameObject Panel2;
    [SerializeField]
    private GameObject Panel3;
    [SerializeField]
    private GameObject Panel4;
    [SerializeField]
    private Dropdown dropdown1;//ルール１
    [SerializeField]
    private Dropdown dropdown2;//ルール２
    [SerializeField]
    private Dropdown dropdown3;
    [SerializeField]
    private Dropdown skillT;//天皇
    [SerializeField]
    private Dropdown skillD;//段付き
    [SerializeField]
    private Dropdown skillB;//武官
    [SerializeField]
    private Dropdown skillY;//弓持ち

    [SerializeField]
    private UnityEngine.UI.Dropdown rule1;//ルール１
    [SerializeField]
    private UnityEngine.UI.Dropdown rule2;//ルール２

    [SerializeField]
    private GameObject text1;
    [SerializeField]
    private GameObject text2;

    [SerializeField]
    private Dropdown dropdown4;//自作から参照

    [SerializeField]
    private GameObject RulePanel;//ローカルシーン
    [SerializeField]
    private GameObject JisakuPanel;//自作シーン

    // Use this for initialization
    public void Drop1()
    {
        if (dropdown4.value == 0)//未選択
        {
            rule1.interactable = true;
            rule2.interactable = true;
        }
        else if (dropdown4.value == 1 || dropdown4.value == 2)  //天段なし
        {
            rule1.interactable = false;
            dropdown1.value = 0;
            rule2.interactable = true;
        }
        else if (dropdown4.value == 3 || dropdown4.value == 4) 　//武弓なし
        {
            rule1.interactable = true;
            rule2.interactable = false;
            dropdown2.value = 0;
        }
    }
    public void Drop2()
    {    //選んだものが～
        if (dropdown1.value == 0 && RulePullDown.Pflag == false) 
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            skillD.value = 0;
            skillT.value = 0;
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue1(0);
        }
        else if (dropdown1.value == 1 ) 
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            text1.SetActive(true);
            skillD.value = 0;
            Debug.Log("天皇");
            SetValue1(1);
        }
        else if (dropdown1.value == 2 ) 
        {
            Panel2.SetActive(true);
            Panel1.SetActive(false);
            text1.SetActive(true);
            skillT.value = 0;
            Debug.Log("段付き");
            SetValue1(2);
        }
        else
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            SetValue1(0);
        }
    }
    public void SetValue1(int value1)
    {
        dropdown1.value = value1;
    }
    public void Drop3()
    {
        if (dropdown2.value == 0 && RulePullDown.Pflag == false)
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            skillY.value = 0;
            skillB.value = 0;
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue2(0);
        }
        else if (dropdown2.value == 1 )
        {
            Panel3.SetActive(true);
            Panel4.SetActive(false);
            text2.SetActive(true);
            skillY.value = 0;
            Debug.Log("武官");
            SetValue2(1);
        }
        else if (dropdown2.value == 2 ) 
        {
            Panel4.SetActive(true);
            Panel3.SetActive(false);
            text2.SetActive(true);
            skillB.value = 0;
            Debug.Log("弓持ち");
            SetValue2(2);
        }
        else
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            SetValue2(0);
        }  
    }
    public void SetValue2(int value2)
    {
        dropdown2.value = value2;
    }
    public void OnClick()//押したらリセット
    {
        dropdown1.value = 0;
        dropdown2.value = 0;
        dropdown3.value = 0;
        dropdown4.value = 0;
        SoundManager.instance.SeApply(Se.choice);
        //skillT.value = 0;
        //skillD.value = 0;
        //skillB.value = 0;
        //skillY.value = 0;
    }
    public void OnClickS1()//ローカルから自作へ
    {
        RulePanel.SetActive(false);
        JisakuPanel.SetActive(true);
        SoundManager.instance.SeApply(Se.choice);
    }
}