using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomDetails : MonoBehaviourPunCallbacks
{
    [Header("Texts")]
    [SerializeField]
    private TMP_Text roomName;
    [SerializeField]
    private TMP_Text team1FPSPlayer, team1MBPlayer, team2FPSPlayer, team2MBPlayer;

    [Header("Variables")]
    [SerializeField]
    private int roomPing = -1;

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

            NetworkManager.Instance.startGameButton.SetActive(true);

            //if (PhotonNetwork.PlayerList.Length == PhotonNetwork.CurrentRoom.MaxPlayers)
            //{
            //    NetworkManager.Instance.startGameButton.SetActive(true);
            //}
            //else
            //{
            //    NetworkManager.Instance.startGameButton.SetActive(false);
            //}
        }
    }

    public override void OnJoinedRoom()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;

        if (PhotonNetwork.IsMasterClient)
        {
            NetworkManager.Instance.startGameButton.SetActive(true);

            roomPing = (int)PhotonNetwork.CurrentRoom.CustomProperties["RoomPing"];

            if (Application.isMobilePlatform)
            {
                int newMBPlayerCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["MBPlayer"] + 1;

                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable()
                {
                    { "MBPlayer", newMBPlayerCount }
                });

                Hashtable newMBPlayer = new Hashtable();
                newMBPlayer.Add("PlayerPlatform", 0);
                PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);

                Debug.Log("Master client is a mobile player");
            }
            else
            {
                int newFPSPlayerCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["FPSPlayer"] + 1;

                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable()
                {
                    { "FPSPlayer", newFPSPlayerCount }
                });

                Hashtable newFPSPlayer = new Hashtable();
                newFPSPlayer.Add("PlayerPlatform", 2);
                PhotonNetwork.LocalPlayer.SetCustomProperties(newFPSPlayer);

                Debug.Log("Master client is pc player");
            }
        }
        else
        {
            if (Application.isMobilePlatform)
            {
                int newMBPlayerCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["MBPlayer"] + 1;

                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable()
                {
                    { "MBPlayer", newMBPlayerCount }
                });

                if (newMBPlayerCount == 1)
                {
                    Hashtable newMBPlayer = new Hashtable();
                    newMBPlayer.Add("PlayerPlatform", 0);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);

                    Debug.Log("New playe is team 1 mobile");

                }
                else
                {
                    Hashtable newMBPlayer = new Hashtable();
                    newMBPlayer.Add("PlayerPlatform", 1);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);
                    Debug.Log("New playe is team 2 mobile");

                }
            }
            else
            {
                int newFPSPlayerCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["FPSPlayer"] + 1;

                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable()
                {
                   { "FPSPlayer", newFPSPlayerCount }
                });

                if (newFPSPlayerCount == 1)
                {
                    Hashtable newMBPlayer = new Hashtable();
                    newMBPlayer.Add("PlayerPlatform", 2);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);
                    Debug.Log("New player is team 1 pc player");

                }
                else
                {
                    Hashtable newMBPlayer = new Hashtable();
                    newMBPlayer.Add("PlayerPlatform", 3);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);

                    Debug.Log("New player is team 2 pc player");

                }
            }
        }

        Debug.Log("Joined room");
    }

    public void OnLeaveButton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            NetworkManager.Instance.startGameButton.SetActive(false);
        }

        if (Application.isMobilePlatform)
        {
            int newValue = (int)PhotonNetwork.CurrentRoom.CustomProperties["MBPlayer"] - 1;

            PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() {
                { "MBPlayer", newValue }
            });
            Debug.Log("Mobile player has left the room");
            Debug.Log($"Current mobile players {newValue}");

        }
        else
        {
            int value = (int)PhotonNetwork.CurrentRoom.CustomProperties["FPSPlayer"];
            int newValue = value - 1;

            PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() {
                { "FPSPlayer", newValue }
            });
            Debug.Log("Pc player has left the room");
            Debug.Log($"Current mobile players {newValue}");
        }

        NetworkManager.Instance.LeaveRoomLobby();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);

        int playerIndex = (int)otherPlayer.CustomProperties["PlayerPlatform"];

        switch (playerIndex) 
        {
            case 0:
                team1MBPlayer.text = "Empty Slot";
                Debug.Log("team1MBPlayer has left the room");

                break;
            case 1:
                team2MBPlayer.text = "Empty Slot";
                Debug.Log("team2MBPlayer has left the room");

                break;
            case 2:
                team1FPSPlayer.text = "Empty Slot";
                Debug.Log("team1FPSPlayer has left the room");

                break;
            case 3:
                team2FPSPlayer.text = "Empty Slot";
                Debug.Log("team2FPSPlayer has left the room");

                break;
        }

        UpdatePlayers();
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);

        UpdatePlayers();
    }

    public void UpdatePlayers()
    {
        team1MBPlayer.text = "Empty Slot";
        team2MBPlayer.text = "Empty Slot";
        team1FPSPlayer.text = "Empty Slot";
        team2FPSPlayer.text = "Empty Slot";

        Player[] players = PhotonNetwork.PlayerList;

        foreach (Player player in players)
        {
            int playerIndex = (int)player.CustomProperties["PlayerPlatform"];

            switch (playerIndex)
            {
                case 0:
                    team1MBPlayer.text = player.NickName;
                    break;
                case 1:
                    team2MBPlayer.text = player.NickName;
                    break;
                case 2:
                    team1FPSPlayer.text = player.NickName;
                    break;
                case 3:
                    team2FPSPlayer.text = player.NickName;
                    break;
            }
        }
    }
}
