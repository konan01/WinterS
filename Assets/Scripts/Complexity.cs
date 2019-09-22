using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complexity : MonoBehaviour
{
    public float complexity_time = 15f;
    public float timer;
    public float timer1;

    public EnemyBase enemy;
    public List<EnemyAttack> enemyOnScene;
    public GameObject[] tmp;
    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < enemy.masEnemy.Length; i++)
        {

            enemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth = enemy.masEnemy[i].GetComponent<EnemyHealth>().defaultHealth;
            enemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage = enemy.masEnemy[i].GetComponent<EnemyAttack>().defaultAttackDamage;
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
            for (int i = 0; i < enemy.masEnemy.Length; i++)
                enemy.masEnemy[i].GetComponent<EnemyHealth>().scoreValue += 10;
            timer1 = 0f;
        }

    }
    
    private void MoreComplexity()
    {
        tmp = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < tmp.Length; i++)
        {
            enemyOnScene.Add(tmp[i].GetComponent<EnemyAttack>());
            //enemyHealth[i].currentHealth += (int)timer;
            enemyOnScene[i].currentAttackDamage = (int)timer;

        }
        enemyOnScene.Clear();
        
        for (int i = 0; i < enemy.masEnemy.Length; i++)
        {
            enemy.masEnemy[i].GetComponent<EnemyHealth>().startingHealth += (int)timer;
            enemy.masEnemy[i].GetComponent<EnemyAttack>().startingAttackDamage = (int)timer;
        }
    }
}
