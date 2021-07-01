using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.XR;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;

    public void CreateNewRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text)
            || !PhotonNetwork.IsConnected)
        {
            return;
        }

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;

        if (XRSettings.isDeviceActive)
        {
            roomOptions.CustomRoomProperties = new Hashtable()
            {
                { "MKPlayer", 0 }, { "VRPlayer", 1 }
            };
        }
        else
        {
            roomOptions.CustomRoomProperties = new Hashtable()
            {
                { "MKPlayer", 1 }, { "VRPlayer", 0 }
            };
        }
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "MKPlayer", "VRPlayer" };

        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
        MenuManager.Instance.OpenMenu("loading");

        Debug.Log(roomOptions.CustomRoomProperties["MKPlayer"].ToString());
        Debug.Log(roomOptions.CustomRoomProperties["VRPlayer"].ToString());
        Debug.Log("Created room");
    }

    public override void OnCreatedRoom()
    {
        MenuManager.Instance.OpenMenu("room menu");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(returnCode + " " + message);
    }
}
