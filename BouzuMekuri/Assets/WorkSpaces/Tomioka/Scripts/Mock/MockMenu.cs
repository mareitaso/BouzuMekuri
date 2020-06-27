using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    private bool menuOnOff = false;

    void Awake()
    {
        menuPanel.SetActive(menuOnOff);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MenuOption();
        }
    }

    private void MenuOption()
    {
        menuOnOff = !menuOnOff;
        menuPanel.SetActive(menuOnOff);
    }

}
