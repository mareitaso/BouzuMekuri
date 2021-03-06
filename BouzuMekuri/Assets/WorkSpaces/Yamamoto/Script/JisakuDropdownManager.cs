﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JisakuDropdownManager : SingletonMonoBehaviour<JisakuDropdownManager>
{
    //効果内容関連
    [SerializeField]
    private GameObject Panel1;
    [SerializeField]
    private GameObject Panel2;
    [SerializeField]
    private GameObject Panel4;
    [SerializeField]
    private GameObject Panel5;
    [SerializeField]
    private GameObject Panel6;
    [SerializeField]
    private Dropdown dropdown1;
    [SerializeField]
    private GameObject text1;
    [SerializeField]
    private GameObject text2;
    [SerializeField]
    private Text koukaname;//編集画面で表示するもの

    //編集画面から参照したいもの
    [SerializeField]
    private Dropdown dropdown2;
    [SerializeField]
    private Dropdown dropdown3;

    //対象の表示パターン
    [SerializeField]
    private Dropdown dropdown4;
    [SerializeField]
    private Dropdown dropdown5;
    [SerializeField]
    private Dropdown dropdown6;
    [SerializeField]
    private Dropdown dropdown7;
    [SerializeField]
    private GameObject Panel8;
    [SerializeField]
    private GameObject Panel9;
    [SerializeField]
    private GameObject Panel10;
    [SerializeField]
    private GameObject Panel11;

    [SerializeField]
    private GameObject RulePanel;//ローカルシーン
    [SerializeField]
    private GameObject JisakuPanel;//自作シーン

    [SerializeField]
    private UnityEngine.UI.Button Sakusei;

    // Use this for initialization
    public void Drop1()
    {
        if (dropdown1.value == 1)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel4.SetActive(true);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            text1.SetActive(true);
            text2.SetActive(true);
            koukaname.text = "もらう";
            Debug.Log("もらう");
            SetValue(1);
        }
        else if (dropdown1.value == 2)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(true);
            text1.SetActive(true);
            text2.SetActive(true);
            koukaname.text = "引く";
            Debug.Log("引く");
            SetValue(2);
        }
        else if (dropdown1.value == 3)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel4.SetActive(true);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            text1.SetActive(true);
            text2.SetActive(true);
            koukaname.text = "置く";
            Debug.Log("置く");
            SetValue(3);
        }
        else if (dropdown1.value == 4)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(true);
            Panel6.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(true);
            koukaname.text = "1回休み";
            Debug.Log("1回休み");
            SetValue(4);
        }
        else if (dropdown1.value == 5)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);;
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            koukaname.text = "逆回り";
            Debug.Log("逆回り");
            SetValue(5);
        }
        else if (dropdown1.value == 6)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            koukaname.text = "無効";
            Debug.Log("無効");
            SetValue(6);
        }
        else
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            //Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            //Panel7.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            koukaname.text = "";
            Debug.Log("未選択");
            SetValue(0);
        }
    }
    public void Drop2()
    {
        if (dropdown2.value >= 1 && dropdown3.value == 0 && 
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] > 0)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(true);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Debug.Log("天段・なし");
        }
        else if (dropdown2.value >= 1 && dropdown3.value >= 1 && 
                 RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] > 0 && 
                 RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] > 0) 
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(true);
            Panel11.SetActive(false);
            Debug.Log("天段・武弓");
        }
        else if (dropdown2.value == 0 && dropdown3.value >= 1 && 
                 RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] > 0)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(true);
            Debug.Log("なし・武弓");
        }
        else if (RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] == 0 && 
                 RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] == 0)
        {
            Panel8.SetActive(true);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Debug.Log("なし・なし");
        }
    }
    public void SetValue(int value)
    {
        dropdown1.value = value;
    }
    public void OnClick()//押したらリセット
    {
        dropdown1.value = 0;
        dropdown4.value = 0;
        dropdown5.value = 0;
        dropdown6.value = 0;
        dropdown7.value = 0;
        koukaname.text = "";
        Debug.Log("リセット！");
    }
    public void Update()
    {
        if (dropdown1.value == 0 ) //作成ボタンが
        {
            Sakusei.interactable = false;//押せない
        }
        else
        {
            Sakusei.interactable = true;//押せる
        }
    }
    public void OnClickS2()//自作からローカルへ
    {
        
        RulePanel.SetActive(true);
        JisakuPanel.SetActive(false);
    }
}