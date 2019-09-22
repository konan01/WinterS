using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static string file;
    public EnemyBase masEnemy;
    // Start is called before the first frame update
    void Start()
    {
        if(!Directory.Exists(Application.persistentDataPath + "/Data"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Data");
        //file = "Data/Save/data.save";
        file = Application.persistentDataPath+"/Data/data.save";
        CreateDefault();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            MSave();
    }

    public void MSave()
    {
        string tmp;
        StreamWriter sw_file = new StreamWriter(file);
        sw_file.WriteLine(PlayerHealth.startingHealth);
        sw_file.WriteLine(ScoreManager.GetScore());
        sw_file.WriteLine(PlayerShooting.damagePerShot);

        sw_file.WriteLine(PlayerShooting.timeBetweenBullets);
        sw_file.WriteLine(Projactile.velocity);

        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        {
            sw_file.WriteLine();
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage);
            sw_file.WriteLine(masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue);
           

        }
        sw_file.Close();

    }
     void CreateDefault()
    {
       
        if (!File.Exists(Application.persistentDataPath + "/Data/default.save"))
        {
            StreamWriter sw_file = new StreamWriter(Application.persistentDataPath + "/Data/default.save");
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
}
