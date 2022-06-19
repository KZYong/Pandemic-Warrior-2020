using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillEXPBar : MonoBehaviour
{
    public PlayerStat playerEXP;
    public Image EXPfillImage;
    private Slider EXPslider;

    // Start is called before the first frame update
    void Awake()
    {
        EXPslider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = playerEXP.EXP / playerEXP.MAX_EXP;
        EXPslider.value = fillvalue;
    }
}
