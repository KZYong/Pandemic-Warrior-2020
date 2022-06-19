using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy3 : MonoBehaviour
{
    public GameObject EnemyT;
    public GameObject[] Player;
    public GameObject Player1;
    public GameObject DMG_Number_Prefab;
    public GameObject DMG_Number_Prefab_Crit;
    public GameObject Crit_Text;
    public GameObject Hit1;
    public GameObject Hit2;

    public AudioClip HitSound;
    public AudioClip CritSound;
    public AudioClip DeadSound;
    public AudioSource audioObject;

    public float MoneyAdd;
    public GameObject MoneyPrefab;

    private PlayerAttack att;

    public float enemyMaxHealth = 50000;
    public float enemycurrentHealth = 50000;
    public float damagedealt;

    public Animator anim;
    public bool isDead = false;
    public bool EnemyDamaged = false;
    public float Deadtimer;
    public float Damagetimer;

    public float CritDice = 0;
    public bool CritTrue = false;

    void Start()
    {
        Player1 = GameObject.FindWithTag("Player");
        enemycurrentHealth = enemyMaxHealth;
        att = Player1.GetComponent<PlayerAttack>();

        Deadtimer = 0;
    }

    void Update()
    {

        if (isDead == true)
        {
            Deadtimer += 1 * Time.deltaTime;
        }

        if (EnemyDamaged == true)
        {
            Damagetimer += 1 * Time.deltaTime;
        }


        if (Deadtimer >= 0.01)
        {
            audioObject.clip = DeadSound;
            audioObject.Play();

            enemycurrentHealth = 0;

            GameObject MO_POP = Instantiate(MoneyPrefab, EnemyT.transform.position, Quaternion.identity) as GameObject;
            MO_POP.GetComponentInChildren<TextMeshProUGUI>().text = "+" + MoneyAdd.ToString();
            MO_POP.AddComponent<Destroy_DMG2>();
            MO_POP.transform.SetParent(null);

            Destroy(this.gameObject, 1);
            GetComponent<Enemy_Movement3>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Enemy3>().enabled = false;

        }

        if (Damagetimer >= 0.25)
        {
            EnemyDamaged = false;
            PlayerAttack.isAttacking = false;
        }
    }


    public void TakeDamage(int damage, int upperdamage, GameObject Player)
    {
        if (isDead == false && EnemyDamaged == false)
        {
            CritDice = Random.Range(0f, 1f);

            if (CritDice <= PlayerStat.Crit_Rate)
            {
                audioObject.clip = CritSound;
                audioObject.Play();

                damagedealt = Random.Range(damage, upperdamage);
                damagedealt = damagedealt * PlayerStat.Crit_Dmg;

                damagedealt = Mathf.Round(damagedealt);

                enemycurrentHealth -= damagedealt;
                EnemyDamaged = true;
                Debug.Log("Enemy Damaged!");

                //knockback
                Enemy_Movement3.knockbackEnemy = true;

                var enemy = EnemyT.GetComponent<Enemy_Movement3>();
                enemy.knockbackCountE = enemy.knockbackLengthE;

                if (Player.transform.position.x < transform.position.x)
                    enemy.knockFromRightE = true;
                else
                    enemy.knockFromRightE = false;
                //

                if (PlayerAttack.Rangedg == false)
                {
                    Debug.Log("Not Ranged");
                    GameObject DMG_HIT = Instantiate(Hit1, EnemyT.transform.position, Quaternion.identity) as GameObject;
                    DMG_HIT.AddComponent<Destroy_DMG>();
                    DMG_HIT.transform.SetParent(null);
                }

                if (PlayerAttack.Rangedg == true)
                {
                    Debug.Log("Ranged");
                    GameObject DMG_HIT2 = Instantiate(Hit2, EnemyT.transform.position, Quaternion.identity) as GameObject;
                    DMG_HIT2.AddComponent<Destroy_DMG>();
                    DMG_HIT2.transform.SetParent(null);
                }

                GameObject DMG_POP = Instantiate(DMG_Number_Prefab_Crit, EnemyT.transform.position, Quaternion.identity) as GameObject;
                DMG_POP.GetComponentInChildren<TextMeshProUGUI>().text = damagedealt.ToString();
                DMG_POP.AddComponent<Destroy_DMG>();
                DMG_POP.transform.SetParent(null);

                GameObject DMG_POP2 = Instantiate(Crit_Text, EnemyT.transform.position, Quaternion.identity) as GameObject;
                DMG_POP2.AddComponent<Destroy_DMG>();
                DMG_POP2.transform.SetParent(null);

                anim.SetTrigger("Hurt3");
            }
            else
            {
                audioObject.clip = HitSound;
                audioObject.Play();

                damagedealt = Random.Range(damage, upperdamage);
                enemycurrentHealth -= damagedealt;
                EnemyDamaged = true;
                Debug.Log("Enemy Damaged!");

                //knockback
                Enemy_Movement3.knockbackEnemy = true;

                var enemy = EnemyT.GetComponent<Enemy_Movement3>();
                enemy.knockbackCountE = enemy.knockbackLengthE;

                if (Player.transform.position.x < transform.position.x)
                    enemy.knockFromRightE = true;
                else
                    enemy.knockFromRightE = false;
                //

                if (PlayerAttack.Rangedg == false)
                {
                    Debug.Log("Not Ranged");
                    GameObject DMG_HIT = Instantiate(Hit1, EnemyT.transform.position, Quaternion.identity) as GameObject;
                    DMG_HIT.AddComponent<Destroy_DMG>();
                    DMG_HIT.transform.SetParent(null);
                }

                if (PlayerAttack.Rangedg == true)
                {
                    Debug.Log("Ranged");
                    GameObject DMG_HIT2 = Instantiate(Hit2, EnemyT.transform.position, Quaternion.identity) as GameObject;
                    DMG_HIT2.AddComponent<Destroy_DMG>();
                    DMG_HIT2.transform.SetParent(null);
                }
                GameObject DMG_POP = Instantiate(DMG_Number_Prefab, EnemyT.transform.position, Quaternion.identity) as GameObject;
                DMG_POP.GetComponentInChildren<TextMeshProUGUI>().text = damagedealt.ToString();
                DMG_POP.AddComponent<Destroy_DMG>();
                DMG_POP.transform.SetParent(null);

                anim.SetTrigger("Hurt3");
            }


        }

        if (enemycurrentHealth <= 0)
        {
            EnemyDamaged = true;
            Die();
            PlayerStat.EXPGAIN3 = true;


        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");

        isDead = true;



        MoneyAdd = Random.Range(2000, 4000);
        PlayerStat.Money += MoneyAdd;


        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


    }
}
