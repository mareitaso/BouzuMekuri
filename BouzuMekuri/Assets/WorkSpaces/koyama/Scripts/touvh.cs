using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touvh : MonoBehaviour
{
    [SerializeField]
    private Test test;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    CardAnimation CardAnime;

    public void draw1()
    {
        if (CardAnime.animeEnd == true)
        {
            test.Draw1();
        }
    }
    public void draw2()
    {
        if (CardAnime.animeEnd == true)
        {
            test.Draw2();
        }
    }

    private bool Player1 = false;
    private bool Player2 = false;
    private bool Player3 = false;
    private bool Player4 = false;
    public void P1()
    {
        if(Player1 == false)
        {
            MasterList.Instance.Shuffle2();
            CardAnime.PlayerAllShuffle();
            int z = deck.Count;
            deck.Count = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    test.Image();
            //    deck.Count++;
            //}
            test.TextChange();
            deck.Count = z;
            Player1 = true;
            Debug.Log("1P押せたよ");
        }
        else
        {
            Debug.Log("1P使い終わったよ");
            return;
        }
        
    }
    public void P2()
    {
        if (Player2 == false)
        {
            MasterList.Instance.Shuffle2();
            CardAnime.PlayerAllShuffle();
            int z = deck.Count;
            deck.Count = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    test.Image();
            //    deck.Count++;
            //}
            test.TextChange();
            deck.Count = z;
            Player2 = true;
            Debug.Log("2P押せたよ");
        }
        else
        {
            Debug.Log("2P使い終わったよ");
            return;
        }
    }
    public void P3()
    {
        if (Player3 == false)
        {
            MasterList.Instance.Shuffle2();
            CardAnime.PlayerAllShuffle();
            int z = deck.Count;
            deck.Count = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    test.Image();
            //    deck.Count++;
            //}
            test.TextChange();
            deck.Count = z;
            Player3 = true;
            Debug.Log("3押せたよ");
        }
        else
        {
            Debug.Log("3P使い終わったよ");
            return;
        }
    }
    public void P4()
    {
        if (Player4 == false)
        {
            MasterList.Instance.Shuffle2();
            CardAnime.PlayerAllShuffle();
            int z = deck.Count;
            deck.Count = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    test.Image();
            //    deck.Count++;
            //}
            test.TextChange();
            deck.Count = z;
            Player4 = true;
            Debug.Log("4P押せたよ");
        }
        else
        {
            Debug.Log("4P使い終わったよ");
            return;
        }
    }
}
