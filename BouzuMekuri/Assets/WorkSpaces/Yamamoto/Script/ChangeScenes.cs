using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< .merge_file_a22372
using UnityEngine.SceneManagement;
=======
>>>>>>> .merge_file_a10700

public class ChangeScenes : MonoBehaviour
{
    // Update is called once per frame
    public void OnClick()
    {
<<<<<<< .merge_file_a22372
        SceneManager.LoadScene("Jisakuru-ru");
=======
        SceneController.instance.LoadScene(SceneController.SceneName.Jisaku);
>>>>>>> .merge_file_a10700
    }
}
