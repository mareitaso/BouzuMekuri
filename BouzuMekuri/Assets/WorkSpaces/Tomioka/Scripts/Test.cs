using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [HideInInspector]
    public bool drowYama1;

    //富岡編集
    [SerializeField]
    private CardDataBase cardDataBase;
    [SerializeField]
    private Image Yamahuda1, Yamahuda2, Sutehuda, Hikihuda;

    public List<Image> Player;

    [Header("ここにはプレイヤーと捨て札と山札の枚数を入れる")]
    [SerializeField]
    private List<Text> PlayerCards;
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private Rule rule;

    private void Start()
    {
        TextChange();
    }

    public void Drow1()
    {
        if (deck.cards1.Count > 0)//山札1があるとき
        {
            drowYama1 = true;
            deck.drawcard = deck.cards1[AA - 1];//0番目を引いたカードとして登録
            Hikihuda.sprite = Resources.Load<Sprite>("Images/Cards" + deck.drawcard);

            //坊主を引く
            if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bouzu)
            {
                DrowBouzu();
            }
            //姫を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Hime)
            {
                DrowHime();
            }
            //天皇を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tennnou)
            {
                TennouDraw();
                hand.handCount[deck.Count] += 1;//手札に追加
            }
            //殿を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tono)
            {
                DrowTono();
            }
            //武官を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bukan)
            {
                BukanDraw();
                ImageChangeTono();
                hand.handCount[deck.Count] += 1;//手札に追加
            }

            deck.cards1.RemoveAt(0);//0番目を削除
            TextChange();
            ReverseRotation();
        }
        //山札2にカードがある場合
        else if (deck.cards2.Count > 0)
        {
            //まだ片方の山札が残っているからそっちを引こう
        }
        else
        {
            GameEnd();
        }
    }
    public void Drow2()
    {
        if (deck.cards2.Count >= 0)//山札1があるとき
        {
            drowYama1 = false;
            deck.drawcard = deck.cards2[0];//0番目を引いたカードとして登録
            Hikihuda.sprite = Resources.Load<Sprite>("Images/Cards" + deck.drawcard);

            //坊主を引く
            if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bouzu)
            {
                DrowBouzu();
            }
            //姫を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Hime)
            {
                DrowHime();
            }
            //天皇を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tennnou)
            {
                rule.TennouDraw();
                hand.handCount[deck.Count] += 1;//手札に追加
            }
            //殿を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Tono)
            {
                DrowTono();
            }
            //武官を引く
            else if (cardDataBase.YamahudaLists()[deck.drawcard].GetFirstJob() == Card.FirstJob.Bukan)
            {
                rule.BukanDraw();
                ImageChangeTono();
                hand.handCount[deck.Count] += 1;//手札に追加
            }

            deck.cards2.RemoveAt(0);//0番目を削除
            TextChange();
            rule.ReverseRotation();
        }
        //山札2にカードがある場合
        else if (deck.cards1.Count > 0)
        {
            //まだ片方の山札が残っているからそっちを引こう
        }
        else
        {
            GameEnd();
        }
    }

    public void ImageChangeTono()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/Cards" + deck.drawcard);
    }
    public void ImageChangeHime()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/Cards" + deck.drawcard);
        Sutehuda.sprite = null;
    }

    public void ImageChangeBouzu()
    {
        Player[deck.Count].sprite = null;
        Sutehuda.sprite = Resources.Load<Sprite>("Images/Cards" + (deck.drawcard));
    }

    private void TextChange()
    {
        PlayerCards[0].text = hand.handCount[0].ToString();
        PlayerCards[1].text = hand.handCount[1].ToString();
        PlayerCards[2].text = hand.handCount[2].ToString();
        PlayerCards[3].text = hand.handCount[3].ToString();
        PlayerCards[4].text = deck.DiscardCount.ToString();
        PlayerCards[5].text = deck.cards1.Count.ToString();
        PlayerCards[6].text = deck.cards2.Count.ToString();
    }


    //どちらの山札もカードがなくなったときの処理
    private void GameEnd()
    {
        Yamahuda1.sprite = null;
        Yamahuda2.sprite = null;
        Debug.LogError("終わり");
        ImageChangeTono();
        hand.Settlement();
    }
}
