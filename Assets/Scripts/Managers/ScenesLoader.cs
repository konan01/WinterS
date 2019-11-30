using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScenesLoader : MonoBehaviour
{
    public static bool menu = true;
    public EnemyBase listEnemy;
    public GameObject canvasMenu;
    public GameObject canvasGame;
    public GameObject upgradePanel;
    public GameObject enemyManager;
   
    public GameObject creaeRoomPanel;
    public GameObject roomListPanel;
    public GameObject upgradeManager;

    public Transform playerTransform;
    public Load load;
    public Save save;
    // Start is called before the first frame update
    void Start()
    {
        listEnemy = GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<EnemyBase>();
       // Time.timeScale = 0;
        canvasMenu.SetActive(false);
        canvasGame.SetActive(false);
        upgradePanel.SetActive(false);
        enemyManager.SetActive(false);//временное отключение\включение врагов
        upgradeManager.SetActive(false);

        canvasMenu.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void Respawn()
    {
        listEnemy.DestroyAllEnemy();

        playerTransform.position = Vector3.zero;
        playerTransform.rotation = Quaternion.identity;
        playerTransform.GetComponent<PlayerHealth>().RestoreHP();


    }
    public void ButtonCreateRoom()
    {
        creaeRoomPanel.SetActive(!creaeRoomPanel.activeSelf);

    }public void ButtonConnectToRoom()
    {
        roomListPanel.SetActive(!roomListPanel.activeSelf);

    }
    public void BackToMenu(bool triger)
    {
        //save.SaveGame();
        canvasMenu.SetActive(triger);
        Respawn();
        
    }
    public void ShowUpgradeScreen()
    {
        upgradePanel.SetActive(!upgradePanel.activeSelf);

    }
    public void NewGame()
    {
        //menu = false;
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);
        
        load.LoadNewGame();
        Camera.main.GetComponent<AudioListener>().enabled = false;
        Camera.main.enabled = false;
        
        upgradeManager.SetActive(true);
        //enemyManager.SetActive(true);//временное отключение\включение врагов
        //Time.timeScale = 1;

        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

    }
    public void ContinueGame()
    {

        //menu = false;
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);
        load.LoadContine();
        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        //SceneManager.LoadScene(2, LoadSceneMode.Additive);
        //SceneManager.LoadScene(2, LoadSceneMode.Single);
        menu = false;

        //enemy_manager.SetActive(true);//временное отключение\включение врагов
        //Time.timeScale = 1;

    }
    public void RestGame()
    {


        save.SaveGame();
        Respawn();
        //load.LoadContine();
        //gameObject.SetActive(false);
        Time.timeScale = 1;
        //SceneManager.LoadScene();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
