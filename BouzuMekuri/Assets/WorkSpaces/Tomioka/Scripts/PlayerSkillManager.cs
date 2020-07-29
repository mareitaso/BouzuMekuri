using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Test test;
    [SerializeField]
    private touvh touch;
    [SerializeField]
    private CardAnimation cardAnime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            PlayerSkill2();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            PlayerSkill3();
        }
    }

    /// <summary>
    /// 自分の手札を全部捨て場に置き
    /// １位のプレイヤーは手札の半分を捨て場に置く
    /// </summary>
    private void PlayerSkill2()
    {

        int x = 0;//枚数比較用
        int b = 0;//半分捨てる人
        //誰が一番多く持っているか
        for (int i = 0; i < 4; i++)
        {
            if (x < MasterList.Instance.list[i].Count)
            {
                x = MasterList.Instance.list[i].Count;
                b = i;
            }
        }

        cardAnime.skillPlayer = b;

        int a = MasterList.Instance.list[touch.touchPlayer].Count;
        //スキルを使った人の手札を捨て札に加算
        for (int t = 0; t < a; t++)
        {
            int y = MasterList.Instance.list[touch.touchPlayer][0];
            deck.DiscardCount.Add(y);
            MasterList.Instance.list[touch.touchPlayer].RemoveAt(0);
        }
        MasterList.Instance.list[touch.touchPlayer].Clear();//手札を初期化


        int g = MasterList.Instance.list[b].Count;
        //一番っ持っている人の手札を捨て札に加算
        for (int m = 0; m < g / 2; m++)
        {
            int z = MasterList.Instance.list[b][0];
            deck.DiscardCount.Add(z);
            MasterList.Instance.list[b].RemoveAt(0);
        }

        Debug.Log((touch.touchPlayer + 1) + "がスキルを使い全部捨てた");
        Debug.Log("Player" + (cardAnime.skillPlayer + 1) + "がスキル対象で半分捨てた");

        test.TextChange();
        cardAnime.AnimePlayerSkill2();
    }


    /// <summary>
    /// 全てのプレイヤーは最下位と同じ枚数になるように
    /// 捨て場にカードを置く(山札計10枚以上)
    /// </summary>
    private void PlayerSkill3()
    {


        int v = 100;//枚数比較用
        int s = 0;//一番少ない人
        for (int i = 0; i < 4; i++)
        {
            if (v > MasterList.Instance.list[i].Count)
            {
                v = MasterList.Instance.list[i].Count;
                s = i;
            }
        }

        Debug.Log("最小枚数は"+ v);

        for (int i = s + 1; i < s + 4; i++)
        {
            i %= 4;
            Debug.Log(i + "回目");
            int d = MasterList.Instance.list[i].Count;
            //スキルを使った人以外の手札を捨て札に加算
            for (int t = 0; t < d - v; t++)
            {
                int y = MasterList.Instance.list[i][0];
                deck.DiscardCount.Add(y);
                MasterList.Instance.list[i].RemoveAt(0);
            }
            MasterList.Instance.list[i].Clear();//手札を初期化
            Debug.Log("Player" + (i + 1) + "がスキル対象で半分捨てた");

        }

        //Debug.Log("Player" + (s + 1) + "がスキルを使った");

        test.TextChange();
        //cardAnime.AnimePlayerSkill3();
    }
}
