using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    [SerializeField]
    private Draw draw;
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
    private GameObject panels;
    [SerializeField]
    private Text text;

    [SerializeField]
    private Dropdown dropdown;

    public void draw1()
    {
        if (CardAnime.animeEnd == true)
        {
            draw.Draw1();
        }
    }
    public void draw2()
    {
        if (CardAnime.animeEnd == true)
        {
            draw.Draw2();
        }
    }

    public bool Player1 = false;
    public bool Player2 = false;
    public bool Player3 = false;
    public bool Player4 = false;
    public void P1()
    {
        touchPlayer = 0;
        if (Player1 == false && deck.Count == 0)
        {
            panel.SetActive(true);
            Debug.Log("1P押せたよ");
        }
        else if(Player1 == true && deck.Count == 0)
        {
            panels.SetActive(true);
            text.text = "既にスキルを使っています";
            Debug.Log("1P使い終わったよ");
        }
        else
        {
            panels.SetActive(true);
            text.text = "あなたの番じゃないよ";
            Debug.Log("1Pの番じゃないよ");
        }
    }
    public void P2()
    {
        touchPlayer = 1;
        if (Player2 == false && deck.Count == 1)
        {
            panel.SetActive(true);
            Debug.Log("2P押せたよ");
        }
        else if (Player2 == true && deck.Count == 1)
        {
            panels.SetActive(true);
            text.text = "既にスキルを使っています";
            Debug.Log("2P使い終わったよ");
        }
        else
        {
            panels.SetActive(true);
            text.text = "あなたの番じゃないよ";
            Debug.Log("2Pの番じゃないよ");
        }
    }
    public void P3()
    {
        touchPlayer = 2;
        if (Player3 == false && deck.Count == 2)
        {
            panel.SetActive(true);
            Debug.Log("3押せたよ");
        }
        else if (Player3 == true && deck.Count == 2)
        {
            panels.SetActive(true);
            text.text = "既にスキルを使っています";
            Debug.Log("3P使い終わったよ");
        }
        else
        {
            panels.SetActive(true);
            text.text = "あなたの番じゃないよ";
            Debug.Log("3Pの番じゃないよ");
        }
    }
    public void P4()
    {
        touchPlayer = 3;
        if (Player4 == false && deck.Count == 3)
        {
            panel.SetActive(true);
            Debug.Log("4P押せたよ");
        }
        else if (Player4 == true && deck.Count == 3)
        {
            panels.SetActive(true);
            text.text = "既にスキルを使っています";
            Debug.Log("4P使い終わったよ");
        }
        else
        {
            panels.SetActive(true);
            text.text = "あなたの番じゃないよ";
            Debug.Log("4Pの番じゃないよ");
        }
    }


    public void Skill1()
    {
        Judge();
        shuf();
        panel.SetActive(false);
    }

    public void Skill2()
    {
        Judge();
        playerSkill.PlayerSkill2();
        panel.SetActive(false);
    }

    public void Skill3()
    {
        if (deck.cards1.Count + deck.cards2.Count > 10)
        {
            Judge();
            playerSkill.PlayerSkill3();
            panel.SetActive(false);
        }
    }

    public void Move()
    {
        panel.SetActive(false);
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
        else if (dropdown.value == 3)
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
        if(MasterList.instance.list[0].Count==0&&
            MasterList.instance.list[1].Count == 0 &&
            MasterList.instance.list[2].Count == 0 &&
            MasterList.instance.list[3].Count == 0)
        {
            playerSkill.EPanel();
        }
        else
        {
            MasterList.instance.Shuffle2();
            SoundManager.instance.SeApply(Se.cardShuffle);
            CardAnime.AnimePlayerSkill1();
            draw.TextChange();
        }
    }
    public void setValue(int value)
    {
        dropdown.value = value;
    }

    private void Judge()
    {
        if (touchPlayer == 0)
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
    }
}
