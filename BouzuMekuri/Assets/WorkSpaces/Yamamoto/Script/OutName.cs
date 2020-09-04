using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutName : MonoBehaviour
{
    [SerializeField]
    Text text1;

    void Start()
    {
        text1.text = InName.str1;
        Debug.Log("きたよ");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
