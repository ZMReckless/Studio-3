using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR;

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

    public void OnClick()
    {
        NetworkManager.Instance.JoinRoom(RoomInfo);
    }
}
