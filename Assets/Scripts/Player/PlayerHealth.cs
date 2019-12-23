using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerHealth : MonoBehaviour
{
    public static int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public ScenesLoader sceneLoader;

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
        sceneLoader = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ScenesLoader>(); 
    }


    void FixedUpdate ()
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
        PhotonNetwork.LeaveRoom();
        sceneLoader.BackToMenu();
       // PhotonNetwork.Destroy(gameObject);
        
        //playerShooting.DisableEffects ();

        //anim.SetTrigger ("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play ();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
        
    }

   
    public void TakeDamage(int amount)
    {
        //damaged = true;
        //if(photonNetwork.ismine) Handheld.Vibrate(); 
        if (!goodmode)
            currentHealth -= amount;

        //playerAudio.Play ();

        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void RestoreHP()
    {
        isDead = false;
        currentHealth = startingHealth;
    }
   

}
