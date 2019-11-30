using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complexity : MonoBehaviour
{
    public float complexity_time = 15f;
    public float timer;
    public float timer1;
    public EnemyBase masEnemy;
    public List<EnemyAttack> enemyOnScene;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        {

            masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth = masEnemy.masEnemy[i].GetComponent<EnemyHealth>().defaultHealth;
            masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage = masEnemy.masEnemy[i].GetComponent<EnemyAttack>().defaultAttackDamage;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer +=  Time.deltaTime;
        timer1 +=  Time.deltaTime;
        if (timer >= complexity_time)
        {

            complexity_time += timer / 2;
           
            MoreComplexity();
            timer = 0f;
        }
        if (timer1 >= 60f)
        {
            IncreaseScoreValue();
            timer1 = 0f;
        }
        
    }

    private void IncreaseScoreValue()
    {
        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
            masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue += (masEnemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue + (int)complexity_time) / 4;
    }

    private void MoreComplexity()
    {
        
        for (int i = 0; i < masEnemy.tmp.Length; i++)
        {
            if (masEnemy.tmp[i] != null)
            {
                enemyOnScene.Add(masEnemy.tmp[i].GetComponent<EnemyAttack>());
                //enemyHealth[i].currentHealth += (int)timer;
                enemyOnScene[i].currentAttackDamage += (int)timer;
            }

        }
        enemyOnScene.Clear();
        
        for (int i = 0; i < masEnemy.masEnemy.Length; i++)
        {
            masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth += masEnemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth + (int)timer;
            masEnemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage += (int)timer;
        }
    }
}
