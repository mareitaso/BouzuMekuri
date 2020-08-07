using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommand : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Draw draw;

    void Update()
    {
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
