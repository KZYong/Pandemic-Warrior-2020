using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enemy4.BossDead = false;
        Enemy4.BossBattle = false;
        Enemy4.BossLoop = false;

        Timer.EndTimer = false;

        PlayerStat.Crit_Rate = 0.02f;
        PlayerStat.Crit_Dmg = 2f;

        PlayerStat.Money = 0;

        Enemy_Movement.knockbackEnemy = false;
        Enemy_Movement2.knockbackEnemy = false;
        Enemy_Movement3.knockbackEnemy = false;
        Enemy_Movement4.knockbackEnemy = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
