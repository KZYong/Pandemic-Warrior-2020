using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject timerText;
    private float startTime;
    public static bool EndTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (EndTimer)
            return;

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.GetComponent<TextMeshProUGUI>().text = minutes + ":" + seconds;
    }
}
