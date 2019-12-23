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
    public bool IsOnPassProtected;
    public string CountPlayers;
    private int Password;

    // Start is called before the first frame update
    void Awake()
    {
        if (!IsOnPassProtected)
            transform.GetChild(3).gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Name;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Map;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = CountPlayers;
    }
    public void JoinLobby()
    {
        if (PhotonNetwork.IsConnected)
            if (IsOnPassProtected)
            { if (PasswordEqals()) PhotonNetwork.JoinRoom(Name); }
            else
                PhotonNetwork.JoinRoom(Name);
        //PhotonNetwork.JoinRandomRoom();
    }
    private int PasswordToInt(string value)
    {
        int password = 0;

        foreach (char item in value)
        {
            password += (int)item;
        }

        return password;
    }
    private bool PasswordEqals()
    {
        if (Password == PasswordToInt(transform.GetChild(3).GetComponent<TMP_InputField>().text))
            return true;
        else
            return false;
    }
    public void setPassword(int value) { Password = value; }
    
}
