using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    
    public BoxCollider2D playerboxcollider;

    [SerializeField]

    public ParticleSystem dust;

    private Rigidbody2D rb;
    private Animator anim;

    public bool isRunning = false;
    public float RunTimer = 0;
    public float IdleTimer = 0;
    public bool IdleStart = false;

    public static bool EFFright = true;

    public float movespd = 2;
    public float jumpforce = 30;
    public float Fallmultiplier = 0.5f;
    
    public int max_multijump = 1;
    public int multijump_done = 0;

    public bool left;
    public bool right = true;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    public Text MoveSpeedText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("idlebool", true);

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("runbool", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("runbool", false);
        }

        move();
        jumpforce = 30;
        sprite_management();
        sprite_direction();

        MoveSpeedText.text = movespd.ToString();

        if (isRunning == true)
        {
            RunTimer += 1 * Time.deltaTime;
        }

        if (IdleStart == true)
        {
            IdleTimer += 1 * Time.deltaTime;
        }


        if (RunTimer >= 0.1f)
        {
            isRunning = false;
            RunTimer = 0;
            IdleStart = true;
        }

        if (IdleTimer >= 0.5f)
        {
            IdleStart = false;
            IdleTimer = 0;
        }
    }


    private bool landed()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(playerboxcollider.bounds.center, Vector2.down, (playerboxcollider.bounds.extents.y   + 0.1f));

        return raycastHit.collider;
    }

    void move()
    {
        if(knockbackCount <= 0)
        {
            
        }
        else
        {
            if (knockFromRight)
            rb.velocity = new Vector2(-knockback, 1f);
            if (!knockFromRight)
            rb.velocity = new Vector2(knockback, 1f);

            knockbackCount -= Time.deltaTime;
        }


        //move
        if (Input.GetKey("left"))
        {
            EFFright = false;
            anim.SetBool("runbool", true);

            if (Jump2.jumping == true)
            {
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespd, rb.velocity.y);
                if (PlayerAttack.isAttacking == false)
                {
                    anim.SetTrigger("Jump");
                    
                }
            }

            if (Jump2.jumping == false)
            {
                if (PlayerAttack.isAttacking == false)
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespd, rb.velocity.y);
                    anim.SetTrigger("PlayerRun");
                    
                }

                if (PlayerAttack.isAttacking == true)
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespd, rb.velocity.y);
                }
            }
            isRunning = true;
            RunTimer = 0;
          
        }

        if (Input.GetKey("right"))
        {
            EFFright = true;
            anim.SetBool("runbool", true);    
            if (Jump2.jumping == true)
            {
                if (PlayerAttack.isAttacking == false)
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespd, rb.velocity.y);
                    anim.SetTrigger("Jump");
                }

                if (PlayerAttack.isAttacking == true)
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespd, rb.velocity.y);
                }
            }

            if (Jump2.jumping == false)
            {
                if (PlayerAttack.isAttacking == false)
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespd, rb.velocity.y);
                    anim.SetTrigger("PlayerRun");
                }

                if (PlayerAttack.isAttacking == true)
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movespd, rb.velocity.y);
                }
                
            }
            isRunning = true;
            RunTimer = 0;
          
        }
    }

    void sprite_direction()
    {
        if (Input.GetAxis("Horizontal") < 0 && !right || Input.GetAxis("Horizontal") > 0 && right)
        {
            if(Jump2.jumping == false)
            CreateDust();

            right = !right;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
            
        }
    }

    void sprite_management()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if (PlayerAttack.isAttacking == false)
            {
                anim.SetTrigger("Jump");
            }
        }

    }


    void CreateDust()
    {
        dust.Play();
    }
}