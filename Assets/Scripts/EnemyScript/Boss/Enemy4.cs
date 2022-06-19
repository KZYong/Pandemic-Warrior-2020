using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy4 : MonoBehaviour
{
    public GameObject EnemyT;
    public GameObject[] Player;
    public GameObject Player1;
    public GameObject DMG_Number_Prefab;
    public GameObject DMG_Number_Prefab_Crit;
    public GameObject Crit_Text;
    public GameObject Hit1;
    public GameObject Hit2;

    public GameObject BossHPText;

    public AudioClip HitSound;
    public AudioClip CritSound;
    public AudioClip DeadSound;
    public AudioSource audioObject;

    public float BenemyMaxHealth = 1000000;
    public float BenemycurrentHealth = 1000000;
    public float damagedealt;

    public static bool BossDead = false;

    private PlayerAttack att;
    private Jump2 jump;

    public Animator anim;
    public bool isDead = false;
    public bool EnemyDamaged = false;
    public float Deadtimer;
    public float Damagetimer;

    public float CritDice = 0;
    public bool CritTrue = false;

    public static bool BossBattle = false;
    public static bool BossLoop = false;

    void Start()
    {
        Player1 = GameObject.FindWithTag("Player");
        BenemycurrentHealth = BenemyMaxHealth;
        att = Player1.GetComponent<PlayerAttack>();
        jump = Player1.GetComponent<Jump2>();

        Deadtimer = 0;

        GetComponent<BossShoot>().enabled = false;
    }

    void Update()
    {
        if (BossLoop == true)
        {
            BenemycurrentHealth = BenemyMaxHealth;
            BossLoop = false;
        }

        if (BossBattle == true)
        {
            GetComponent<BossShoot>().enabled = true;
        }
        
        if (BossBattle == false)
        {
            GetComponent<BossShoot>().enabled = false;
        }

        BossHPText.GetComponent<TextMeshProUGUI>().text = BenemycurrentHealth.ToString("f0");


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

            BenemycurrentHealth = 0;

            jump.jumpVelocity = 13;

            Destroy(this.gameObject, 1);
            BossDead = true;
            GetComponent<Enemy_Movement4>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Enemy4>().enabled = false;


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

                BenemycurrentHealth -= damagedealt;
                EnemyDamaged = true;
                Debug.Log("Enemy Damaged!");
                Debug.Log("LOL!");

                //knockback
                Enemy_Movement4.knockbackEnemy = true;

                var enemy = EnemyT.GetComponent<Enemy_Movement4>();
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

                Debug.Log("Hello");

                GameObject DMG_POP = Instantiate(DMG_Number_Prefab_Crit, EnemyT.transform.position, Quaternion.identity) as GameObject;
                DMG_POP.GetComponentInChildren<TextMeshProUGUI>().text = damagedealt.ToString();
                DMG_POP.AddComponent<Destroy_DMG>();
                DMG_POP.transform.SetParent(null);

                GameObject DMG_POP2 = Instantiate(Crit_Text, EnemyT.transform.position, Quaternion.identity) as GameObject;
                DMG_POP2.AddComponent<Destroy_DMG>();
                DMG_POP2.transform.SetParent(null);

                anim.SetTrigger("Hurt");
            }
            else
            {
                audioObject.clip = HitSound;
                audioObject.Play();

                damagedealt = Random.Range(damage, upperdamage);
                BenemycurrentHealth -= damagedealt;
                EnemyDamaged = true;
                Debug.Log("Enemy Damaged!");

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

                anim.SetTrigger("Hurt");
            }


        }

        if (BenemycurrentHealth <= 0)
        {
            EnemyDamaged = true;
            Die();
            PlayerStat.EXPGAIN = true;


        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");


        anim.SetBool("IsDead", true);
        isDead = true;


        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


    }
}
