using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP3 : MonoBehaviour
{
    Vector3 localScale;
    public Enemy3 EnemyStat;

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