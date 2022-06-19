using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_DMG : MonoBehaviour
{
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += 1 * Time.deltaTime;

        if (Timer > 0.3f)
        {
            Destroy(this.gameObject);
        }
    }
}
