using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject continue_button;
    public EnemyBase masEnemy;

    string text;
    // Start is called before the first frame update
    void Start()
    {
        //if (File.Exists(Application.persistentDataPath + "/Data/data.save"))  //chek file to hide/show continue button
        //{
        //    continue_button.SetActive(true);
        //    //print(Directory.Exists(Application.persistentDataPath + "/Data/data.save"));
        //}
        //else
        //{
        //    continue_button.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void LoadContine()
    {
        if (File.Exists(Application.persistentDataPath + "/Data/data.save"))
        {
            StreamReader sr =                   new StreamReader(Application.persistentDataPath + "/Data/data.save");

            PlayerHealth.startingHealth =       Convert.ToInt32(sr.ReadLine());
            ScoreManager.SetScore(              Convert.ToInt64(sr.ReadLine()));
            PlayerShooting.damagePerShot =      Convert.ToInt32(sr.ReadLine());
            PlayerShooting.timeBetweenBullets = float.Parse(sr.ReadLine());
            Projactile.velocity =               Convert.ToInt32(sr.ReadLine());
            UpgradeManager.costUpgradeHP =      Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < masEnemy.masEnemy.Length; i++)
            {
                sr.ReadLine();
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth =       Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage = Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue =           Convert.ToInt32(sr.ReadLine());
            }

            sr.Close();
        }

        

        //StreamReader sr1 = new StreamReader(Application.persistentDataPath + "/Data/data.save");

        //text += sr1.ReadLine()+"\n";
        //text += sr1.ReadLine()+"\n";
        //text += sr1.ReadLine()+"\n";
        //text += sr1.ReadLine()+"\n";
        //text += sr1.ReadLine()+"\n";



        //for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        //{
        //    sr1.ReadLine();
        //    text += sr1.ReadLine() + "\n";
        //    text += sr1.ReadLine() + "\n";
        //    text += sr1.ReadLine() + "\n";
        //}

        //sr1.Close();
        //printTB(text);

    }

    public void LoadNewGame()
    {
        float tmp;
        if (File.Exists(Application.persistentDataPath + "/Data/default.save"))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/Data/default.save");

            PlayerHealth.startingHealth =       Convert.ToInt32(sr.ReadLine());
            ScoreManager.SetScore(              Convert.ToInt64(sr.ReadLine()));
            PlayerShooting.damagePerShot =      Convert.ToInt32(sr.ReadLine());
            tmp = float.Parse(sr.ReadLine());
            PlayerShooting.timeBetweenBullets = tmp;
            //print(PlayerShooting.timeBetweenBullets);
            //printTB(PlayerShooting.timeBetweenBullets.ToString());
            Projactile.velocity =               Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < masEnemy.masEnemy.Length; i++)
            {
                sr.ReadLine();
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth =       Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponentInChildren<EnemyAttack>().startingAttackDamage = Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue =           Convert.ToInt32(sr.ReadLine());
            }
            sr.Close();
        }

    }

    
}
