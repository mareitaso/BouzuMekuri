using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JisakuDropdownManager : SingletonMonoBehaviour<JisakuDropdownManager>
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Panel1;
    [SerializeField]
    private GameObject Panel2;
    [SerializeField]
    private GameObject Panel3;
    [SerializeField]
    private GameObject Panel4;
    [SerializeField]
    private GameObject Panel5;
    [SerializeField]
    private GameObject Panel6;
    [SerializeField]
    private GameObject Panel7;
    [SerializeField]
    private Dropdown dropdown1;

    [SerializeField]
    private GameObject text1;
    [SerializeField]
    private GameObject text2;
    [SerializeField]
    private Text koukaname;

    [SerializeField]
    private Dropdown dropdown2;
    [SerializeField]
    private Dropdown dropdown3;
    [SerializeField]
    private GameObject Panel8;
    [SerializeField]
    private GameObject Panel9;
    [SerializeField]
    private GameObject Panel10;
    [SerializeField]
    private GameObject Panel11;
    [SerializeField]
    private GameObject Panel12;
    [SerializeField]
    private GameObject Panel13;
    [SerializeField]
    private GameObject Panel14;
    [SerializeField]
    private GameObject Panel15;
    [SerializeField]
    private GameObject Panel16;

    // Use this for initialization
    public void Drop1()
    {
        if (dropdown1.value == 1)
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(true);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
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
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(true);
            Panel7.SetActive(false);
            text1.SetActive(true);
            text2.SetActive(true);
            koukaname.text = "引く";
            Debug.Log("引く");
            SetValue(2);
        }
        else if (dropdown1.value == 3)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(true);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(true);
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
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(true);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(true);
            koukaname.text = "1回休み";
            Debug.Log("1回休み");
            SetValue(4);
        }
        else if (dropdown1.value == 5)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
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
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
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
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            koukaname.text = "";
            Debug.Log("未選択");
            SetValue(0);
        }
    }
    
    public void Drop2()
    {
        if (dropdown2.value == 1 && dropdown3.value == 0)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(true);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Panel12.SetActive(false);
            Panel13.SetActive(false);
            Panel14.SetActive(false);
            Panel15.SetActive(false);
            Panel16.SetActive(false);
            Debug.Log("天皇なし");
           
        }
        else if (dropdown2.value == 1 && dropdown3.value == 1)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(true);
            Panel11.SetActive(false);
            Panel12.SetActive(false);
            Panel13.SetActive(false);
            Panel14.SetActive(false);
            Panel15.SetActive(false);
            Panel16.SetActive(false);
            Debug.Log("天皇武官");
            
        }
        else if (dropdown2.value == 1 && dropdown3.value == 2)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(true);
            Panel12.SetActive(false);
            Panel13.SetActive(false);
            Panel14.SetActive(false);
            Panel15.SetActive(false);
            Panel16.SetActive(false);
            Debug.Log("天皇弓持ち");
            
        }
        else if (dropdown2.value == 2 && dropdown3.value == 0)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Panel12.SetActive(true);
            Panel13.SetActive(false);
            Panel14.SetActive(false);
            Panel15.SetActive(false);
            Panel16.SetActive(false);
            Debug.Log("段付きなし");
            
        }
        else if (dropdown2.value == 2 && dropdown3.value == 1)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Panel12.SetActive(false);
            Panel13.SetActive(true);
            Panel14.SetActive(false);
            Panel15.SetActive(false);
            Panel16.SetActive(false);
            Debug.Log("段付き武官");
            
        }
        else if (dropdown2.value == 2 && dropdown3.value == 2)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Panel12.SetActive(false);
            Panel13.SetActive(false);
            Panel14.SetActive(true);
            Panel15.SetActive(false);
            Panel16.SetActive(false);
            Debug.Log("段付き弓持ち");
           
        }
        else if (dropdown2.value == 0 && dropdown3.value == 1)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Panel12.SetActive(false);
            Panel13.SetActive(false);
            Panel14.SetActive(false);
            Panel15.SetActive(true);
            Panel16.SetActive(false);
            Debug.Log("なし武官");
            
        }
        else if (dropdown2.value == 0 && dropdown3.value == 2)
        {
            Panel8.SetActive(false);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Panel12.SetActive(false);
            Panel13.SetActive(false);
            Panel14.SetActive(false);
            Panel15.SetActive(false);
            Panel16.SetActive(true);
            Debug.Log("なし弓持ち");
            
        }
        else
        {
            Panel8.SetActive(true);
            Panel9.SetActive(false);
            Panel10.SetActive(false);
            Panel11.SetActive(false);
            Panel12.SetActive(false);
            Panel13.SetActive(false);
            Panel14.SetActive(false);
            Panel15.SetActive(false);
            Panel16.SetActive(false);
            Debug.Log("なしなし");
            
        }
    }

    public void SetValue(int value)
    {
        dropdown1.value = value;
    }
    public void OnClick()
    {
        dropdown1.value = 0;
        dropdown2.value = 0;
        dropdown3.value = 0;
        koukaname.text = "";
    }
}
