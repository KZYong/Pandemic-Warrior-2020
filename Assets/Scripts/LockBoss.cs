using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoss : MonoBehaviour
{
    public GameObject BossLock;
    public GameObject BossHP;
    public GameObject BossHPText;
    public GameObject BossName;

    // Update is called once per frame
    void Start()
    {
    }

    void Update()
    {
        if (Enemy4.BossDead == true)
        {
            BossHP.SetActive(false);
            BossHPText.SetActive(false);
            BossName.SetActive(false);
            Timer.EndTimer = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            BossLock.SetActive(true);
            BossHP.SetActive(true);
            Enemy4.BossBattle = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            BossLock.SetActive(false);
            BossHP.SetActive(false);
            Enemy4.BossBattle = false;
            Enemy4.BossLoop = true;
        }
    }
}
