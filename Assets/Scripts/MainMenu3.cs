using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu3 : MonoBehaviour
{
    [SerializeField]
    GameObject exitPanel;
    [SerializeField]
    GameObject TimeStopPanel;
    [SerializeField]
    GameObject Sold1;
    [SerializeField]
    GameObject Sold2;
    public GameObject Player1;

    private PlayerAttack att;
    private PlayerStat stat;

    public GameObject MoneyShopText;

    // Update is called once per frame
    void Start()
    {
        Player1 = GameObject.FindWithTag("Player");
        att = Player1.GetComponent<PlayerAttack>();
        stat = Player1.GetComponent<PlayerStat>();
    }

    void Update()
    {
        MoneyShopText.GetComponent<TextMeshProUGUI>().text = PlayerStat.Money.ToString("f0");
    }

    public void ExitPanel()
    {
        exitPanel.SetActive(true);
        TimeStopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void buyRange()
    {
        if (PlayerStat.Money >= 25000)
        {
            PlayerStat.Money -= 25000;
            att.Ranged = true;
            Sold1.SetActive(true);
        }
    }

    public void buyKey()
    {
        if (PlayerStat.Money >= 500000)
        {
            PlayerStat.Money -= 500000;
            stat.Key = true;
            Sold2.SetActive(true);
        }
    }

    public void closeShop()
    {
        exitPanel.SetActive(false);
        TimeStopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
