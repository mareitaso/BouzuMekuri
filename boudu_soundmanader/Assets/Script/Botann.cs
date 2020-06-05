using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botann : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //左クリックを受け付ける
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed primary button.");
    }
}
