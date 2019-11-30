using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public static int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public DeathScreen deathScreen;

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    public bool goodmode;
    bool isDead;
    bool damaged;
    

    void Awake ()
    {
        Time.timeScale = 1;
        //anim = GetComponent <Animator> ();
       // playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        healthSlider = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<Slider>();
    }


    void Update ()
    {
        //if(isDead)
        //{

        //    deathScreen.ShowDeathScreen();
        //}
        healthSlider.maxValue=startingHealth;
        healthSlider.value = currentHealth;
    }

    void Death ()
    {
        
        isDead = true;
        //playerShooting.DisableEffects ();

        //anim.SetTrigger ("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play ();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
        deathScreen.ShowDeathScreen();
    }

   
    public void TakeDamage(int amount)
    {
        //damaged = true;
        Handheld.Vibrate();
        currentHealth -= amount;

        

        //playerAudio.Play ();

        if (currentHealth <= 0 && !isDead)
        {
            if (!goodmode)
                Death();
        }
    }
    public void RestoreHP()
    {
        isDead = false;
        currentHealth = startingHealth;
    }
   

}
