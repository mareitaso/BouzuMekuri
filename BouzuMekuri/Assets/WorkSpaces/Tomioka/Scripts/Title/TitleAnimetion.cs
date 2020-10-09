using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleAnimetion : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    private GameObject card;

    [SerializeField]
    private GameObject generatePoint, movePoint;

    //カードを生成する時間
    [SerializeField]
    private float generateTime = 10.0f;

    [SerializeField]
    private List<int> cardList;

    [SerializeField]
    private List<GameObject> cardObj;

    private bool anime = true;

    private void Start()
    {
        if (cardList == null)
        {
            cardList = new List<int>();//初期化
        }
        else
        {
            cardList.Clear();//cardsを空にする
        }

        for (int i = 1; i < 100; i++)
        {
            if (i != 10)
            {
                cardList.Add(i);
            }
            else
            {
                cardList.Add(100);
            }
        }

        int n = cardList.Count;//nの初期値はカードの枚数
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);//
            int temp = cardList[k];//k番目のカードをtempに追加
            cardList[k] = cardList[n];
            cardList[n] = temp;
        }
    }

    void Update()
    {
        GenerateCards();
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

    private void AnimetionCard()
    {
        card.transform.DOMove(movePoint.transform.position, 3f).OnComplete(() =>
        {
            Destroy(cardObj[0]);
            cardObj.RemoveAt(0);
        });
    }

    public void SemimaruAnmime()
    {
        Debug.Log("蝉丸の効果");
    }
}
