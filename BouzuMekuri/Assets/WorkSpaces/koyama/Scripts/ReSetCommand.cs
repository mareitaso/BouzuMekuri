using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSetCommand : SingletonMonoBehaviour<ReSetCommand>
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void ReSet()
    {
        MasterList.instance.Start();
        SceneController.instance.LoadScene(SceneController.SceneName.Title);
    }
}
