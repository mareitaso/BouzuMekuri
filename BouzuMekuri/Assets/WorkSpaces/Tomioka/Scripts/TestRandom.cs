using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRandom : MonoBehaviour
{
    [SerializeField]
    private Text text1, text2, text3, text4, ALLtext;

    private int Num1, Num2, Num3, Num4;

    private int allNum;

    // Start is called before the first frame update
    void Start()
    {
        Num1 = Random.Range(0, 25);
        Num2 = Random.Range(0, 25);
        Num3 = Random.Range(0, 25);
        Num4 = Random.Range(0, 25);

        allNum = Num1 + Num2 + Num3 + Num4;
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = Num1.ToString();
        text2.text = Num2.ToString();
        text3.text = Num3.ToString();
        text4.text = Num4.ToString();
        ALLtext.text = allNum.ToString();
    }

    public void DivideButton()
    {
        int a = Random.Range(0, Num1);
        int b = Random.Range(0, Num2);
        int c = Random.Range(0, Num3);
        int d = Random.Range(0, Num4);
    }
}
