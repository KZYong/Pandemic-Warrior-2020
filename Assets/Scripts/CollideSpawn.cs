using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSpawn : MonoBehaviour
{
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;

    public bool Spawn1 = false;
    public bool Spawn2 = false;
    public bool Spawn3 = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == SpawnPoint1)
        {
            Spawn1 = true;
            Spawn2 = false;
            Spawn3 = false;
        }

        if (other.gameObject == SpawnPoint2)
        {
            Spawn2 = true;
            Spawn1 = false;
            Spawn3 = false;
        }

        if (other.gameObject == SpawnPoint3)
        {
            Spawn3 = true;
            Spawn1 = false;
            Spawn2 = false;
        }
    }
}