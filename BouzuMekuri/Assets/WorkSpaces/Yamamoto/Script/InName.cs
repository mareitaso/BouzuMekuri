using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InName : MonoBehaviour
{
    public InputField inputField;//自作ルールの名前
    [HideInInspector]
    public Text text1;
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        //text1 = text1.GetComponent<Text>();
    }

    public void InputText()
    {
        text1.text = inputField.text;
        Debug.Log("入った");
    }
    public void OnClick()
    {
        inputField.text = "";
        text1.text = "";
    }
}
