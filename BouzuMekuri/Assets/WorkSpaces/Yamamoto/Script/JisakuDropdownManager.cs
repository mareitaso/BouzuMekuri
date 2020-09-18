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
    
    public void SetValue(int value)
    {
        dropdown1.value = value;
    }
    public void OnClick()
    {
        dropdown1.value = 0;
        koukaname.text = "";
    }
}
