using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public GameObject DMG_Number_Prefab;
    public GameObject EFF;

    private GameObject RANGER;

    public bool Ranged = false;
    public static bool Rangedg = false;

    public Animator anim;
    public ParticleSystem dust;

    public Transform attackPoint;

    public bool left;
    public bool right = true;

    public float attackRange = 0.5f;

    public float AATimer = 0;

    public LayerMask enemyLayers;
    public LayerMask enemyLayers2;
    public LayerMask enemyLayers3;
    public LayerMask enemyLayers4;

    public int attackDamage = 10;
    public int upperDamage = 10;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public static float Real_atkspeed;

    public Text AttackDamageText;
    public Text AttackSpeedText;

    public Movement Move;

    public static bool isAttacking = false;


    void Update()
    {

        if (Ranged == true)
        {
            attackRange = 5.0f;
            Rangedg = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("attackbool", false);
            AATimer = 0;
            isAttacking = false;
        }

        if (isAttacking == true)
        {
            AATimer += Time.deltaTime * 1;
            anim.SetBool("runbool", false);
            anim.SetBool("jumpbool", false);
            anim.SetBool("idlebool", false);
            
            
        }

        if (AATimer >= 0.10)
        {
            isAttacking = false;
            AATimer = 0;
            anim.SetBool("attackbool", false);
            anim.SetBool("idlebool", true);
        }

        Real_atkspeed = attackRate * 100;
        Real_atkspeed = Mathf.Round(Real_atkspeed);

        if (Time.time >= nextAttackTime)
        {
            if(isAttacking == true)
            {
                isAttacking = false;
            }


            if (Input.GetKeyDown(KeyCode.Z))
            {

                {
                    Attack();
                    Debug.Log("I TRIED TO ATTACK");
                    nextAttackTime = Time.time + 1f / attackRate;
                   
                }
            }
        }

        AttackDamageText.text = attackDamage.ToString() + " ~ " + upperDamage.ToString();
        AttackSpeedText.text = Real_atkspeed.ToString() + "%";

    }
        

    void Attack()
    {
        CreateDust();

            anim.SetBool("attackbool", true);

            isAttacking = true;

            anim.SetTrigger("Attack1");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        {
            for (int i = 0; i < hitEnemies.Length; i++ )
            {
                hitEnemies[i].GetComponent<Enemy>().TakeDamage(attackDamage, upperDamage, Player);
            }
        }

        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers2);
        {
            for (int i = 0; i < hitEnemies2.Length; i++)
            {
                hitEnemies2[i].GetComponent<Enemy2>().TakeDamage(attackDamage, upperDamage, Player);
            }
        }

        Collider2D[] hitEnemies3 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers3);
        {
            for (int i = 0; i < hitEnemies3.Length; i++)
            {
                hitEnemies3[i].GetComponent<Enemy3>().TakeDamage(attackDamage, upperDamage, Player);
            }
        }

        Collider2D[] hitEnemies4 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers4);
        {
            for (int i = 0; i < hitEnemies4.Length; i++)
            {
                hitEnemies4[i].GetComponent<Enemy4>().TakeDamage(attackDamage, upperDamage, Player);
            }
        }

        if (Ranged == true)
        {

            GameObject EFF_HIT = Instantiate(EFF, Player.transform.position, Quaternion.identity) as GameObject;
            EFF_HIT.AddComponent<Destroy_DMG3>();
            EFF_HIT.transform.SetParent(null);
            
        }
    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void CreateDust()
    {
        dust.Play();
    }
}