using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2 : MonoBehaviour
{
    [Range(1, 20)]
    public float jumpVelocity;
    public static int maxjump = 0;
    public BoxCollider2D playerboxcollider;
    public Transform Tile1;
    public LayerMask platform;
    public static bool jumping = false;
    public static bool touchenemy = false;
    public Animator anim;

    public AudioClip JumpSound;
    public AudioSource audioObject;

    public ParticleSystem dust;

    void Update()
    {
        if (touchenemy == true)
        {
                maxjump = 1;
                touchenemy = false;
        }


        if (Input.GetButtonDown("Jump"))
        {

            if (maxjump < 2)
            {
                audioObject.clip = JumpSound;
                audioObject.Play();

                anim.SetBool("jumpbool", true);
                maxjump++;
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
                CreateDust();

                jumping = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            CreateDust();

            anim.SetTrigger("PlayerIdle");
            anim.SetBool("jumpbool", false);
            maxjump = 0;

            jumping = false;

        }
    }

     void CreateDust()
    {
        dust.Play();
    }
}
