using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHP4 : MonoBehaviour
{
    Vector3 localScale;
    public Enemy4 EnemyStat;


    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {   
        localScale.x = EnemyStat.BenemycurrentHealth / EnemyStat.BenemyMaxHealth;
        transform.localScale = localScale;
    }
}