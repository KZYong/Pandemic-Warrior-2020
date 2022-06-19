using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEffect : MonoBehaviour
{
    public static bool eleft;
    public static bool eright = true;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        if (Movement.EFFright == false)
        {
            mySpriteRenderer.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.EFFright == false)
        {
            mySpriteRenderer.flipX = true;
        }
    }
}
