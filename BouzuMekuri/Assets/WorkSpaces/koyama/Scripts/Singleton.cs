﻿using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                Type t = typeof(T);

                instance = (T)FindObjectOfType(t);
                if(instance == null)
                {
                    Debug.LogError(t + "をアタッチしてるGameObjectはないよ");
                }
            }
            return instance;
        }
    }

    virtual protected void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if(instance = null)
        {
            instance = this as T;
            return true;
        }
        else if(instance == this)
        {
            return true;
        }
        Destroy(this);
        return true;
    }
}
