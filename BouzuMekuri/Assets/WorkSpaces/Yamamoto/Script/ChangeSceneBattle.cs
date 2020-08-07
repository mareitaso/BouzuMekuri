using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneBattle : MonoBehaviour
{
    public void OnClick()
    {
        SceneController.instance.LoadScene(SceneController.SceneName.Main);//←試合画面を入れて
    }
}
