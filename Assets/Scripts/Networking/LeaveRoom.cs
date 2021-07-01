using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveRoom : MonoBehaviourPunCallbacks
{
    public void LeaveRoomLobby()
    {
        PhotonNetwork.LeaveRoom();
        OnlineConnection.Instance.fromRoomLobby = true;

        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("main lobby");

        Debug.Log("Left room");
    }
}
