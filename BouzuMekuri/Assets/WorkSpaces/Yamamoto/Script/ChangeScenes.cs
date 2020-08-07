using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{
    // Update is called once per frame
    public void OnClick()
    {
        SceneController.instance.LoadScene(SceneController.SceneName.Jisaku);
    }
}
