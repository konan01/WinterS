using ExitGames.Client.Photon;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour, IPunObservable
{
    PhotonView photonView;
    [SerializeField] static Weapon weapon;
    int damage;
    int health;
    float speed;
    float XP;
    int Lvl;

   [SerializeField] List<Int64> scores;

    Class @class;
    enum Class
    {
        IceSculptures,
        SnowDemoman,
        SnowStormtrooper
    }
    // Start is called before the first frame update
    void Awake()
    {
        scores = new List<Int64>();
        photonView = GetComponent<PhotonView>();

        weapon = new Weapon(-1, 0, 1, 0);

        PhotonPeer.RegisterType(typeof(List<Int64>), 0, SerializeListInt64, DeserializeListInt64);
        PhotonPeer.RegisterType(typeof(Int64), 1, SerializeInt64, DeserializeInt64);
        //print((Int64)DeserializeInt64(SerializeInt64(ScoreManager.GetScore())));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDamage(int value)
    {
        damage = value;

    }
    public int GetDamage()
    {
        return damage;

    }
    public void SetHealth(int value)
    {
        health = value;

    }
    public int GetHealth()
    {
        return health;

    }
    public void SetSpeed(float value)
    {
        speed = value;

    }
    public float GetSpeed()
    {
        return speed;

    }
    public void SetXP(float value)
    {
        XP = value;

    }
    public float GetXP()
    {
        return XP;

    }
    public void SetLVL(int value)
    {
        Lvl = value;

    }
    public int GetLVL()
    {
        return Lvl;

    }

    public void SetWeapon(Weapon wea)
    {
        weapon = wea;

    }
    public Weapon GetWeapon()
    {
        return weapon;

    }
    public int GetWeaponId()
    {
        return weapon.IDweapon;

    }
    public static int GetMyltiplaer()
    {
        if (weapon != null)
            return weapon.myltiplaer;
        else
        {
            return 1;
        }

    }
    public int GetWeaponLevel()
    {
        if (weapon != null)
            return weapon.weaponLevel;
        else
        {
            return 0;
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
        if (stream.IsWriting)
        {
            stream.SendNext(ScoreManager.GetScore());
            print("send");
        }
        else
        {
            scores.Add((Int64)stream.ReceiveNext());
            print("receive");
        }
    }
    public static object DeserializeListInt64(byte[] data)
    {
        List<Int64> result = new List<Int64>();
        for (int i = 0; i < data.Length; i += 8)
            result.Add(BitConverter.ToInt64(data, i));
        return result;
    }
    public static byte[] SerializeListInt64(object obj)
    {
        List<Int64> list = (List<Int64>)obj;
        byte[] result= new byte[list.Count*8];
        for (int j = 0, i = 0; i < list.Count; i++,j+=8)
        {
            BitConverter.GetBytes(list[i]).CopyTo(result, j);
        }
        
        return result;
    }public static object DeserializeInt64(byte[] data)
    {
        Int64 result=0;
        result=BitConverter.ToInt64(data, 0);
        return result;
    }
    public static byte[] SerializeInt64(object obj)
    {
        Int64 list = (Int64)obj;
        byte[] result= new byte[8];
        BitConverter.GetBytes(list).CopyTo(result, 0);
        return result;
    }
}
