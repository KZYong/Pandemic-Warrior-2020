using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletFollow : MonoBehaviour
{
    float moveSpeed = 6f;
    private float DMG = 0;
    private GameObject Player;
    public GameObject DMG_Number_Prefab;

    Rigidbody2D rb;

    Movement target;
    Vector2 moveDirection;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Movement>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            DMG = Random.Range(100, 250);
            Player.GetComponent<PlayerStat>().HP -= DMG;

            GameObject DMG_POP = Instantiate(DMG_Number_Prefab, Player.transform.position, Quaternion.identity) as GameObject;
            DMG_POP.GetComponentInChildren<TextMeshProUGUI>().text = DMG.ToString();
            DMG_POP.AddComponent<Destroy_DMG>();
            DMG_POP.transform.SetParent(null);

            Debug.Log("HIT PLAYER!");
            Destroy(gameObject);
        }
    }
}