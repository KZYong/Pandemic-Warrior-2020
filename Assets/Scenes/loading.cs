using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public float TimerEnd;
    public GameObject Need;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerEnd += 1 * Time.deltaTime;

        if (TimerEnd >= 3)
        {
            Need.SetActive(true);
        }

        if (TimerEnd >= 6)
        {
            {
                SceneManager.LoadScene("Game1");
            }
        }
    }
}