using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScenesLoader : MonoBehaviour
{
    public GameObject canvasMenu;                  //camvas
    public GameObject canvasGame;                  //camvas

    public GameObject upgradePanel;                //Panels
    public GameObject creaeRoomPanel;              //Panels
    public GameObject roomListPanel;               //Panels
    public GameObject menuPanel;                   //Panels
    public GameObject characterSelectPanel;        //Panels

    public EnemyBase listEnemy;                    //Managers
    public GameObject upgradeManager;              //Managers
    public GameObject enemyManager;                //Managers
    public GameObject playerInfo;                  //Managers
    public GameObject characterManager;            //Managers


    public Transform playerTransform;

    public Load load;
    public Save save;

    [SerializeField] Camera cameraMenu;
    [SerializeField] Camera cameraCharaster;
    // Start is called before the first frame update
    void Start()
    {
        load.LoadNewGame();
        listEnemy = GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<EnemyBase>();
        cameraMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cameraCharaster = GameObject.FindGameObjectWithTag("CameraCharester").GetComponent<Camera>();
      
        canvasMenu.SetActive(false);
        canvasGame.SetActive(false);
        upgradePanel.SetActive(false);
        enemyManager.SetActive(false);//временное отключение\включение врагов


        canvasMenu.SetActive(true);
        if (!Directory.Exists(Application.persistentDataPath + "/Data"))
        {
            CharacterSelect();print("Выбор персонажа");
        }
        else
        {
            ContinueGame();print("продолжить");
        }
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
    //public void BackToMenu(bool triger)
    //{
    //    save.SaveGame();
    //    canvasMenu.SetActive(triger);
    //    Respawn();

    //}
    public void ShowUpgradeScreen()
    {
        upgradePanel.SetActive(!upgradePanel.activeSelf);
    }
    public void NewGame()
    {
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);
        
        //load.LoadNewGame();
        cameraMenu.GetComponent<AudioListener>().enabled = false;
        cameraMenu.enabled = false;
       
    }
    public void TurnOnManagers()
    {
        upgradeManager.SetActive(true);
        playerInfo.SetActive(true);
        enemyManager.SetActive(true);//временное включение врагов
    }
    public void TurnOffManagers()
    {
        upgradeManager.SetActive(false);
        playerInfo.SetActive(false);
        enemyManager.SetActive(false);//временное отключение врагов
    }
    public void ContinueGame()
    {
        save.CreateDefault();
        characterSelectPanel.SetActive(false);
        menuPanel.SetActive(true);
        cameraMenu.enabled = true;
        cameraCharaster.enabled =false;

        //load.LoadContine();
       
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
    public void CharacterSelect()
    {
        canvasGame.SetActive(false);
        menuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
        cameraMenu.enabled = false;
        cameraCharaster.enabled = true;
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
