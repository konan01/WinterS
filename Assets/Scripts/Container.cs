using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Container : MonoBehaviour
{
    public int id;
    public string Name;
    public string Map;
    public string CountPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void JoinLobby()
    {
        PhotonNetwork.JoinRoom(Name);
        //PhotonNetwork.JoinRandomRoom();
    }
    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Name;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Map;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = CountPlayers;
    }
}
