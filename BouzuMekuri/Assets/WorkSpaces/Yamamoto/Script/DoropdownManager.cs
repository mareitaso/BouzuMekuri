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
    private Dropdown dropdown1;
    [SerializeField]
    private Dropdown dropdown2;
    [SerializeField]
    private Dropdown dropdown3;
    [SerializeField]
    private GameObject text1;
    [SerializeField]
    private GameObject text2;

    // Use this for initialization
    public void Drop1()
    {
        if (dropdown1.value == 0)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            Debug.Log("なし");
            SetValue(0);
        }
        else if (dropdown1.value == 1)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            text1.SetActive(true);
            Debug.Log("天皇");
            SetValue(1);
        }
        else if (dropdown1.value == 2)
        {
            Panel2.SetActive(true);
            Panel1.SetActive(false);
            text1.SetActive(true);
            Debug.Log("段付き");
            SetValue(2);
        }
        else
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            text1.SetActive(false);
            SetValue(0);
        }
        
    }
    public void SetValue(int value)
    {
        dropdown1.value = value;
    }
    public void Drop2()
    { 
        if (dropdown2.value == 0)
        {
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            text2.SetActive(false);
            Debug.Log("なし");
            SetValue2(0);
        }
        else if (dropdown2.value == 1)
        {
            Panel3.SetActive(true);
            Panel4.SetActive(false);
            text2.SetActive(true);
            Debug.Log("武官");
            SetValue2(1);
        }
        else if (dropdown2.value == 2)
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
    public void OnClick()
    {
        dropdown1.value = 0;
        dropdown2.value = 0;
        dropdown3.value = 0;
    }
}
//ボタンを押したら～に変える