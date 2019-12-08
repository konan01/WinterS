using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI debugtext;
    public TMP_InputField Nameroom;
   
    bool isConnected=false;
  
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1, 10000);
        Log("Player name set " + PhotonNetwork.NickName);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
        
    }

    
    public override void OnConnectedToMaster()
    {
        isConnected = true;
        Log("Connected to master");
        
    }
   
    public void CreateLobby()
    {
        if (isConnected)
        {
            PhotonNetwork.CreateRoom(Nameroom.text, new Photon.Realtime.RoomOptions { MaxPlayers = 3 });
        }
       
    }
    public void JoinLobby()
    {
        if(isConnected)
        PhotonNetwork.JoinRoom(Nameroom.text);
    }
    public override void OnJoinedRoom()
    {
        Log("Connected to Room");
       
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void Log(string message)
    {
        debugtext.text += "\n";
        debugtext.text += message ;


    }
}
