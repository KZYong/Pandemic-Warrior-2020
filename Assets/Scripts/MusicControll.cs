using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControll : MonoBehaviour
{
    public AudioClip BGM;
    public AudioClip BGM2;
    public AudioSource audioObject;

    // Update is called once per frame
    void Start()
    {
        audioObject = gameObject.GetComponent<AudioSource>();
    }

     void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "Player")
         {

             audioObject.clip = BGM;
             audioObject.Play();
             Debug.Log("Playing BGM 1");
         }
    }

     void OnTriggerExit2D(Collider2D other)
     {
         if (other.tag == "Player")
         {

             audioObject.Stop();
         }
     }
}
