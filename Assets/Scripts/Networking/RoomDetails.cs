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

            if (PhotonNetwork.PlayerList.Length == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                NetworkManager.Instance.startGameButton.SetActive(true);
            }
            else
            {
                NetworkManager.Instance.startGameButton.SetActive(false);
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
            }
        }
        else
        {
            Player[] players = PhotonNetwork.PlayerList;

            foreach (Player player in players)
            {
                if (Application.isMobilePlatform)
                {
                    int newMBPlayerCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["MBPlayer"] + 1;

                    PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable()
                    {
                        { "MBPlayer", newMBPlayerCount }
                    });

                    if ((int)player.CustomProperties["PlayerPlatform"] == 0)
                    {
                        Hashtable newMBPlayer = new Hashtable();
                        newMBPlayer.Add("PlayerPlatform", 1);
                        PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);
                    }
                    else
                    {
                        Hashtable newMBPlayer = new Hashtable();
                        newMBPlayer.Add("PlayerPlatform", 0);
                        PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);
                    }
                }
                else
                {
                    int newFPSPlayerCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["FPSPlayer"] + 1;

                    PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable()
                    {
                       { "FPSPlayer", newFPSPlayerCount }
                    });

                    if ((int)player.CustomProperties["PlayerPlatform"] == 2)
                    {
                        Hashtable newMBPlayer = new Hashtable();
                        newMBPlayer.Add("PlayerPlatform", 3);
                        PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);
                    }
                    else
                    {
                        Hashtable newMBPlayer = new Hashtable();
                        newMBPlayer.Add("PlayerPlatform", 2);
                        PhotonNetwork.LocalPlayer.SetCustomProperties(newMBPlayer);
                    }
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
        }
        else
        {
            int value = (int)PhotonNetwork.CurrentRoom.CustomProperties["FPSPlayer"];
            int newValue = value - 1;

            PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() {
                { "FPSPlayer", newValue }
            });
        }

        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["MBPlayer"]);
        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["FPSPlayer"]);

        NetworkManager.Instance.LeaveRoomLobby();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);

        if ((int)otherPlayer.CustomProperties["PlayerPlatform"] == 0)
        {
            team1MBPlayer.text = "Team 1 MB Player";
        }
        else if ((int)otherPlayer.CustomProperties["PlayerPlatform"] == 1)
        {
            team2MBPlayer.text = "Team 2 MB Player";
        }
        else if ((int)otherPlayer.CustomProperties["PlayerPlatform"] == 2)
        {
            team1FPSPlayer.text = "Team 1 FPS Player";
        }
        else
        {
            team2FPSPlayer.text = "Team 2 FPS Player";
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);

        Debug.Log((int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerPlatform"]);

        Player[] players = PhotonNetwork.PlayerList;

        foreach (Player player in players)
        {
            if ((int)player.CustomProperties["PlayerPlatform"] == 0)
            {
                team1MBPlayer.text = player.NickName;
            }
            else if ((int)player.CustomProperties["PlayerPlatform"] == 1)
            {
                team2MBPlayer.text = player.NickName;
            }
            else if ((int)player.CustomProperties["PlayerPlatform"] == 2)
            {
                team1FPSPlayer.text = player.NickName;
            }
            else
            {
                team2FPSPlayer.text = player.NickName;
            }
        }
        Debug.Log((int)PhotonNetwork.CurrentRoom.CustomProperties["FPSPlayer"]);
    }
}
