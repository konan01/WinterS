using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    List<float> distanse;

    public GameObject[] players;
    void Awake ()
    {
        distanse = new List<float>();
        players = GameObject.FindGameObjectsWithTag("Player");
        //player = GameObject.FindGameObjectWithTag ("Player").transform;

        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();

    }


    void FixedUpdate ()
    {
        CalcDistance();
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
            nav.SetDestination (players[minDistance()].transform.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
    void CalcDistance()
    {
        
        
        for (int i = 0; i < players.Length; i++)
        {
            distanse.Add(Vector3.Distance(transform.position, players[i].transform.position));
        }

        

    }
    int minDistance()
    {
        int index=0;
        float minDistanse = 0;

        for (int i = 0; i < distanse.Count; i++)
        {
            if (minDistanse > distanse[i])
            {
                minDistanse = distanse[i];
                index = i;
            }
        }

        return index;

    }


}
