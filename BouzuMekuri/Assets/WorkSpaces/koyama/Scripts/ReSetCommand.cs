using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSetCommand : SingletonMonoBehaviour<ReSetCommand>
{ 
    public void ReSet()
    {
        MasterList.instance.Start();
        SceneController.instance.LoadScene(SceneController.SceneName.Title,true,2.0f);
    }
}
