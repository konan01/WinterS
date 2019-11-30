using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public GameObject boss;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    


    float timer=0;
    float timer_boss=0;

    void Start ()
    {

       
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void FixedUpdate()
    {

        if(boss==null)
        timer += Time.deltaTime;
        timer_boss += Time.deltaTime;

        if (timer_boss >= 5f) { boss = GameObject.FindGameObjectWithTag("Boss"); timer_boss = 0; }    //проверка имеется ли босс на сцене

        if (timer >= spawnTime)
        { Spawn(); timer = 0; }
        
    }
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        PhotonNetwork.Instantiate(enemy.name, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
    
}
