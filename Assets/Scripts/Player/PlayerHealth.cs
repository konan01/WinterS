using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public Save save;
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
    }


    void Update ()
    {
        if(isDead)
        {
           
            deathScreen.Death_Screen();
        }
    }


    public void TakeDamage (int amount)
    {
        //damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        //playerAudio.Play ();

        if (currentHealth <= 0 && !isDead)
        {
            if(!goodmode)
                Death();
        }
    }


    void Death ()
    {
        save.MSave();
        isDead = true;

        //playerShooting.DisableEffects ();

        //anim.SetTrigger ("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play ();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
        deathScreen.Death_Screen();
    }


    
}
