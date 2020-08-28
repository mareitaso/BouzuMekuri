using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< .merge_file_a12108
using UnityEngine.SceneManagement;
=======
>>>>>>> .merge_file_a15928

public class ChangeSceneBattle : MonoBehaviour
{
    public void OnClick()
    {
<<<<<<< .merge_file_a12108
        SceneManager.LoadScene("Mock");//←試合画面を入れて
=======
        SceneController.instance.LoadScene(SceneController.SceneName.Main);//←試合画面を入れて
>>>>>>> .merge_file_a15928
    }
}
