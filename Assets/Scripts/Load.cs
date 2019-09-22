using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject level;
    public EnemyBase masEnemy;
    public Text tb;
    string text;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MLoad()
    {
        if (File.Exists(Application.persistentDataPath + "/Data/data.save"))
        {
            StreamReader sr =                   new StreamReader(Application.persistentDataPath + "/Data/data.save");

            PlayerHealth.startingHealth =       Convert.ToInt32(sr.ReadLine());
            ScoreManager.SetScore(              Convert.ToInt32(sr.ReadLine()));
            PlayerShooting.damagePerShot =      Convert.ToInt32(sr.ReadLine());
            PlayerShooting.timeBetweenBullets = float.Parse(sr.ReadLine());
            Projactile.velocity =               Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < masEnemy.masEnemy.Length; i++)
            {
                sr.ReadLine();
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth =       Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage = Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue =           Convert.ToInt32(sr.ReadLine());
            }

            sr.Close();
        }
        level.SetActive(!level.activeSelf);

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

    public void Load_Default()
    {
        //float TMP;
        if (File.Exists(Application.persistentDataPath + "/Data/default.save"))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/Data/default.save");

            PlayerHealth.startingHealth =       Convert.ToInt32(sr.ReadLine());
            ScoreManager.SetScore(              Convert.ToInt32(sr.ReadLine()));
            PlayerShooting.damagePerShot =      Convert.ToInt32(sr.ReadLine());
            PlayerShooting.timeBetweenBullets = float.Parse(sr.ReadLine());
            print(PlayerShooting.timeBetweenBullets);
            //printTB(PlayerShooting.timeBetweenBullets.ToString());
            Projactile.velocity =               Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < masEnemy.masEnemy.Length; i++)
            {
                sr.ReadLine();
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth =       Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage = Convert.ToInt32(sr.ReadLine());
                masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue =           Convert.ToInt32(sr.ReadLine());
            }
            sr.Close();
        }

        printTB(PlayerShooting.timeBetweenBullets.ToString());

        level.SetActive(!level.activeSelf);
    }

    void printTB(string t)
    {
        tb.text = t;

    }
}
