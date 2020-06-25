using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Card", menuName = "CreateCard")]
public class Card : ScriptableObject
{
    public enum FirstJob
    {
        Bouzu,
        Hime,
        Tono,
    }
    public enum SecondJob
    {
        Bukan,
        Tennou,
        Semimaru,
        None
    }
    public enum ThirdJob
    {
        Yumimoti,
        Dantuki,
        None,
    }

    //　アイテムの種類
    public FirstJob firstJob;
    public SecondJob secondJob;
    public ThirdJob thirdJob;

    public FirstJob GetFirstJob()
    {
        return firstJob;
    }

    public SecondJob GetSecondJob()
    {
        return secondJob;
    }

    public ThirdJob GetThirdJob()
    {
        return thirdJob;
    }
}