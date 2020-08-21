using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCommandRule : MonoBehaviour
{
    void Update()
    {
        Debug();
    }

    private void Debug()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SceneController.instance.LoadScene(SceneController.SceneName.Main);
        }
    }
}
