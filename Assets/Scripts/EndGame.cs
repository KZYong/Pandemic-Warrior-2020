using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public float TimerEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerEnd += 1 * Time.deltaTime;

        if (TimerEnd >= 60)
        {
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
