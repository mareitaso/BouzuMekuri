using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        MasterList.Instance.Start();
        SceneController.Instance.LoadScene(SceneController.SceneName.Title, true, 2f);
        //SceneManager.LoadScene("Title");
    }

}
