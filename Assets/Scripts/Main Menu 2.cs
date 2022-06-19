using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    [SerializeField]
    GameObject exitPanel;
    [SerializeField]
    GameObject TimeStopPanel;

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitPanel()
    {
        exitPanel.SetActive(true);
        TimeStopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void buyRange()
    {

    }

    public void closeShop()
    {
        exitPanel.SetActive(false);
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
