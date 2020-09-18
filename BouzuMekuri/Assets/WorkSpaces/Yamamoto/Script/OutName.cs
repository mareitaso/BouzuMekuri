using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutName : MonoBehaviour
{
    [SerializeField]
    Text text1;
    [SerializeField]
    Text koukaname;

    public GameObject KoukaName = null;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //自作スキル表示
        if (JisakuDropdownManager.str2 == 0)
        {
            koukaname.text = "";//ココを効果内容によって変える
        }
        else if (JisakuDropdownManager.str2 == 1)
        {
            koukaname.text = "もらう";
        }
        else if (JisakuDropdownManager.str2 == 2)
        {
            koukaname.text = "引く";
        }
        else if (JisakuDropdownManager.str2 == 3)
        {
            koukaname.text = "置く";
        }
        else if (JisakuDropdownManager.str2 == 4)
        {
            koukaname.text = "1回休み";
        }
        else if (JisakuDropdownManager.str2 == 5)
        {
            koukaname.text = "逆回り";
        }
        else if (JisakuDropdownManager.str2 == 6)
        {
            koukaname.text = "効果無効";
        }
    }
    public void OnClick()
    {
        text1.text = "";
        //koukaname.text = "";  //リセットできない
    }
}
