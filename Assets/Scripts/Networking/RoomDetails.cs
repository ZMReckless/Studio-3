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

    public override void OnJoinedRoom()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;

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
}
