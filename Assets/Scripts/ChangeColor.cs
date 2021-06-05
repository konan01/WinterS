using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeColor : MonoBehaviour
{
    Color darkgrey= new Color(85, 85, 85);
    public void changeColor()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.grey;
    }
}
