﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI debugtext;
    public TMP_InputField Nameroom;
    public ScenesLoader scenesLoader;
    public MyRoomList roomList;
    // public List<Room> rooms;
    bool isConnected=false;
    Room newRoom;
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
            newRoom = new Room(Nameroom.text, new Photon.Realtime.RoomOptions { MaxPlayers = 3 });
            roomList.AddRoom(newRoom);
            PhotonNetwork.CreateRoom(Nameroom.text, new Photon.Realtime.RoomOptions { MaxPlayers = 3 });
           
        }
       
    }
    public override void OnDisable()
    {
        roomList.DeleteRoom(newRoom);
    }
    public void JoinLobby()
    {
        if(isConnected)
        PhotonNetwork.JoinRoom(Nameroom.text);
        
        //PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Log("Connected to Room");
        scenesLoader.NewGame();
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
