using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestManager : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Start()
    {
        Scene sceneA = SceneManager.GetSceneByName("TitleTestScene");
        Debug.LogFormat("TitleTestScene = {0}", sceneA.IsValid());
        Scene sceneB = SceneManager.GetSceneByName("ResultScene");
        Debug.LogFormat("ResultScene = {0}", sceneB.IsValid());

        yield return null;
    }

}
