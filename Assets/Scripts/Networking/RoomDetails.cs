using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.XR;

public class RoomDetails : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;

    private void Update()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }
}
