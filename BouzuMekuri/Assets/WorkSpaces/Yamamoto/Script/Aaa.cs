﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aaa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SoundManader.instance.BgmApply(Bgm.BGM0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SoundManader.instance.SeApply(Se.SE0);
        }

    }
}
