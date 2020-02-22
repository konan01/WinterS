using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharecterManager : MonoBehaviour
{

    public GameObject charecterField;
    public Camera charecterCamera;


    public Save save;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharacterSelection(int index)
    {
        switch(index)
        {
            case 0:
                save.SaveGameCell1();
                break;
            case 2:
                save.SaveGameCell2();
                break;
            case 3:
                save.SaveGameCell3();
                break;
        }
           
    }
}
