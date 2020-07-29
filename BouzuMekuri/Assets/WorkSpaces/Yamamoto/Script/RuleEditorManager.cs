using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleEditorManager : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.BgmApply(Bgm.RuleEditor);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
