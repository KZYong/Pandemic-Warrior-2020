using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject Credit;
    public Slider LoadingSlider;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;

    public void LoadLevel()
    {
        
    }

    public void Credits()
    {
       Credit.SetActive(true);
    }

    public void CreditsBack()
    {
        Credit.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("LoadingScreen");
    }

    public void HowToPlay()
    {
        Page1.SetActive(true);
    }

    public void To2()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
    }

    public void To3()
    {
        Page2.SetActive(false);
        Page3.SetActive(true);
    }

    public void To4()
    {
        Page3.SetActive(false);
        Page4.SetActive(true);
    }

    public void To5()
    {
        Page4.SetActive(false);
        Page5.SetActive(true);
    }

    public void To6()
    {
        Page5.SetActive(false);
        Page6.SetActive(true);
    }

    public void Back5()
    {
        Page6.SetActive(false);
        Page5.SetActive(true);
    }

    public void Back4()
    {
        Page5.SetActive(false);
        Page4.SetActive(true);
    }

    public void Back3()
    {
        Page4.SetActive(false);
        Page3.SetActive(true);
    }

    public void Back2()
    {
        Page3.SetActive(false);
        Page2.SetActive(true);
    }

    public void Back1()
    {
        Page2.SetActive(false);
        Page1.SetActive(true);
    }

    public void Close1()
    {
        Page1.SetActive(false);
    }

    public void Close2()
    {
        Page2.SetActive(false);
    }

    public void Close3()
    {
        Page3.SetActive(false);
    }

    public void Close4()
    {
        Page4.SetActive(false);
    }

    public void Close5()
    {
        Page5.SetActive(false);
    }

    public void Close6()
    {
        Page6.SetActive(false);
    }






    public void QuitGame()
    {
        Application.Quit();
    }
}
