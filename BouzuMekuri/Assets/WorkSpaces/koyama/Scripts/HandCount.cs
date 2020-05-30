using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandCount : MonoBehaviour
{
    [SerializeField]
    public int[] handCount; //4人分の手札
    [SerializeField]
    private Deck deck;
    private int Min = 0;//所持札の最少数
    private int Max = 100;//所持札の最大数
    private int num = 4;//参加最大人数
    public void Settlement()//順位決定
    {
        for(int i =0; i<4; i++)
        {
            Debug.LogFormat("{0}Pは{1}枚です。", i + 1, handCount[i]);
        }
        Debug.Log("捨て札は" + deck.DiscardCount + "枚です");
        /*
        Array.Sort(handCount);
        foreach(int n in handCount)
        {
            Debug.Log(n + "枚\n");
        }*/
        return;
    }
}
