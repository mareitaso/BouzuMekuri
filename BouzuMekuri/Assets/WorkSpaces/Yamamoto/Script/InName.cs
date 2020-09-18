using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InName : MonoBehaviour
{
    public static string str1;
    //public static int str2;
    public InputField inputField;//自作ルールの名前
    public Dropdown dropdown;//効果名

    public void SaveText()
    {
        str1 = inputField.text;
        Debug.Log("入力した");
    }
}
