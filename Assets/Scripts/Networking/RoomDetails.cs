using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.XR;

public class RoomDetails : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;
    
    [SerializeField]
    private int roomPing;

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.GetPing() != roomPing)
            {
                roomPing = PhotonNetwork.GetPing();

                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() {
                    { "RoomPing", roomPing }
                });
            }
        }
    }

    public override void OnJoinedRoom()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;

        if (PhotonNetwork.IsMasterClient)
        {
            NetworkManager.Instance.startGameButton.SetActive(true);

            roomPing = (int)PhotonNetwork.CurrentRoom.CustomProperties["RoomPing"];
        }

        if (XRSettings.isDeviceActive)
        {
            int value = (int)PhotonNetwork.CurrentRoom.CustomProperties["VRPlayer"];
            int newValue = value + 1;

            Hashtable setValue = new Hashtable();
            setValue.Add("VRPlayer", newValue);

            Hashtable expectedValue = new Hashtable();
            setValue.Add("VRPlayer", value);

            PhotonNetwork.CurrentRoom.SetCustomProperties(setValue, expectedValue);
        }
        else
        {
            int value = (int)PhotonNetwork.CurrentRoom.CustomProperties["MKPlayer"];
            int newValue = value + 1;

            PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() {
                { "MKPlayer", newValue } 
            });
        }

        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["VRPlayer"]);
        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["MKPlayer"]);
        Debug.Log("Joined room");
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            NetworkManager.Instance.startGameButton.SetActive(true);
            roomPing = (int)PhotonNetwork.CurrentRoom.CustomProperties["RoomPing"];
        }
    }
}
