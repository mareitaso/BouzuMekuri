using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    /*富岡編集
    [SerializeField]
    private Image Yamahuda;
    [SerializeField]
    private Image Sutehuda;
    [SerializeField]
    private List<Image> Player;
    */
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private HandCount hand;
    [SerializeField]
    private MasterList ml;

    [SerializeField]
    private int Count;
    
    public void draw()
    {
        //ml.Shuffle1();
        //Count = 0;//hand.handCount.Length;
        //Debug.Log(Count+"だよ");
        if (deck.Count <= 3)//4人(仮)
        {
            if (deck.cards.Count > 0)//山札があるとき
            {
                deck.drawcard = deck.cards[0];//0番目を引いたカードとして登録
                Debug.Log(deck.drawcard);
                //Yamahuda.sprite = Resources.Load<Sprite>("Images/" + deck.drawcard);
                if (deck.drawcard < 12)
                {
                    Debug.Log("坊主" + deck.Count + "のばん");
                    
                    ml.list[deck.Count].Add(deck.drawcard); 
                    //hand.handCount[deck.Count] += 1;
                    //deck.DiscardCount += hand.handCount[deck.Count];//手札を捨て札に加算
                    //hand.handCount[deck.Count] = 0;//手札を初期化

                    //ml.list.Add[Count][deck.drawcard];
                    //ImageChangeBouzu();
                }
                else if (deck.drawcard < 33)
                {
                    Debug.Log("姫" + deck.Count + "のばん");
                    if (deck.DiscardCount > 0)
                    {
                        hand.handCount[deck.Count] += deck.DiscardCount;//捨て札を回収
                        deck.DiscardCount = 0;//捨て札を初期化
                        ml.list[deck.Count].Add(deck.drawcard);
                        //hand.handCount[deck.Count] += 1;
                        //ImageChangeHime();
                    }
                    else
                    {
                        ml.list[deck.Count].Add(deck.drawcard);
                        //hand.handCount[deck.Count] += 1;
                        //ImageChangeHime();
                    }
                }
                else
                {
                    Debug.Log("殿" + deck.Count + "のばん");
                    ml.list[deck.Count].Add(deck.drawcard);
                    //hand.handCount[deck.Count] += 1;//手札に追加
                    //ImageChangeTono();
                }
                Count++;
                if(Count == 2)
                {
                    ml.Shuffle1();
                    Debug.Log(ml.list);
                }
                deck.Count++;
                deck.cards.RemoveAt(0);//0番目を削除
                if (deck.Count == 4)
                {
                    deck.Count = 0;
                }
                //手札シャッフル
                if(Count==20||Count==40||Count==60||Count==80)
                {
                    FieldFlag.instance.Distribution();
                }
            }
            else
            {
                //Yamahuda.sprite = null;
                Debug.LogError("終わり");
                //ImageChangeTono();
                hand.Settlement();
                
            }
        }
    }
    /*
    private void ImageChangeTono()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/" + deck.drawcard);
    }
    private void ImageChangeHime()
    {
        Player[deck.Count].sprite = Resources.Load<Sprite>("Images/" + deck.drawcard);
        Sutehuda.sprite = null;
    }

    private void ImageChangeBouzu()
    {
        Player[deck.Count].sprite = null;
        Sutehuda.sprite = Resources.Load<Sprite>("Images/" + deck.drawcard);
    }*/
}