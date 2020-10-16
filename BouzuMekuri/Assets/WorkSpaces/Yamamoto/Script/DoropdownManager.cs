using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Dropdown dropdown4;//ルール１天
    [SerializeField]
    private Dropdown dropdown5;//ルール１段
    [SerializeField]
    private Dropdown dropdown6;//ルール２武
    [SerializeField]
    private Dropdown dropdown7;//ルール２弓

    [SerializeField]
    private GameObject Panel5;//ルール１
    [SerializeField]
    private GameObject Panel6;//ルール１天
    [SerializeField]
    private GameObject Panel7;//ルール１段
    [SerializeField]
    private GameObject Panel8;//ルール２
    [SerializeField]
    private GameObject Panel9;//ルール２武
    [SerializeField]
    private GameObject Panel10;//ルール２弓

    [SerializeField]
    private GameObject text1;
    [SerializeField]
    private GameObject text2;

    [SerializeField]
    private Dropdown dropdown8;//自作から参照

    [SerializeField]
    private GameObject RulePanel;//ローカルシーン
    [SerializeField]
    private GameObject JisakuPanel;//自作シーン
    // Use this for initialization
    public void Drop1()
    {
        if (dropdown8.value == 0)//未選択
        {
            Panel5.SetActive(true);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(true);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            
        }
        else if (dropdown8.value == 1) //天なし
        {
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(true);
            Panel8.SetActive(true);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            
        }
        else if (dropdown8.value == 2) //段なし
        {
            Panel5.SetActive(false);
            Panel6.SetActive(true);
            Panel7.SetActive(false);
            Panel8.SetActive(true);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            
        }
        else if (dropdown8.value == 3)　//武なし
        {
            Panel5.SetActive(true);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(true);
            
        }
        else if (dropdown8.value == 4)　//弓なし
        {
            Panel5.SetActive(true);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
            Panel9.SetActive(true);
            Panel10.SetActive(false);
            
        }
    }
    public void Drop2()
    {
        if (dropdown1.value == 0) 
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue1(0);
        }
        else if (dropdown1.value == 1 ) 
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            text1.SetActive(true);
            Debug.Log("天皇");
            SetValue1(1);
        }
        else if (dropdown1.value == 2 ) 
        {
            Panel2.SetActive(true);
            Panel1.SetActive(false);
            text1.SetActive(true);
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
        if (dropdown2.value == 0 )
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[1].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue2(0);
        }
        else if (dropdown2.value == 1 )
        {
            Panel3.SetActive(true);
            Panel4.SetActive(false);
            text2.SetActive(true);
            Debug.Log("武官");
            SetValue2(1);
        }
        else if (dropdown2.value == 2 ) 
        {
            Panel4.SetActive(true);
            Panel3.SetActive(false);
            text2.SetActive(true);
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
    public void Drop4()
    {
        if (dropdown4.value == 0)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue4(0);
        }
        else if (dropdown4.value == 1)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            text1.SetActive(true);
            Debug.Log("天皇");
            SetValue4(1);
        }
        else
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            SetValue4(0);
        }

    }
    public void SetValue4(int value4)
    {
        dropdown4.value = value4;
    }
    public void Drop5()
    {
        if (dropdown5.value == 0)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue5(0);
        }
        else if (dropdown5.value == 1)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            text1.SetActive(true);
            Debug.Log("段付き");
            SetValue5(1);
        }
        else
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            SetValue5(0);
        }
    }
    public void SetValue5(int value5)
    {
        dropdown5.value = value5;
    }
    public void Drop6()
    {
        if (dropdown6.value == 0)
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue6(0);
        }
        else if (dropdown6.value == 1)
        {
            Panel3.SetActive(true);
            Panel4.SetActive(false);
            text2.SetActive(true);
            Debug.Log("武官");
            SetValue6(1);
        }
        else
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            SetValue6(0);
        }
    }
    public void SetValue6(int value6)
    {
        dropdown6.value = value6;
    }
    public void Drop7()
    {
        if (dropdown7.value == 0)
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            RuleManager.instance.PlayerList[RuleCreate.instance.PlayerNumber].RuleList[0].RuleEfect[0] = 0;
            Debug.Log("なし");
            SetValue7(0);
        }
        else if (dropdown7.value == 1)
        {
            Panel3.SetActive(false);
            Panel4.SetActive(true);
            text2.SetActive(true);
            Debug.Log("弓持ち");
            SetValue7(1);
        }
        else
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            SetValue7(0);
        }
    }
    public void SetValue7(int value7)
    {
        dropdown7.value = value7;
    }
     
    public void OnClick()
    {
        dropdown1.value = 0;
        dropdown2.value = 0;
        dropdown3.value = 0;
        dropdown4.value = 0;
        dropdown5.value = 0;
        dropdown6.value = 0;
        dropdown7.value = 0;
        dropdown8.value = 0;
    }
    public void OnClickS1()//ローカルから自作
    {
        RulePanel.SetActive(false);
        JisakuPanel.SetActive(true);
    }
}