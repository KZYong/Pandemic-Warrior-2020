using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject mob;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public GameObject[] respawns;

    public static float maxEnemy = 0;

    public float SpawnTimer = 0;
    public bool EnemyMax = false;
    public bool Spawnable = true;

    // Start is called before the first frame update
    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (maxEnemy == 2)
        {
            EnemyMax = true;
            Spawnable = false;
        }

        if (maxEnemy < 2)
        {
            if (EnemyMax == true)
            {
            SpawnTimer += 1 * Time.deltaTime;
            }

            EnemyMax = false;
        }

        if (SpawnTimer >= 15)
        {
            Spawnable = true;
            SpawnTimer = 0;
        }


        if (maxEnemy < 2 && Spawnable == true)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(35f, 45f);
                whereToSpawn = new Vector2(randX, transform.position.y);

                foreach (GameObject respawn in respawns)
                {
                    Instantiate(mob, whereToSpawn, Quaternion.identity);
                    maxEnemy++;
                }
            }
        }
    }
}
