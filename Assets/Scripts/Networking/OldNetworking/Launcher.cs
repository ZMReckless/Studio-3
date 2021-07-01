//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using Photon.Realtime;
//using TMPro;
//using UnityEngine.XR;
//using UnityEngine.EventSystems;

//public class Launcher : MonoBehaviourPunCallbacks
//{
//    public static Launcher Instance;

//    [Header("Game Version")]
//    [SerializeField] string gameVersion;

//    [Header("Room")]
//    [SerializeField] TMP_InputField roomNameInputField;
//    [SerializeField] TMP_Text roomNameText;

//    [Header("Server")]
//    [SerializeField] GameObject startGameButton;
//    [SerializeField] GameObject serverListPrefab;
//    [SerializeField] Transform serverListContent;

//    private bool firstStart;


//    private void Awake()
//    {
//        Instance = this;
//        firstStart = true;
//    }

//    void Start()
//    {
//        PhotonNetwork.GameVersion = gameVersion.ToString(); // set the game version, if build's game version is not this, will not connect to server
//        PhotonNetwork.ConnectUsingSettings();

//        Debug.Log("Connecting to server");
//    }

//    public override void OnConnectedToMaster()
//    {
//        PhotonNetwork.JoinLobby();
//        PhotonNetwork.AutomaticallySyncScene = true;

//        Debug.Log("Connected to master server");
//    }

//    public override void OnJoinedLobby()
//    {
//        if (firstStart)
//        {
//            if (!XRSettings.isDeviceActive)
//            {
//                Debug.Log("There is no VR headset detected");
//            }
//            else
//            {
//                Debug.Log(XRSettings.loadedDeviceName.ToString());
//            }

//            MenuManager.Instance.OpenMenu("main menu"); // activates the main menu canvas when connected to server
//            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000"); // sets the player name to a random name for now till player profiles are made
//            Debug.Log(PhotonNetwork.NickName + " has joined the server");
//            firstStart = false;
//        }
//    }

//    public override void OnDisconnected(DisconnectCause cause)
//    {
//        Debug.LogFormat("Disconnected to server for {0}", cause.ToString());
//    }

//    public void CreateRoom()
//    {
//        // stops method if the setting of the room name is empty
//        if (string.IsNullOrEmpty(roomNameInputField.text))
//        {
//            return;
//        }

//        PhotonNetwork.CreateRoom(roomNameInputField.text, new RoomOptions { MaxPlayers = 4 });
//        MenuManager.Instance.OpenMenu("loading");
//    }

//    public override void OnCreateRoomFailed(short returnCode, string message)
//    {
//        Debug.Log("Failed to create room");
//        //errorText.text = "Room creation failed: " + message;
//        //MenuManager.Instance.OpenMenu("error");
//    }

//    public void JoinRoom(RoomInfo info)
//    {
//        PhotonNetwork.JoinRoom(info.Name);
//        MenuManager.Instance.OpenMenu("loading");
//        Debug.Log("Joined room");
//    }

//    public override void OnJoinedRoom()
//    {
//        MenuManager.Instance.OpenMenu("server menu");
//        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

//        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
//    }

//    public void LeaveRoom()
//    {
//        PhotonNetwork.LeaveRoom();
//        MenuManager.Instance.OpenMenu("loading");
//    }

//    public override void OnMasterClientSwitched(Player newMasterClient)
//    {
//        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
//    }

//    public override void OnLeftRoom()
//    {
//        MenuManager.Instance.OpenMenu("main lobby");
//        Debug.Log("Left room");
//    }

//    public override void OnRoomListUpdate(List<RoomInfo> serverList)
//    {
//        foreach (Transform transfrom in serverListContent)
//        {
//            Destroy(transfrom.gameObject);
//        }

//        for (int i = 0; i < serverList.Count; i++)
//        {
//            if (serverList[i].RemovedFromList)
//            {
//                continue;
//            }

//            Instantiate(serverListPrefab, serverListContent).GetComponent<RoomListItem>().SetUp(serverList[i]);
//        }

//        Debug.Log("List updated");
//    }

//    public void StartGame()
//    {
//        PhotonNetwork.LoadLevel(1);
//        Debug.Log("Started game");
//    }
//}
