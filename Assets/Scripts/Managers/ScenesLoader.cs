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

    Camera cameraMenu;
    Camera cameraCharester;
    // Start is called before the first frame update
    void Start()
    {
        listEnemy = GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<EnemyBase>();
        cameraMenu = Camera.main;
        cameraCharester = GameObject.FindGameObjectWithTag("CameraCharester").GetComponent<Camera>();
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

    }
    public void ButtonConnectToRoom()
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
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);
        
        load.LoadNewGame();
        cameraMenu.GetComponent<AudioListener>().enabled = false;
        cameraMenu.enabled = false;
       
    }
    public void TurnOnManagers()
    {
        upgradeManager.SetActive(true);
        enemyManager.SetActive(true);//временное включение врагов
    }
    public void TurnOffManagers()
    {
        upgradeManager.SetActive(false);
        enemyManager.SetActive(false);//временное отключение врагов
    }
    public void ContinueGame()
    {
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);
        load.LoadContine();
        menu = false;

        //enemy_manager.SetActive(true);//временное отключение\включение врагов
        //Time.timeScale = 1;

    }
    public void BackToMenu()
    {
        //save.SaveGame();
        TurnOffManagers();
        listEnemy.DestroyAllEnemy();
        canvasGame.SetActive(false);
        canvasMenu.SetActive(true);

        cameraMenu.GetComponent<AudioListener>().enabled = true;
        cameraMenu.enabled = true;
        //Respawn();
        //load.LoadContine();
        //gameObject.SetActive(false);
        //SceneManager.LoadScene();

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
