using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCommand : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;

    [SerializeField]
    private Text count;

    void Update()
    {
        count.text = (deck.Count + 1).ToString();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            int x = deck.cards1.Count - 2;
            for (int i = 0; i < x; i++)
            {
                deck.cards1.RemoveAt(0);//0番目を削除
            }
            deck.cards2[0] = 10;
            draw.TextChange();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            deck.cards2[0] = 10;
            draw.TextChange();
        }
    }
}
