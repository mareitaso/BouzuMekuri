﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnOff : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    private Text text;
    private float time;

    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        text.color = ChangeAlpha(text.color);
    }

    //α値を変更
    private Color ChangeAlpha(Color color)
    {
        time += Time.deltaTime * 5f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}