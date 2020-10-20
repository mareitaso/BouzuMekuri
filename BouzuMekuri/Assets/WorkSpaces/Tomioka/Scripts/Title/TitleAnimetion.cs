using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleAnimetion : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private GameObject DownCards;

    private GameObject card;

    private GameObject cards;


    [SerializeField]
    private GameObject UFO;


    [SerializeField]
    private GameObject generatePoint, movePoint;

    //左
    [SerializeField]
    private GameObject GeneP, MovP;
    //中
    [SerializeField]
    private GameObject generaterP, MoverP;

    //カードを生成する時間
    [SerializeField]
    private float generateTime = 10.0f;
    //落下用のカード生成時間
    [SerializeField]
    private float generateTimes = 3.0f;

    [SerializeField]
    private List<int> cardList;

    //落下用のリスト
    [SerializeField]
    private List<int> cardLists;
    [SerializeField]
    private List<int> cardListss;


    [SerializeField]
    private List<GameObject> cardObj;
    //落下用
    [SerializeField]
    private List<GameObject> CardObj;
    [SerializeField]
    private List<GameObject> cardobj;

    [SerializeField]
    private List<GameObject> UFOPlace;

    private bool anime = true;

    //落下用
    private bool animes = false;
    private int s = 0;

    private int n = 0;

    private int animeCardNum;

    //落下用ナンバー
    private int DownCardNum;

    private int downNum;

    private void Start()
    {
        if (s == 0)
        {
            s = 1;
            AniStart();
        }
        /*
        if (cardListss == null)
        {
            cardListss = new List<int>();//初期化
        }
        else
        {
            cardListss.Clear();//cardsを空にする
        }

        for (int r = 1; r < downNum; r++)
        {
            int y = Random.Range(1, 100);

            if (y != 10)
            {
                cardListss.Add(y);
            }
            else
            {
                cardListss.Add(100);
            }
        }
        //sの初期値はカードの枚数
        int m = downNum - 1;
        while (m > 1)
        {
            m--;
            int g = Random.Range(0, m + 1);//
            int temps = cardListss[g];//D番目のカードをtempsに追加
            cardListss[g] = cardLists[m];
            cardListss[m] = temps;
        }
        */
    }

    private void AniStart()
    {
        anime = true;
        animeCardNum = Random.Range(4, 7);

        if (cardList == null)
        {
            cardList = new List<int>();//初期化
        }
        else
        {
            cardList.Clear();//cardsを空にする
        }

        for (int i = 1; i < animeCardNum; i++)
        {
            int j = Random.Range(1, 100);

            if (j != 10)
            {
                cardList.Add(j);
            }
            else
            {
                cardList.Add(100);
            }
        }

        //nの初期値はカードの枚数
        int n = animeCardNum - 1;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);//
            int temp = cardList[k];//k番目のカードをtempに追加
            cardList[k] = cardList[n];
            cardList[n] = temp;
        }
        GenerateDownCards();
    }

    private void DownStart()
    {
        animes = true;
        DownCardNum = Random.Range(4, 7);

        //
        if (cardLists == null)
        {
            cardLists = new List<int>();//初期化
        }
        else
        {
            cardLists.Clear();//cardsを空にする
        }

        for (int u = 1; u < DownCardNum; u++)
        {
            int f = Random.Range(1, 100);

            if (f != 10)
            {
                cardLists.Add(f);
            }
            else
            {
                cardLists.Add(100);
            }
        }
        //sの初期値はカードの枚数
        int s = DownCardNum - 1;
        while (s > 1)
        {
            s--;
            int d = Random.Range(0, s + 1);//
            int temps = cardLists[d];//D番目のカードをtempsに追加
            cardLists[d] = cardLists[s];
            cardLists[s] = temps;
        }
    }
    void Update()
    {
        GenerateCards();
        if(animes == true)
        {
            GenerateDownCards();
        }
    }


    private void GenerateCards()
    {
        if (anime == true)
        {
            generateTime -= 0.1f;
            if (0 > generateTime)
            {
                generateTime = 40.0f;

                card = Instantiate(cardPrefab);
                cardObj.Add(card);

                card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/MainCards/" + cardList[0]);
                cardList.RemoveAt(0);
                if (cardList.Count < 1)
                {
                    anime = false;
                }

                card.transform.position = generatePoint.transform.position;
                AnimetionCard();
            }
        }
    }
    
    private void GenerateDownCards()
    {
        if (animes == true)
        {
            generateTimes -= 0.1f;
            if (0 > generateTimes)
            {
                generateTimes = 15.0f;

                cards = Instantiate(DownCards);
                CardObj.Add(cards);
                cards.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/MainCards/" + cardLists[0]);
                cardLists.RemoveAt(0);
                /*
                cards = Instantiate(DownCards);
                cardobj.Add(cards);
                cards.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/MainCards/" + cardLists[0]);
                cardListss.RemoveAt(0);*/
                if (cardLists.Count < 1)
                {
                    animes = false;
                }
                cards.transform.position = generaterP.transform.position;
                //cards.transform.position = GeneP.transform.position;
                CardAnime();
            }
        }

    }

    private void AnimetionCard()
    {
        card.transform.DOMove(movePoint.transform.position, 3f).OnComplete(() =>
        {
            Destroy(cardObj[0]);
            cardObj.RemoveAt(0);
            if (cardList.Count == 0)
            {
                UFOAnime();
            }
        });
    }

    public void SemimaruAnmime()
    {
        Debug.Log("蝉丸の効果");
        animes = false;
        DownStart();
    }

    private void CardAnime()
    {
        cards.transform.DOMove(MoverP.transform.position, 3f).OnComplete(() =>
        {
            Destroy(CardObj[0]);
            CardObj.RemoveAt(0);
            if(cardLists.Count == 0)
            {
                DownStart();
            }
        });
        /*
        cards.transform.DOMove(MovP.transform.position, 3f).OnComplete(() =>
        {
            Destroy(cardobj[0]);
            cardobj.RemoveAt(0);
            if (cardListss.Count == 0)
            {
                Start();
            }
        });*/
    }

    private void UFOAnime()
    {
        Debug.Log("ここからアニメーション");

        UFO.transform.DOMove(UFOPlace[0].transform.position, 1f).OnComplete(() =>
        {
            UFO.transform.DOMove(UFOPlace[1].transform.position, 1f).OnComplete(() =>
            {
                UFO.transform.DOMove(UFOPlace[2].transform.position, 1f).OnComplete(() =>
                {
                    UFO.transform.DOMove(UFOPlace[3].transform.position, 1f).OnComplete(() =>
                    {
                        UFO.transform.DOMove(UFOPlace[4].transform.position, 1f).OnComplete(() =>
                        {
                            UFO.transform.DOMove(UFOPlace[5].transform.position, 1f).OnComplete(() =>
                            {
                                UFO.transform.DOMove(UFOPlace[6].transform.position, 1f).OnComplete(() =>
                                {
                                    UFO.transform.DOMove(UFOPlace[7].transform.position, 1f).OnComplete(() =>
                                    {
                                        AniStart();
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });
    }
}
