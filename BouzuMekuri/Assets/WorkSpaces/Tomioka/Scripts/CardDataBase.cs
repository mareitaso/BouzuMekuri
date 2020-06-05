using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CardDataBase", menuName = "CreateCardDataBase")]
public class CardDataBase : ScriptableObject
{
    public List<Card> cardLists = new List<Card>();

    //　アイテムリストを返す
    public List<Card> YamahudaLists()
    {
        return cardLists;
    }

    //private void Awake()
    //{
    //    Debug.Log(cardLists);
    //    for (int i = 0; i < YamahudaLists().Count; i++)
    //    {
    //        cardLists.Add(Resources.Load<>.card);
    //    }
    //}
}
