using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    [SerializeField]
    private GameObject creditPanel;

    public void creditOn()
    {
        creditPanel.SetActive(true);
        SoundManager.instance.SeApply(Se.choice);
    }

    public void creditOff()
    {
        creditPanel.SetActive(false);
        SoundManager.instance.SeApply(Se.choice);
    }
}
