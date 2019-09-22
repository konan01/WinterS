using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] static int score;


     public TextMeshProUGUI text;


    void Start ()
    {
        text =GameObject.FindGameObjectWithTag("Score").GetComponent <TextMeshProUGUI> ();
        score = 0;
    }

    void OnGUI()
    {
        //GUILayout.Label("Очки: ", GUILayout.Width(1000), GUILayout.Height(1000));
        //GUI.Label(new Rect(Screen.width-50, Screen.height - 100, 100, 100), "Очки: ");
    }
    void Update ()
    {
        text.text = "Очки: " + score;
    }
    public static void SetScore(int value)
    {
        score = value;

    }
    public static void AddScore(int value)
    {
        score += value;

    }
    public static int GetScore()
    {

        return score;
    }
}
