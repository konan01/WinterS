using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chekserverstate : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        gameObject.GetComponentInChildren<Image>().color = Color.green;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
