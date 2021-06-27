using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class ServerListItem : MonoBehaviour
{
    [SerializeField] TMP_Text serverNameText;
    [SerializeField] TMP_Text mapNameText;
    [SerializeField] TMP_Text playerCountText;

    public int playerCount;

    public RoomInfo info;

    private void Update()
    {
        playerCount = info.PlayerCount;
        playerCountText.text = playerCount.ToString() + "/4";
    }

    public void SetUp(RoomInfo _info)
    {
        info = _info;
        serverNameText.text = info.Name;
        mapNameText.text = "Town Centre";
    }

    public void OnClick()
    {
        if (info.PlayerCount < info.MaxPlayers)
        {
            Launcher.Instance.JoinRoom(info);
        }
        else
        {
            Debug.Log("Failed to join room");
        }
    }
}
