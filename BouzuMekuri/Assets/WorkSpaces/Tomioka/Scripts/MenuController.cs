using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuPanel;

    [SerializeField]
    private GameObject titlePanel;

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


    /// <summary>
    ///タイトルに戻るを押すと「本当に戻りますか」
    ///と聞くパネルを出す
    /// </summary>
    public void TitleButton()
    {
        titlePanel.SetActive(true);
    }

    public void LoadTitle()
    {
        SoundManager.instance.FadeOutBgm(1f);
        ReSetCommand.instance.ReSet();
    }

    public void MenuBack()
    {
        titlePanel.SetActive(false);
    }
}
