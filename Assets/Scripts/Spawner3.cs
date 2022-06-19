using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
    public GameObject mob;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public GameObject[] respawns;
    public GameObject[] gos;

    public static float maxEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemy = 0;
        respawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy2");

        if (gos.Length < 50)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(150f, 260f);
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
