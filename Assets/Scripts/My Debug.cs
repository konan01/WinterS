using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MyDebug : MonoBehaviour
{
    public TextMeshProUGUI Debug;
    public string DebugText;


    void Update()
    {
        Debug.text = DebugText;
    }

    public MyDebug(string DebugText)
    {
        this.DebugText = DebugText;
    }
}
