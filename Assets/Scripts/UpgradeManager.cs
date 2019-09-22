using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    public void OpenUpgradeDialog(GameObject panel)
    {
        if(panel.activeSelf)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        panel.SetActive(!panel.activeSelf);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
