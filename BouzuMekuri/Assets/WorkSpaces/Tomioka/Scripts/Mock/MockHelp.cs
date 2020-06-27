using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MockHelp : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExeClose();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    private void ExeClose()
    {
        Application.Quit();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Mock");
    }


}
