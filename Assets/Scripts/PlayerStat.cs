using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    public float HP;
    public float MAX_HP = 10;
    public float MP;
    public float MAX_MP = 50;

    public GameObject LvEffect;
    public Animator effectanim;
    public Animator HPRecoveranim;
    public GameObject LvUpText;
    public GameObject Player;
    public GameObject DeadPanel;
    public GameObject HealNumber;
    public GameObject NeedKeyText;

    public AudioClip LevelUpSound;
    public AudioClip HealSound;
    public AudioSource audioObject;

    public Animator anim;

    public CollideSpawn spawn;
    public ParticleSystem heal;

    public static float Crit_Rate = 0.02f;
    public static float Crit_Dmg = 2f;
    public static float Real_rate;

    public bool Key = false;
    public GameObject Door;
    public GameObject DoorText;

    public static bool EXPGAIN = false;
    public static bool EXPGAIN2 = false;
    public static bool EXPGAIN3 = false;

    public AudioClip PlayerDead;
    public AudioSource audioObject2;

    public bool HealAvailable = true;
    public float HealTimer = 5;
    public float HealAmount;

    public float ReviveTimer = 3;

    public PlayerAttack Stats;
    public Movement Movespeed;

    private bool playDead;

    public float EXP;
    public float MAX_EXP = 2;
    public float ExtraEXP;
    public float PlayerLevelDetect;

    public static float Money = 0;

    public int PlayerLv;
    public bool LevelUp;

    public GameObject LvText;
    public GameObject HPText;
    public GameObject Cooldown;
    public Text CritText;
    public Text CritDmgText;
    public GameObject MoneyText;
    public GameObject ReviveText;
    public GameObject MPText;

    // Start is called before the first frame update
    void Start()
    {
        HPRecoveranim.SetTrigger("HPCooldownDone");
    }

    void Update()
    {
        if (HP > MAX_HP)
        {
            HP = MAX_HP;
        }

        if (MP < MAX_MP)
        {
            MP += 2 * Time.deltaTime;
        }

        if (MP > MAX_MP)
        {
            MP = MAX_MP;
        }

        //Dead
        if (ReviveTimer < 3 && ReviveTimer > 2.95)
        {
            audioObject2.clip = PlayerDead;
            audioObject2.Play();
        }


        if(ReviveTimer <= 0)
        {
            HP = MAX_HP;
            DeadPanel.SetActive(false);
            GetComponent<PlayerAttack>().enabled = true;
            GetComponent<Movement>().enabled = true;
            GetComponent<Jump2>().enabled = true;
            ReviveTimer = 3;

            if (spawn.Spawn1 == true)
            {
                this.transform.position = new Vector3(17, 12, 0);
            }

            if (spawn.Spawn2 == true)
            {
                this.transform.position = new Vector3(114, 12, 0);
            }

            if (spawn.Spawn3 == true)
            {
                this.transform.position = new Vector3(274, 14, 0);
            }
            anim.SetTrigger("PlayerIdle");
            anim.SetBool("deadbool", false);
            anim.SetBool("runbool", false);
            anim.SetBool("jumpbool", false);
            anim.SetBool("attackbool", false);
            HealAvailable = true;
        }

        if(HP <= 0)
        {
          

            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<Movement>().enabled = false;
            GetComponent<Jump2>().enabled = false;
            DeadPanel.SetActive(true);
            ReviveTimer -= 1 * Time.deltaTime;
            anim.SetTrigger("Dead");
            anim.SetBool("deadbool", true);
            HealAvailable = false;
        }

        //

        if (HealAvailable == false)
        {
            Cooldown.SetActive(true);
            HealTimer -= 1 * Time.deltaTime;
            HPRecoveranim.SetTrigger("HPCooldown");
        }

        if (HealAvailable == true)
        {
            Cooldown.SetActive(false);
            HPRecoveranim.SetTrigger("HPCooldownDone");
        }


        if (HealTimer <= 0)
        {
            HealAvailable = true;
            HealTimer = 5;
            HPRecoveranim.SetTrigger("HPCooldownDone");
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            if (HealAvailable == true && MP > 25 && HP < MAX_HP)
            {
                {
                    Heal();
                    MP -= 25;
                }
            }
        }

        

        PlayerLevelDetect = PlayerLv;

        if (EXP >= MAX_EXP)
        {
            ExtraEXP = EXP - MAX_EXP;
        }

        if (LevelUp == true)
        {
            EXP = ExtraEXP;
            LevelUp = false;
        }
        

        

        Real_rate = Crit_Rate * 100;
        Real_rate = Mathf.Round(Real_rate);
        CritText.text = Real_rate.ToString() + "%";
        CritDmgText.text = Crit_Dmg.ToString("f2") + "x";

        HPText.GetComponent<TextMeshProUGUI>().text = HP.ToString("f0");

        LvText.GetComponent<TextMeshProUGUI>().text = PlayerLv.ToString("f0");

        MoneyText.GetComponent<TextMeshProUGUI>().text = Money.ToString("f0");

        Cooldown.GetComponent<TextMeshProUGUI>().text = HealTimer.ToString("f0");

        ReviveText.GetComponent<TextMeshProUGUI>().text = ReviveTimer.ToString("f0");

        MPText.GetComponent<TextMeshProUGUI>().text = MP.ToString("f0");

        if (EXPGAIN == true)
        {
            EXP++;
            EXPGAIN = false;
        }

        if (EXPGAIN2 == true)
        {
            EXP += 5;
            EXPGAIN2 = false;
        }

        if (EXPGAIN3 == true)
        {
            EXP += 25;
            EXPGAIN3 = false;
        }

    //LEVEL_UP
        if (PlayerLv < 50 && EXP >= MAX_EXP)
        {
            ExtraEXP = EXP - MAX_EXP;
            PlayerLv++;
            EXP = 0;
            StatUp();
        }
      //
    }

    void StatUp()
    {
        audioObject.clip = LevelUpSound;
        audioObject.Play();

        LvEffect.SetActive(true);

        effectanim.SetTrigger("LvUp");

        GameObject LV_POP = Instantiate(LvUpText, Player.transform.position, Quaternion.identity) as GameObject;
        LV_POP.AddComponent<Destroy_DMG2>();
        LV_POP.transform.SetParent(null);

        MAX_MP += 2;
        

        if (PlayerLv == 10 | PlayerLv == 20 | PlayerLv == 30 | PlayerLv == 40 | PlayerLv == 50) 
        {
            Movespeed.movespd++;
        }

        if (PlayerLv <= 10)
        {
            MAX_EXP += 1;
            HP = MAX_HP;
            MP = MAX_MP;

            Stats.attackDamage += Random.Range(3, 6);
            Stats.upperDamage += Random.Range(6, 12);
            Stats.attackRate += 0.1f;
            MAX_HP += Random.Range(10, 25);
            Crit_Rate += 0.01f;
            Real_rate = Mathf.Round(Real_rate);
            Crit_Dmg += 0.01f;
            LevelUp = true;
        }

        if (PlayerLv <= 20 && PlayerLv > 10 )
        {
            MAX_EXP += 3;
            HP = MAX_HP;
            MP = MAX_MP;

            Stats.attackDamage += Random.Range(15, 30);
            Stats.upperDamage += Random.Range(30, 50);
            Stats.attackRate += 0.15f;
            MAX_HP += Random.Range(25, 50);
            Crit_Rate += 0.01f;
            Real_rate = Mathf.Round(Real_rate);
            Crit_Dmg += 0.01f;
            LevelUp = true;
        }

        if (PlayerLv <= 30 && PlayerLv > 20)
        {
            MAX_EXP += 6;
            HP = MAX_HP;
            MP = MAX_MP;

            Stats.attackDamage += Random.Range(50, 100);
            Stats.upperDamage += Random.Range(100, 200);
            Stats.attackRate += 0.15f;
            MAX_HP += Random.Range(100, 150);
            Crit_Rate += 0.01f;
            Real_rate = Mathf.Round(Real_rate);
            Crit_Dmg += 0.02f;
            LevelUp = true;
        }

        if (PlayerLv <= 40 && PlayerLv > 30)
        {
            MAX_EXP += 15;
            HP = MAX_HP;
            MP = MAX_MP;

            Stats.attackDamage += Random.Range(250, 450);
            Stats.upperDamage += Random.Range(450, 600);
            Stats.attackRate += 0.2f;
            MAX_HP += Random.Range(150, 200);
            Crit_Rate += 0.01f;
            Real_rate = Mathf.Round(Real_rate);
            Crit_Dmg += 0.02f;
            LevelUp = true;
        }

        if (PlayerLv <= 50 && PlayerLv > 40)
        {
            MAX_EXP += 20;
            HP = MAX_HP;
            MP = MAX_MP;

            Stats.attackDamage += Random.Range(600, 800);
            Stats.upperDamage += Random.Range(800, 1000);
            Stats.attackRate += 0.25f;
            MAX_HP += Random.Range(150, 200);
            Crit_Rate += 0.01f;
            Real_rate = Mathf.Round(Real_rate);
            Crit_Dmg += 0.02f;
            LevelUp = true;
        }
        
    }

    void SpdUp()
    {
        Movespeed.movespd++;
    }

    void Heal()
    {
        if (HP < MAX_HP)
        {
            CreateHeal();
            HealAmount = Random.Range(MAX_HP / 100 * 25, MAX_HP / 100 * 30);
            HealAmount = Mathf.Round(HealAmount);

            GameObject HEAL_POP = Instantiate(HealNumber, Player.transform.position, Quaternion.identity) as GameObject;
            HEAL_POP.AddComponent<Destroy_DMG>();
            HEAL_POP.GetComponentInChildren<TextMeshProUGUI>().text = HealAmount.ToString();
            HEAL_POP.transform.SetParent(null);

            
            HP += HealAmount;
            HealAvailable = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Door)
        {
            if (Key == true)
            {
                Door.SetActive(false);
                DoorText.SetActive(true);
            }
            else
            {
                GameObject KEY_POP = Instantiate(NeedKeyText, Player.transform.position, Quaternion.identity) as GameObject;
                KEY_POP.AddComponent<Destroy_DMG2>();
                KEY_POP.transform.SetParent(null);
            }
        }
    }

    void CreateHeal()
    {
        heal.Play();
        audioObject.clip = HealSound;
        audioObject.Play();
    }
}
