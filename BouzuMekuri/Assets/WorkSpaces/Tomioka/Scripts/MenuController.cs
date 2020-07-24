using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
