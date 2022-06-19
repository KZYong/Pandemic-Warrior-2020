using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot1 : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    public float fireRate;
    float nextFire;

    public float Wtimer = 0;
    public bool WarningStart = false;
    public GameObject Warning;

    public float ReloadTimer = 0;

    public bool Rampage = false;
    public float Rrate;
    public float Rtimer = 0;


    void Start()
    {
        Rrate = 0.1f;
        fireRate = 1f;
        nextFire = Time.time;
        WarningStart = true;
    }

    void Update()
    {
        ReloadTimer += 1 * Time.deltaTime;

        if (WarningStart == true)
        {
           Wtimer += 1 * Time.deltaTime;
        }

        if (Wtimer >= 22)
        {
            Warning.SetActive(true);
        }

        if (Wtimer >= 25)
        {
            Warning.SetActive(false);
            Wtimer = 0;
            WarningStart = false;
        }
       
        if (ReloadTimer >= 25)
        {
            Rampage = true;
            ReloadTimer = 0;
        }

        if (Rampage == true)
        {
        Rtimer += 1 * Time.deltaTime;
        WarningStart = true;
        }
        
        if (Rtimer >= 5)
        {
            Rtimer = 0;
            Rampage = false;
        }

        if (Rampage == true)
        {
            fireRate = Rrate;
        }

        if (Rampage == false)
        {
            fireRate = 1f;
        }

        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}