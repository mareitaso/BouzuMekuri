using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class test : MonoBehaviour
{
    [SerializeField]
    private RuleData ruleData;

    public void Update()
    {
        Debug.Log(RuleManager.instance.PlayerList[0].RuleList[0].RuleEfect.Count);
    }
    /*
    private void Start()
    {
        var path = "Assets/Resources/Data/RuleData";
        ruleData = AssetDatabase.LoadAssetAtPath<RuleData>(path);

        if(ruleData == null)
        {
            ruleData = ScriptableObject.CreateInstance<RuleData>();
            AssetDatabase.CreateAsset(ruleData, path);
        }
    }

    public void Rule1()
    {
        ruleData.RulesList()[1].GetFirst() == First.None
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ruleData.RulesList()[1].GetFirst() == First.None)
            {
                //変更を検知
                EditorGUI.BeginChangeCheck();

                

                //ruleData.RulesList()[1];
                //EditorUtility.SetDirty(ruleData);
                //AssetDatabase.SaveAssets();
            }
        }
        /*Debug.Log(ruleData.RulesList()[0].GetFirst());
        if(ruleData.RulesList()[1].GetFirst() == First.None)
        {

        }
    }*/
}
