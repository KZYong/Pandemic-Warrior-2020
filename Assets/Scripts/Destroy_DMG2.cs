using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_DMG2 : MonoBehaviour
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

        if (Timer > 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
