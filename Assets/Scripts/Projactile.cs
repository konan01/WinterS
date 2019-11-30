using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projactile : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] public static int velocity=400;
    public int debugvelocity = 500;
    GameObject Player;
    Rigidbody rigidbody;
    float timer;
    void Start()
    {
       
        rigidbody = GetComponent < Rigidbody>();
    }

    void OnTriggerEnter(Collider collision)
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        // Debug.Log(collision.gameObject);
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        //print(enemyHealth);
        //if (collision.gameObject.name == "Enemy" && collision.gameObject.name == "BigEnemy")
        //{
        //    Debug.Log(enemyHealth.currentHealth);
        //    if (enemyHealth != null)
        //    {
        //        Debug.Log(enemyHealth.currentHealth);

        //        Destroy(gameObject);
        //    }
        //}
        if (collision.gameObject.name != "Player_Pr(Clone)" && collision.gameObject.name != transform.gameObject.name)
        {
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(PlayerShooting.damagePerShot*PlayerWeapon.GetMyltiplaer());
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Debug.Log(collision.gameObject);
    //    EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

    //    //if (collision.gameObject.name == "Enemy" && collision.gameObject.name == "BigEnemy")
    //    //{
    //    //    Debug.Log(enemyHealth.currentHealth);
    //    //    if (enemyHealth != null)
    //    //    {
    //    //        Debug.Log(enemyHealth.currentHealth);

    //    //        Destroy(gameObject);
    //    //    }
    //    //}
    //    if (collision.gameObject.name != Player.name && collision.gameObject.name != transform.gameObject.name)
    //    {
    //        if (enemyHealth != null)
    //        {
    //            enemyHealth.TakeDamage(PlayerShooting.damagePerShot);
    //            Destroy(gameObject);
    //        }
    //        else
    //            Destroy(gameObject);
    //    }

    //}
    public void Shoot()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       // velocity = debugvelocity;

        timer += Time.deltaTime;
        rigidbody.AddForce(transform.forward * velocity);
        if (timer >= 5f)
        {
            Destroy(gameObject);
        }
    }
}
