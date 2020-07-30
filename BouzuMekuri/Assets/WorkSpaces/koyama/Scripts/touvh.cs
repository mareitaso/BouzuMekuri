﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class touvh : MonoBehaviour
{
    [SerializeField]
    private Test test;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    CardAnimation CardAnime;

    [HideInInspector]
    public int touchPlayer;

    [SerializeField]
    private PlayerSkillManager playerSkill;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Dropdown dropdown;

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
        touchPlayer = 0;
        if (Player1 == false)
        {
            //shuf();
            //Player1 = true;
            panel.SetActive(true);
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
        touchPlayer = 1;
        if (Player2 == false)
        {
            //shuf();
            //Player2 = true;
            panel.SetActive(true);
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
        touchPlayer = 2;
        if (Player3 == false)
        {
            //shuf();
            //Player3 = true;
            panel.SetActive(true);
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
        touchPlayer = 3;
        if (Player4 == false)
        {
            //shuf();
            //Player4 = true;
            panel.SetActive(true);
            Debug.Log("4P押せたよ");
        }
        else
        {
            Debug.Log("4P使い終わったよ");
            return;
        }
    }

    public void drop()
    {
        if (dropdown.value == 0)
        {
            panel.SetActive(false);
            setValue(0);
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("aa");
            shuf();
            Judge();
            setValue(0);
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("aaa");
            playerSkill.PlayerSkill2();
            Judge();
            setValue(0);
        }
        else if(dropdown.value ==3)
        {
            Debug.Log("aaaa");
            playerSkill.PlayerSkill3();
            Judge();
            setValue(0);
        }
        else
        {
            panel.SetActive(false);
            setValue(0);
        }
        panel.SetActive(false);
    }

    private void shuf()
    {
        MasterList.Instance.Shuffle2();
        SoundManager.instance.SeApply(Se.cardShuffle);
        CardAnime.AnimePlayerSkill1();
        int z = deck.Count;
        deck.Count = 0;
        //for (int i = 0; i < 4; i++)
        //{
        //    test.Image();
        //    deck.Count++;
        //}
        test.TextChange();
        deck.Count = z;
    }
    public void setValue(int value)
    {
        dropdown.value = value;
    }

    private void Judge()
    {
        if(touchPlayer == 0)
        {
            Player1 = true;
        }
        if (touchPlayer == 1)
        {
            Player2 = true;
        }
        if (touchPlayer == 2)
        {
            Player3 = true;
        }
        if (touchPlayer == 3)
        {
            Player4 = true;
        }

        /*
        switch (touchPlayer)
        {
            case 1:
                Player1 = true;
                break;
            case 2:
                Player2 = true;
                break;
            case 3:
                Player3 = true;
                break;
            case 4:
                Player4 = true;
                break;
        }*/
    }
}
