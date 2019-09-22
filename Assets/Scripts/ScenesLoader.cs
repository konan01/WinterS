using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScenesLoader : MonoBehaviour
{
    public GameObject canvas_menu;
    public GameObject canvas_game;
    public GameObject continue_button;
    
    public Load load;
    public static bool menu=true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/Data/data.save"))  //chek file to hide/show continue button
        {
            continue_button.SetActive(true);
            //print(Directory.Exists(Application.persistentDataPath + "/Data/data.save"));
        }
        else
        {
            continue_button.SetActive(false);
        }

    }
    public void NewGame(int index)
    {


        canvas_menu.SetActive(false);
        canvas_game.SetActive(true);
        
        load.Load_Default();
        menu = false;
        Time.timeScale = 1;
        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        
    }
    public void ContinueGame(int index)
    {

        canvas_menu.SetActive(false);
        canvas_game.SetActive(true);
        load.MLoad();
        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        //SceneManager.LoadScene(2, LoadSceneMode.Additive);
        //SceneManager.LoadScene(2, LoadSceneMode.Single);
        menu = false;
        Time.timeScale = 1;
        
    }
}
