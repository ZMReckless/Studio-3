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

    public void SetUp(RoomInfo _info)
    {
        info = _info;
        serverNameText.text = info.Name;
        mapNameText.text = "Town Square";
        playerCountText.text = playerCount + " /4";
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
