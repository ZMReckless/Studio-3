using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.XR;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance;

    [Header("Game Version")]
    [SerializeField] string gameVersion;

    [Header("Room")]
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text roomNameText;

    [Header("Server")]
    [SerializeField] GameObject startGameButton;
    public List<Sprite> VRSprites;
    public List<Sprite> MKSprites;

    [HideInInspector] public bool fromRoomLobby = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion.ToString();
        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000"); // sets the player name to a random name for now till player profiles are made
        Debug.Log(PhotonNetwork.NickName + " has joined the server");

        Debug.Log("Connecting online");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        ConnectToLobby();

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
            MenuManager.Instance.OpenMenu("main menu");
            fromRoomLobby = true;
        }

        Debug.Log("Joined main lobby");
    }

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
                { "MKPlayer", 0 }, { "VRPlayer", 0 }
            };
        }
        else
        {
            roomOptions.CustomRoomProperties = new Hashtable()
            {
                { "MKPlayer", 0 }, { "VRPlayer", 0 }
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

    public void JoinRoom(RoomInfo roomInfo)
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
        MenuManager.Instance.OpenMenu("room menu");

        Debug.Log("Joining room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogFormat("Failed to connect to room {0}", message);
    }

    public void LeaveRoomLobby()
    {
        if (XRSettings.isDeviceActive)
        {
            int value = (int)PhotonNetwork.CurrentRoom.CustomProperties["VRPlayer"];
            int newValue = value - 1;

            Hashtable setValue = new Hashtable();
            setValue.Add("VRPlayer", newValue);

            Hashtable expectedValue = new Hashtable();
            setValue.Add("VRPlayer", value);

            PhotonNetwork.CurrentRoom.SetCustomProperties(setValue, expectedValue);
        }
        else
        {
            int value = (int)PhotonNetwork.CurrentRoom.CustomProperties["MKPlayer"];
            int newValue = value - 1;

            PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() {
                { "MKPlayer", newValue }
            });
        }

        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["VRPlayer"]);
        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["MKPlayer"]);

        PhotonNetwork.LeaveRoom();
        fromRoomLobby = true;

        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("main lobby");
        ConnectToLobby();

        Debug.Log("Left room");
    }

    public void ConnectToLobby()
    {
        PhotonNetwork.JoinLobby();
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);

        Debug.Log("Started game");
    }
}
