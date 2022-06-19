using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public int HP;
    public float Deadtimer;
    public bool Dead;
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
        Dead = false;
        Deadtimer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (HP <= 0)
        {
            Die();
        }

        if (Dead == true)
        {
            Deadtimer += 1 * Time.deltaTime;
        }

        if (Deadtimer >= 2)
        {
            Destroy(this.gameObject);
        }
    }

    void Die()
    {
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Dead = true;
    }
}
