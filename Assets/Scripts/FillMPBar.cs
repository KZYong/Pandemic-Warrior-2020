using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillMPBar : MonoBehaviour
{
    public PlayerStat playerMP;
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = playerMP.MP / playerMP.MAX_MP;
        slider.value = fillvalue;
    }
}
