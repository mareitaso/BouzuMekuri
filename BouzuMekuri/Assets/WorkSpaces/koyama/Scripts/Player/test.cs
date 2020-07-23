using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private RuleData ruleData;

    private void Update()
    {
        //Debug.Log(ruleData.RulesList()[0].GetFirst());
        if(ruleData.RulesList()[1].GetFirst() == First.None)
        {

        }
    }
}
