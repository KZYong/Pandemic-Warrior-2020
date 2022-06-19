using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject VictoryPortal;
    public GameObject VictoryText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy4.BossDead == true)
        {
            VictoryPortal.SetActive(true);
            VictoryText.SetActive(true);
        }
    }
}
