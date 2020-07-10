using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MockHelp : MonoBehaviour
{
    [SerializeField]
    private Deck deck;
    [SerializeField]
    private GameObject arrowImage;

    [SerializeField]
    private GameObject arrowPostion1, arrowPostion2, arrowPostion3, arrowPostion4;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExeClose();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            deck.cards1[0] = 9;
        }

        ArrowPosition();
    }

    private void ExeClose()
    {
        Application.Quit();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Mock");
    }

    private void ArrowPosition()
    {
        switch (deck.Count)
        {
            case 0:
                arrowImage.transform.position = arrowPostion1.transform.position;
                break;

            case 1:
                arrowImage.transform.position = arrowPostion2.transform.position;
                break;

            case 2:
                arrowImage.transform.position = arrowPostion3.transform.position;
                break;

            case 3:
                arrowImage.transform.position = arrowPostion4.transform.position;
                break;
        }
    }
}
