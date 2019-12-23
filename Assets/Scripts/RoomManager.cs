using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI debugText;
    
    public Transform spawnPooint;
    public Transform cameraSpawnPooint;

    public GameObject playerPrefab;
    public Camera cameraPrefab;
    public GameObject ListRoomBit;
    public GameObject container;
    public ScenesLoader scenesLoader;

    public TMP_InputField nameRoom;
    public TMP_InputField passwordRoom;

    TypedLobby lobby = new TypedLobby("sdfsd", LobbyType.Default);
    List<Container> containers;
    bool isConnected = false;
    float timer;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateListRoom(roomList);
       // print(roomList[0].Name + " " + roomList[0].PlayerCount);
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
        Log(newPlayer.NickName+" connected to room");
    }

    // Start is called before the first frame update
    void Start()
    {
        containers = new List<Container>();
        //UpdateListRoom();
    }
    
    public override void OnConnectedToMaster()
    {
        isConnected = true;
        PhotonNetwork.JoinLobby(lobby);
    }
    public override void OnJoinedLobby()
    {
        print("Lobby Joined"+lobby);
        
    }
    public void CreateLobby()
    {
        if (isConnected)
        {
            //print(passwordRoom.text);
            if (!passwordRoom.text.Equals(""))
                PhotonNetwork.CreateRoom(nameRoom.text, new RoomOptions { MaxPlayers = 3 , IsOnPassProtected=true, Password=PasswordEncryption(passwordRoom.text) }); 
            else
                PhotonNetwork.CreateRoom(nameRoom.text, new RoomOptions { MaxPlayers = 3, IsOnPassProtected = false });
        }
        //print(PasswordEncryption(passwordRoom.text));
    }
    //public void JoinRoom()
    //{
    //    if (isConnected)

    //        PhotonNetwork.JoinRoom(nameRoom.text);
    //}

    public override void OnJoinedRoom()
    {
        scenesLoader.NewGame();
        Spawn();
        scenesLoader.TurnOnManagers();
        print(containers.Count);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(PhotonNetwork.IsConnected)
        if (!PhotonNetwork.InRoom && PhotonNetwork.InLobby && timer >= 5)
        {
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.JoinLobby(lobby);
            timer = 0;
        }
    }

    private void UpdateListRoom(List<RoomInfo> roomList)
    {
        print(roomList.Count);
        print(containers.Count);
        if (containers.Count < roomList.Count)
            foreach (var item in roomList)
            {
                Container listbit = Instantiate(ListRoomBit, container.transform).GetComponent<Container>();
                listbit.transform.SetParent(container.transform);
                listbit.Name = item.Name;
                listbit.Map = "Cokret";
                listbit.IsOnPassProtected = item.IsOnPassProtected;
                listbit.setPassword(item.Password);
                listbit.CountPlayers = item.PlayerCount + "/" + item.MaxPlayers;
                listbit.id += 1;

                containers.Add(listbit); print("roomname= " + item.Name + " passwordprotected= " + item.IsOnPassProtected + " roompassword= " + item.Password);

            }
        if (containers.Count == roomList.Count)
        {
            for (int i = 0; i < containers.Count; i++)
            {
                containers[i].Name = roomList[i].Name;
                containers[i].Map = "Cokret";
                containers[i].IsOnPassProtected = roomList[i].IsOnPassProtected;
                containers[i].setPassword(roomList[i].Password);
                containers[i].CountPlayers = roomList[i].PlayerCount + "/" + roomList[i].MaxPlayers;
            }
        }
        if (containers.Count > roomList.Count)
        {
            for (int i = 0; i < containers.Count; i++)
            {
                if (containers[i].Name != roomList[i].Name)
                    Destroy(containers[i]);
            }
            //foreach (var item in containers)
            //{
            //    Destroy(item);
            //}
        }
    }

    private void Log(string message)
    {
        debugText.text += "\n";
        debugText.text += message;


    }
    private void Spawn()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPooint.position, Quaternion.identity);

        GameObject camera= PhotonNetwork.Instantiate(cameraPrefab.name, cameraSpawnPooint.position, cameraSpawnPooint.rotation);

        
        camera.GetComponent<CameraFollow>().target = player.transform;
        camera.GetComponent<CameraFollow>().CalcOffcet();

        camera.GetComponent<CameraFollow>().enabled = true;
       
    }
    private int PasswordEncryption(string value)
    {
        int password=0;

        foreach (char item in value)
        {
            password += (int)item;
        }

        return password;
    }

}
