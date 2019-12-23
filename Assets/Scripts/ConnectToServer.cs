using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI debugtext;

    float timerConecteon=0;
    // Start is called before the first frame update
    void Start()
    {
        ConnectToPhoton();
    }
    
    public override void OnConnectedToMaster()
    {
        Log("Connected to master");
        
    }

    // Update is called once per frame
    void Update()
    {
        timerConecteon += Time.deltaTime;
        if (timerConecteon > 3 && !PhotonNetwork.IsConnected)
        {
            ConnectToPhoton(); timerConecteon = 0;
        }
    }
    void ConnectToPhoton()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1, 10000);
        Log("Player name set " + PhotonNetwork.NickName);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();

    }
    private void Log(string message)
    {
        debugtext.text += "\n";
        debugtext.text += message ;


    }
}
