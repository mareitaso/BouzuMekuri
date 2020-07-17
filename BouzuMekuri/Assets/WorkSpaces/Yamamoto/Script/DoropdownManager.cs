using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoropdownManager : MonoBehaviour
{
    [SerializeField]
    private Dropdown dropdown;

    [SerializeField]
    private GameObject image;//imageに格納する変数

    // Update is called once per frame
    void Update()
    {
        if (dropdown.value == 1)
        {
            image.GetComponent<Renderer>().material.color = Color.red;
        }
        if (dropdown.value == 2)
        {
            image.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (dropdown.value == 3)
        {
            image.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
