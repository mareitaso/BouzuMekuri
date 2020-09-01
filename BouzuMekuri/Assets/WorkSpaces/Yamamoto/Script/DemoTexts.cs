using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoTexts : MonoBehaviour
{
    public InputField inputField;
    public Dropdown dropdown;
    public Text text1;
    public Text text2;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        dropdown = dropdown.GetComponent<Dropdown>();
        text1 = text1.GetComponent<Text>();
        text2 = text2.GetComponent<Text>();
    }
    public void InputText()
    {
        text1.text = inputField.text;
    }
    public void Drop()
    {
        if (dropdown.value == 0)
        {
            text2.text = "0";
        }
        else if (dropdown.value == 1)
        {
            text2.text = "1";
        }
        else if (dropdown.value == 2)
        {
            text2.text = "2";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
