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
        timer += Time.deltaTime;
        timer_boss += Time.deltaTime;

        if (timer_boss >= 11f) { boss = GameObject.FindGameObjectWithTag("Boss"); timer_boss = 0; }    //проверка имеется ли босс на сцене

        if (timer >= spawnTime && boss == null)
        { Spawn(); timer = 0; }
        

    }
    void Spawn ()
    {
        if (boss == null)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }

    void SpawnBoss()
    {

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
