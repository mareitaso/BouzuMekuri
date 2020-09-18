using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InName : MonoBehaviour
{
    [SerializeField] InputField inputField;//自作ルールの名前
    [SerializeField] Text text1;
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        text1 = text1.GetComponent<Text>();
    }

    public void InputText()
    {
        text1.text = inputField.text;
    }

}
