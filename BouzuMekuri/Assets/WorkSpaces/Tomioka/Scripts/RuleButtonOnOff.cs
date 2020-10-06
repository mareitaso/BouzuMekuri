using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleButtonOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject myRules;


    void Start()
    {
        button.SetActive(true);
        myRules.SetActive(false);
    }

    public void RuleButton()
    {
        if (RuleCreate.instance.myRule[RuleCreate.instance.PlayerNumber] == true)
        {
            button.SetActive(false);
            myRules.SetActive(true);
        }
        else
        {
            button.SetActive(true);
            myRules.SetActive(false);
        }
    }


    void Update()
    {
        if (RuleCreate.instance.myRule[RuleCreate.instance.PlayerNumber] == true)
        {
            button.SetActive(false);
            myRules.SetActive(true);
        }
        else
        {
            button.SetActive(true);
            myRules.SetActive(false);
        }
    }
}
