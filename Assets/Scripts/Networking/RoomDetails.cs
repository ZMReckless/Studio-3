using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class RoomDetails : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;

    void Start()
    {

    }

    public override void OnJoinedRoom()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }
}
