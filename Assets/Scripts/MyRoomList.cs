using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoomList : MonoBehaviour, IPunObservable
{
    private List<Room> rooms= new List<Room>();

    public void AddRoom(Room room)
    {
       // foreach (var item in rooms)
       // {
            //if (room.Name!=item.Name)
                rooms.Add(room);
       // }
    }
    public Room[] GetRooms()
    {

        return rooms.ToArray();

    } public int GetRoomsCount()
    {

        return rooms.Count;

    }public void DeleteRoom(Room room)
    {
        rooms.Remove(room);
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rooms);
            print("Send rooms " + rooms);
        }
        else
        {
            rooms = (List<Room>)stream.ReceiveNext();
            print("Read rooms "+ rooms);
        }
    }
}
