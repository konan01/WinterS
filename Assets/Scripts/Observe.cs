using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Observe : MonoBehaviour
{
    public GameObject cameraSelf;
    PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {

        cameraSelf = GameObject.FindGameObjectWithTag("GameCamera");
        photonView = cameraSelf.GetComponent<PhotonView>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Obs()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1 && photonView.IsMine)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            cameraSelf.GetComponent<CameraFollow>().target = players[Random.Range(0, 2)].transform;
            print("Observe for " + players[0]);
        }
    }
}
