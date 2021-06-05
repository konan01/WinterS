using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject[] masEnemy;
    public GameObject[] tmp;

    float timer;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            SearchEnemy();
            timer = 0;
        }
    }
    private void SearchEnemy()
    {
        tmp = GameObject.FindGameObjectsWithTag("Enemy");
 //       tmp = GameObject.FindGameObjectsWithTag("Boss");
    }
    public void DestroyAllEnemy()
    {
        for (int i = 0; i < tmp.Length; i++)
        {
            Destroy(tmp[i]);
        }
    }
}
