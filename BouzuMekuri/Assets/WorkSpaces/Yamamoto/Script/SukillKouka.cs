using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SukillKouka : MonoBehaviour
{
    public GameObject KoukaName = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text koukaname = KoukaName.GetComponent<Text>();
        koukaname.text = "000000";//ココを効果内容によって変える
    }
}
