using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class RoomMonitor : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI debugText;
    
    public Transform spawnPooint;
    public Transform cameraSpawnPooint;

    public GameObject playerPrefab;
    public Camera cameraPrefab;
    public MyRoomList roomList;
    public GameObject ListRoomBit;
    public GameObject Container;

    bool isConnected = false;
    float timer;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var roms in roomList)
        {
            print(roms.Name + " " + roms.MaxPlayers);
            
        }
        
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
        Log(newPlayer.NickName+" connected to room");
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    public override void OnConnectedToMaster()
    {
        isConnected = true;
        
    }

    public override void OnJoinedRoom()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=5)
        {
            UpdateListRoom();
            timer = 0;
        }
    }

    private void UpdateListRoom()
    {
        //GameObject listbit = Instantiate(ListRoomBit, Container.transform);
       // listbit.transform.SetParent(Container.transform);
        foreach (var item in roomList.GetRooms())
        {
            print(item.Name + " " + item.MaxPlayers);
            Log(item.Name + " " + item.MaxPlayers);
            if (Container.transform.childCount <= roomList.GetRoomsCount())
            {
                GameObject listbit = Instantiate(ListRoomBit, Container.transform);
                listbit.transform.SetParent(Container.transform);
            }
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
        //camera.GetComponent<CameraFollow>().enabled = true;
    }

   
}
