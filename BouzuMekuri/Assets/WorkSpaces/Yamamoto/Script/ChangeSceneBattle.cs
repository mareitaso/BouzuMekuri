﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneBattle : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Mock");//←試合画面を入れて
    }
}
