using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCount : MonoBehaviour
{
    public static HandCount Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int handCount;//手札の枚数
    public int DiscardCount;//捨て札の枚数
}
