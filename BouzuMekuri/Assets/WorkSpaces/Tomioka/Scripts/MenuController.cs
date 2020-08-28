using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< .merge_file_a04008
using UnityEngine.SceneManagement;
=======
>>>>>>> .merge_file_a16188

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuPanel;


    //メニューをオンにする
    public void MenuOn()
    {
        MenuPanel.SetActive(true);
    }


    //メニューをオフにする
    public void MenuOff()
    {
        MenuPanel.SetActive(false);
    }
    
    public void LoadTitle()
    {
        SoundManager.instance.FadeOutBgm(1f);
<<<<<<< .merge_file_a04008
        MasterList.Instance.Start();
        SceneController.Instance.LoadScene(SceneController.SceneName.Title, true, 2f);
        //SceneManager.LoadScene("Title");
=======
        ReSetCommand.instance.ReSet();
>>>>>>> .merge_file_a16188
    }

}
