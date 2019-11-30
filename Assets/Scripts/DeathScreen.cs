using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public bool isDeath;
    public ScenesLoader scenesLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ShowDeathScreen()
    {
        isDeath = true;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        isDeath = false;
        //gameObject.SetActive(false);
        scenesLoader.RestGame();
        gameObject.SetActive(false);
        //SceneManager.LoadScene(index);
    }
    public void ShowUpgradeScreen()
    {
        scenesLoader.ShowUpgradeScreen();
    }
    public void BackToMainMenu()
    {
        scenesLoader.BackToMenu(true);
        gameObject.SetActive(false);
    }
}
