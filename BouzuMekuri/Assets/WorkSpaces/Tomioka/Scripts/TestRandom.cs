using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        int i = Random.Range(0, allNum);
        int j = Random.Range(0, allNum - i);
        int k = Random.Range(0, allNum - i - j);

        Num1 = i;
        Num2 = j;
        Num3 = k;
        Num4 = allNum - i - j - k;
    }

    public void DButton()
    {
        int i = allNum / 4;
        int j = allNum / 4;
        int k = allNum / 4;
        int l = allNum - i - j - k;

        int a = Random.Range(i - 5, i);
        int b = Random.Range(i - 5, j);
        int c = Random.Range(i - 5, k);
        int d = Random.Range(i - 5, l);

        Num1 = i - a + b;
        Num2 = j - b + a;
        Num3 = k - c + d;
        Num4 = l - d + c;
    }
}

