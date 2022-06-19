using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay1 : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;
    [SerializeField]
    GameObject TimeStopPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HowToPlay2()
    {
        Page1.SetActive(true);
        TimeStopPanel.SetActive(true);
        Time.timeScale = 0f;
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
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close2()
    {
        Page2.SetActive(false);
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close3()
    {
        Page3.SetActive(false);
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close4()
    {
        Page4.SetActive(false);
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close5()
    {
        Page5.SetActive(false);
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close6()
    {
        Page6.SetActive(false);
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
