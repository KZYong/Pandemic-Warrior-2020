using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortal : MonoBehaviour
{
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Player)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
