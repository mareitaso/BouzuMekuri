using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleEditorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel1, Panel2, Panel3, Panel4;

    void Start()
    {
        SoundManager.instance.BgmApply(Bgm.RuleEditor);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PanelChange1()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
    }

    public void PanelChange2()
    {
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        
    }

    public void PanelChange3()
    {
        Panel3.SetActive(false);
        Panel4.SetActive(true);
    }
}
