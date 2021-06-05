using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static string fileSave1;
    public static string fileSave2;
    public static string fileSave3;
    public EnemyBase masEnemy;
    // Start is called before the first frame update
    void Start()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data");
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/Saves");
        }
        //file = "Data/Save/data.save";
        fileSave1 = Application.persistentDataPath+ "/Data/Saves/save data1.save";
        fileSave2 = Application.persistentDataPath+ "/Data/Saves/save data2.save";
        fileSave3 = Application.persistentDataPath+ "/Data/Saves/save data3.save";
        //CreateDefault();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            SaveEncripted();
        if (Input.GetKeyDown(KeyCode.F6))
           loadEncripted();
    }

    public void CreateDefault()
    {

        if (!File.Exists(Application.persistentDataPath + "/Data/Saves/default.save"))
        {
            StreamWriter sw_file = new StreamWriter(Application.persistentDataPath + "/Data/Saves/default.save");
            sw_file.WriteLine("100");
            sw_file.WriteLine("0");
            sw_file.WriteLine("20");
            sw_file.WriteLine("0.2");
            sw_file.WriteLine("155");



            for (int i = 0; i < masEnemy.masEnemy.Length; i++)
            {
                sw_file.WriteLine();
                sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().defaultHealth);
                sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyAttack>().defaultAttackDamage);
                sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue);


            }
            sw_file.Close();

        }
        else return;
    }
    public void SaveGameCell1()
    {
        StreamWriter sw_file = new StreamWriter(fileSave1);
        sw_file.WriteLine(PlayerHealth.startingHealth);
        sw_file.WriteLine(ScoreManager.GetScore());
        sw_file.WriteLine(PlayerShooting.damagePerShot);

        sw_file.WriteLine(PlayerShooting.timeBetweenBullets);
        sw_file.WriteLine(Projactile.velocity);
        sw_file.WriteLine(UpgradeManager.costUpgradeHP);

        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        {
            sw_file.WriteLine();
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue);


        }
        sw_file.Close();
    }
    public void SaveGameCell2()
    {
        StreamWriter sw_file = new StreamWriter(fileSave2);
        sw_file.WriteLine(PlayerHealth.startingHealth);
        sw_file.WriteLine(ScoreManager.GetScore());
        sw_file.WriteLine(PlayerShooting.damagePerShot);

        sw_file.WriteLine(PlayerShooting.timeBetweenBullets);
        sw_file.WriteLine(Projactile.velocity);
        sw_file.WriteLine(UpgradeManager.costUpgradeHP);

        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        {
            sw_file.WriteLine();
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue);


        }
        sw_file.Close();
    }
    public void SaveGameCell3()
    {
        StreamWriter sw_file = new StreamWriter(fileSave3);
        sw_file.WriteLine(PlayerHealth.startingHealth);
        sw_file.WriteLine(ScoreManager.GetScore());
        sw_file.WriteLine(PlayerShooting.damagePerShot);

        sw_file.WriteLine(PlayerShooting.timeBetweenBullets);
        sw_file.WriteLine(Projactile.velocity);
        sw_file.WriteLine(UpgradeManager.costUpgradeHP);

        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        {
            sw_file.WriteLine();
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue);
        }
        sw_file.Close();
    }
    public void SaveEncripted()
    {
        string tmp;
        StreamWriter sw_file = new StreamWriter(Application.persistentDataPath + "/Data/data1.save");
        tmp = "" + PlayerHealth.startingHealth+"\n"
                + ScoreManager.GetScore()+ "\n"
                + PlayerShooting.damagePerShot+ "\n"
                + PlayerShooting.timeBetweenBullets + "\n"
                + Projactile.velocity+ "\n"
                + UpgradeManager.costUpgradeHP+ "\n"
                ;
        
        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        {
            tmp += "\n"
                        + masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth+"\n"
                        + masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage+ "\n"
                        + masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue+ "\n"
                        ;
            
        }
        byte[] bate = Encoding.UTF8.GetBytes(tmp);
        string tmpr = BitConverter.ToString(bate);
        sw_file.Write(tmpr.Replace("-",""));
        sw_file.Close();
        
    }
    public void loadEncripted()
    {
        string tmp;
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Data/data1.save");
        tmp = sr.ReadToEnd();
        int charcount = tmp.Length;
        byte[] bytes = new byte[charcount / 2];
        for (int i = 0; i < charcount; i+=2)
        {
            bytes[i / 2] = Convert.ToByte(tmp.Substring(i, 2), 16);
        }
        tmp = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        StreamWriter sw_file = new StreamWriter(Application.persistentDataPath + "/Data/data2.save");
        sw_file.Write(tmp);
        sw_file.Close();
    }
}
