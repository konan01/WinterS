using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class ScoreManager : MonoBehaviour
{
     public TextMeshProUGUI textGamescore;
     public TextMeshProUGUI textBonusesCollected;
     public TextMeshProUGUI textEnemiesKilled;
     //public TextMeshProUGUI textGamescore;

    [SerializeField] static Int64 Gamescore;

    public static int bonusesCollected;
    public static int enemiesKilled;


    void Start ()
    {
        textGamescore = GameObject.FindGameObjectWithTag("Score").GetComponent <TextMeshProUGUI> ();
        Gamescore = 0;
    }

    void OnGUI()
    {
        //GUILayout.Label("Очки: ", GUILayout.Width(1000), GUILayout.Height(1000));
        //GUI.Label(new Rect(Screen.width-50, Screen.height - 100, 100, 100), "Очки: ");
    }
    void Update ()
    {
        textGamescore.text = Strings.score + Gamescore;
    }
    void TopScorePlayer()
    {
        

    }
    public static void SetScore(Int64 value)
    {
        Gamescore = value;

    }
    public static void AddScore(Int64 value)
    {
        Gamescore += value;

    }
    public static Int64 GetScore()
    {

        return Gamescore;
    }

}
