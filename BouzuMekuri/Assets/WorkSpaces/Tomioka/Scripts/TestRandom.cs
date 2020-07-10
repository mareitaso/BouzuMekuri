using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TestRandom : MonoBehaviour
{
    private int allNum;

    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Test test;

    public void DivideButton()
    {
        allNum = hand.handCount[0] + hand.handCount[1] + hand.handCount[2] + hand.handCount[3];

        int i = Random.Range(0, allNum);
        int j = Random.Range(0, allNum - i);
        int k = Random.Range(0, allNum - i - j);

        hand.handCount[0] = i;
        hand.handCount[1] = j;
        hand.handCount[2] = k;
        hand.handCount[3] = allNum - i - j - k;

        test.TextChange();
        test.MockShuffle();
    }
}

