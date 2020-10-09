using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "CardDataBase", menuName = "CreateCardDataBase")]
public class CardDataBase : ScriptableObject
{
    public List<Card> cardLists = new List<Card>();

    //　アイテムリストを返す
    public List<Card> YamahudaLists()
    {
        return cardLists;
    }
}
