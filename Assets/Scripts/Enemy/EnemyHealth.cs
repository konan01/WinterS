using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int defaultHealth = 100;
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    

    ParticleSystem hitParticles;
    bool isDead;
    bool isSinking;
    

    void Awake ()
    {
        hitParticles = GetComponentInChildren <ParticleSystem> ();
      
        currentHealth = startingHealth;
    }


    void Update ()
    {
        //if(isSinking)
        //{
        //    transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        //}
        
    }


    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

        //enemyAudio.Play ();

        currentHealth -= amount;

        // hitParticles.transform.position = hitPoint;
        // hitParticles.Play();
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            ScoreManager.AddScore(scoreValue);
            Death ();
        }
    }


    void Death ()
    {
       
        isDead = true;
        Destroy(gameObject);
        

    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
    
}
