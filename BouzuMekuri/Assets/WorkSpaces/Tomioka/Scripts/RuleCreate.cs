using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonBuck()
    {
        SceneController.instance.LoadScene(SceneController.SceneName.Rule);
    }
}
