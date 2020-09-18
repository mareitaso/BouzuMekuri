using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] GameObject RulePanel;
    [SerializeField] GameObject JisakuPanel;
    
    public void OnClick1()//ローカルから自作へ
    {
        RulePanel.SetActive(false);
        JisakuPanel.SetActive(true);
    }
    public void OnClick2()//自作からローカルへ
    {
        RulePanel.SetActive(true);
        JisakuPanel.SetActive(false);
    }
}
