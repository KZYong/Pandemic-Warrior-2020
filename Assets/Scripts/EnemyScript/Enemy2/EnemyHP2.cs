using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP2 : MonoBehaviour
{
    Vector3 localScale;
    public Enemy2 EnemyStat;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {   
        localScale.x = EnemyStat.enemycurrentHealth / EnemyStat.enemyMaxHealth;
        transform.localScale = localScale;
    }
}