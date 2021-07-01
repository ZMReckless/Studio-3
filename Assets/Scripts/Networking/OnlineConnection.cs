using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class OnlineConnection : MonoBehaviourPunCallbacks
{
    public static OnlineConnection Instance;

    [SerializeField] string buildVersion = "0.1";

    [HideInInspector] public bool fromRoomLobby = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PhotonNetwork.GameVersion = buildVersion.ToString();
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Connecting online");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();

        Debug.Log("Connected to master");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogFormat("Disconnected to server for {0}", cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        if (!fromRoomLobby)
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000"); // sets the player name to a random name for now till player profiles are made
            Debug.Log(PhotonNetwork.NickName + " has joined the server");
            MenuManager.Instance.OpenMenu("main menu");
            fromRoomLobby = true;

            Debug.Log("Joined main lobby");
        }
    }
}
