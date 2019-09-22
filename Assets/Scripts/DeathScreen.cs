using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public bool isDeath;
    public void show_UpgradeScreen(GameObject Screen)
    {
        gameObject.SetActive(false);
        Screen.SetActive(!Screen.activeSelf);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Death_Screen()
    {
        isDeath = true;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void RestartGame(int index)
    {
        //gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
}
