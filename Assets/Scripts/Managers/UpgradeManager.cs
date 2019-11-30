using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    [SerializeField] public static int costUpgradeHP = 20;
    [SerializeField] public static int costCountProjactle = 200;
    [SerializeField] public static int costHealing = 115;
    //[SerializeField] public static int costCountProjactle = 200;
    //[SerializeField] public static int costCountProjactle = 200;
    //[SerializeField] public static int costCountProjactle = 200;
    public TextMeshProUGUI UpgradeHPText;
    public TextMeshProUGUI UpgradeCountProjactleText;
    public TextMeshProUGUI CostHealingText;
    //public TextMeshProUGUI UpgradeHPText;
    //public TextMeshProUGUI UpgradeHPText;
    //public TextMeshProUGUI UpgradeHPText;

    PlayerHealth playerHealth;
    PlayerWeapon playerWeapon;
    // Start is called before the first frame update
    void Awake()
    {
        
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        UpgradeHPText.text = costUpgradeHP + " Очков";
        UpgradeCountProjactleText.text = costCountProjactle + " Очков";
        CostHealingText.text = costHealing + " Очков";
    }
    public void ImproveHP()
    {
        if (ScoreManager.GetScore() >= costUpgradeHP)
        {
            PlayerHealth.startingHealth += 10;
            ScoreManager.AddScore(-costUpgradeHP);
            costUpgradeHP += 7 + (PlayerHealth.startingHealth / 10);
        }
    }
    public void ImproveCountProjactle()
    {
        if (playerWeapon.GetWeaponLevel() > 0)
        {
            if ((PlayerShooting.length - playerWeapon.GetWeaponLevel())==0)
            {
                if (ScoreManager.GetScore() >= costCountProjactle)
                {
                    if (PlayerShooting.length < 9)
                    {
                        PlayerShooting.length += 1;
                        ScoreManager.AddScore(-costCountProjactle);
                        costCountProjactle += costCountProjactle * 2;
                    }
                }
            }
            else print("Уровень оружия слишком мал");
        }
        else if(playerWeapon.GetWeaponLevel() <= 0)
            print("Уровень оружия слишком мал");
    }
    public void OpenUpgradeDialog(GameObject panel)
    {
        if (panel.activeSelf)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        panel.SetActive(!panel.activeSelf);
    }
    public void Healing()
    {
        if (ScoreManager.GetScore() >= costHealing)
        {
            playerHealth.currentHealth += (PlayerHealth.startingHealth / 100) * 10;
            ScoreManager.AddScore(-costHealing);
        }
    }
}
