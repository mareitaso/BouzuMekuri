using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField]
    private GameObject RulePanel;
    [SerializeField]
    private GameObject JisakuPanel;
    // Update is called once per frame
    public void OnClick1()//ローカルから自作
    {
        RulePanel.SetActive(false);
        JisakuPanel.SetActive(true);
    }
    public void OnClick2()//自作からローカル
    {
        RulePanel.SetActive(true);
        JisakuPanel.SetActive(false);
    }
}
