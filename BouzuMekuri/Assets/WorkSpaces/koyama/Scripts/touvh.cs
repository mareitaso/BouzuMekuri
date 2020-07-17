using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touvh : MonoBehaviour
{
    [SerializeField]
    private Test test;
    [SerializeField]
    private Deck deck;
    public void draw1()
    {
        test.Draw1();
    }
    public void draw2()
    {
        test.Draw2();
    }
    public void P1()
    {
        MasterList.Instance.Shuffle2();
        int z = deck.Count;
        deck.Count = 0;
        for(int i = 0; i < 4; i++)
        {
            test.Image();
            deck.Count++;
        }
        test.TextChange();
        deck.Count = z;
        Debug.Log("1P押せたよ");
    }
    public void P2()
    {
        Debug.Log("2P押せたよ");
    }
    public void P3()
    {
        Debug.Log("3P押せたよ");
    }
    public void P4()
    {
        Debug.Log("4P押せたよ");
    }
}
