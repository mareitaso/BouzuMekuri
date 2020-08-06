using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSetCommand : Singleton<ReSetCommand>
{ 
    public void ReSet()
    {
        MasterList.Instance.Start();
        SceneController.Instance.LoadScene(SceneController.SceneName.Title);
    }
}
