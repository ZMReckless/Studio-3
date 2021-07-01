using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

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
        roomOptions.EmptyRoomTtl = 0;

        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
        MenuManager.Instance.OpenMenu("loading");

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
