using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy_Movement4 : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject DMG_Number_Prefab;

    public float MoveSpeed;
    public int _Random;
    public float time;
    public bool Right;
    public bool Flip;
    public int DMG;

    private Rigidbody2D rbE;

    public float knockbackE;
    public float knockbackLengthE;
    public float knockbackCountE;
    public bool knockFromRightE;
    public static bool knockbackEnemy = false;

    void Awake()
    {
        rbE = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");

        DMG = 1;
        MoveSpeed = 5f;

        _Random = Random.Range(0, 1);
        if (_Random == 0)
        {
            Right = false;
        }
        else
        {
            Right = true;
            FlipSprite();
        }
    }

    void Update()
    {

        if (knockbackCountE <= 0)
        {
            knockbackEnemy = false;
        }
        else
        {
            knockbackEnemy = true;

            if (knockFromRightE)
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(knockbackE, 1f);
            if (!knockFromRightE)
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-knockbackE, 1f);

            knockbackCountE -= Time.deltaTime;
        }

        if (knockbackEnemy == false)
        {
            time += Time.deltaTime * 1;

            if (time >= Random.Range(2, 5))
            {
                _Random = Random.Range(-2, 2);
                time = 0;
            }

            if (_Random <= 0)
            {
                // MoveLeft
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, 0);

                if (Right == true)
                {
                    FlipSprite();
                    Right = false;
                }
            }
            else
            {
                // MoveRight
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, 0);

                if (Right == false)
                {
                    FlipSprite();
                    Right = true;
                }
            }
        }


    }

    void FlipSprite()
    {
        this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Player[0])
        {
            DMG = Random.Range(200, 300);

            GameObject DMG_POP = Instantiate(DMG_Number_Prefab, Player[0].transform.position, Quaternion.identity) as GameObject;
            DMG_POP.GetComponentInChildren<TextMeshProUGUI>().text = DMG.ToString();
            DMG_POP.AddComponent<Destroy_DMG>();
            DMG_POP.transform.SetParent(null);
            Player[0].GetComponent<PlayerStat>().HP -= DMG;

            var player = Player[0].GetComponent<Movement>();
            player.knockbackCount = player.knockbackLength;


            if (other.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;

            Jump2.touchenemy = true;

        }

        if (_Random <= 0)
        {
            _Random = 1;
        }
        else
        {
            _Random = -1;
        }


    }

}
