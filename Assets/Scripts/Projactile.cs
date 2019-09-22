using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projactile : MonoBehaviour
{
    // Start is called before the first frame update
    public static int velocity=155;
    GameObject Player;
    Rigidbody rigidbody;
    public float timer;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = GetComponent < Rigidbody>();
    }
    void OnTriggerEnter(Collider collision)
    {
        // Debug.Log(collision.gameObject);
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        //if (collision.gameObject.name == "Enemy" && collision.gameObject.name == "BigEnemy")
        //{
        //    Debug.Log(enemyHealth.currentHealth);
        //    if (enemyHealth != null)
        //    {
        //        Debug.Log(enemyHealth.currentHealth);

        //        Destroy(gameObject);
        //    }
        //}
        if (collision.gameObject.name != Player.name && collision.gameObject.name != transform.gameObject.name)
        {
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(PlayerShooting.damagePerShot);
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject);
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        //if (collision.gameObject.name == "Enemy" && collision.gameObject.name == "BigEnemy")
        //{
        //    Debug.Log(enemyHealth.currentHealth);
        //    if (enemyHealth != null)
        //    {
        //        Debug.Log(enemyHealth.currentHealth);

        //        Destroy(gameObject);
        //    }
        //}
        if (collision.gameObject.name != Player.name && collision.gameObject.name != transform.gameObject.name)
        {
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(PlayerShooting.damagePerShot);
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }

    }
    public void Shoot()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        timer += 1*Time.deltaTime;
        rigidbody.AddForce(transform.forward * velocity);
        if (timer >= 13f)
        {
            Destroy(gameObject);
        }
    }
}
