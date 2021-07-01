using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class RoomListItem : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;
    [SerializeField]
    private TMP_Text playerCount;
    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;

        roomName.text = roomInfo.Name;
        playerCount.text = roomInfo.PlayerCount.ToString() + "/" + roomInfo.MaxPlayers;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room menu");

        Debug.Log("Joined room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogFormat("Failed to connect to room {0}", message);
    }
}
