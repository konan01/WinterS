using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Jobs;

public class EnemyMovement : MonoBehaviour
{
    //Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    int distanseIndex=0;
    bool playerInRange;
    float randomWalkTimer =0;
    [SerializeField] GameObject[] player;
    void Awake ()
    {
        
        //distanse = new List<float>();
        player = GameObject.FindGameObjectsWithTag("Player");
        //player = GameObject.FindGameObjectWithTag ("Player").transform;

        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        nav.SetDestination(new Vector3(UnityEngine.Random.Range(-30, 20), 0, UnityEngine.Random.Range(-30, 30)));
        foreach (var item in player)
            print(item);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player[distanseIndex])
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player[distanseIndex])
        {
            playerInRange = false;
        }
    }

    void Update ()
    {
        randomWalkTimer += Time.deltaTime;
        CalcDistance();
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        // print(distanseIndex);
        if (player[distanseIndex] != null && playerInRange)
        {
            nav.SetDestination(player[distanseIndex].transform.position);
        }
        else if (!playerInRange && randomWalkTimer>=5)
        {
            nav.SetDestination(new Vector3(UnityEngine.Random.Range(-30, 20),0, UnityEngine.Random.Range(-30, 30)));
            randomWalkTimer = 0;
        }
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
    void CalcDistance()
    {
        NativeList<float3> players = new NativeList<float3>(Allocator.TempJob);
        NativeList<float> distanse = new NativeList<float>(Allocator.TempJob);
        NativeArray<int> index = new NativeArray<int>(1,Allocator.TempJob);
        foreach (var item in player)
        {
            players.Add(item.transform.position);
        }
        DistanseCalculate job = new DistanseCalculate
        {
            player = players,
            monster = transform.position,
            distanse = distanse,
            index = index,
            minDistanse=0
        };
        JobHandle jobHandle = job.Schedule();
        jobHandle.Complete();
        
        distanseIndex= job.index[0];
        players.Dispose();
        distanse.Dispose();
        index.Dispose();
        //if (players!=null)
        //{
        //    for (int i = 0; i < players.Length; i++)
        //    {
        //        if (players[i] != null)
        //            distanse.Add(Vector3.Distance(transform.position, players[i].transform.position));
        //    }
        //}
    }
    //int minDistance()
    //{
    //    int index=0;
    //    float minDistanse = 0;

    //    for (int i = 0; i < distanse.Count; i++)
    //    {
    //        if (minDistanse > distanse[i])
    //        {
    //            minDistanse = distanse[i];
    //            index = i;
    //        }
    //    }

    //    return index;

    //}

}
[BurstCompile]
public struct DistanseCalculate : IJob
{
    public NativeList<float3> player;
    public float3 monster;
    public NativeList<float> distanse;

    public NativeArray<int> index;
    public float minDistanse;
    public void Execute()
    {
        
        for (int i = 0; i < player.Length; i++)
        {
            
            distanse.Add(math.distance(monster, player[i]));
        }
        minDistanse = distanse[0];
        for (int i = 0; i < distanse.Length; i++)
        {
            
            if (minDistanse > distanse[i])
            {
                minDistanse = distanse[i];
                index[0] = i;
            }
        }
        
    }

}
