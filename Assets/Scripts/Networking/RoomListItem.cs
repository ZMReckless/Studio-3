using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;
    [SerializeField]
    private TMP_Text mapName;
    [SerializeField]
    private TMP_Text playerCount;
    [SerializeField]
    public int maxMBPlayers, maxFPSPlayers = 2;

    [SerializeField]
    private List<Image> MBImages;
    [SerializeField]
    private List<Image> FPSImages;
    [SerializeField]
    private Image pingImage;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        
        roomName.text = roomInfo.Name;
        mapName.text = "Town Square";
        playerCount.text = roomInfo.PlayerCount.ToString() + "/" + roomInfo.MaxPlayers;
    }

    public void OnClick()
    {
        if (Application.isMobilePlatform)
        {
            if ((int)RoomInfo.CustomProperties["MBPlayer"] < maxMBPlayers)
            {
                NetworkManager.Instance.JoinRoom(RoomInfo);

                Debug.Log("Joining room as mobile player");
            }
            else
            {
                Debug.Log("Mobile player slots full");
            }
        }
        else
        {
            if ((int)RoomInfo.CustomProperties["FPSPlayer"] < maxFPSPlayers)
            {
                NetworkManager.Instance.JoinRoom(RoomInfo);

                Debug.Log("Joining room as FPS player");
            }
            else
            {
                Debug.Log("FPS player slots full");
            }
        }
    }

    public void ChangeRoomIcons()
    {
        if ((int)RoomInfo.CustomProperties["MBPlayer"] == 0)
        {
            foreach (Image image in MBImages)
            {
                image.sprite = NetworkManager.Instance.MBSprites[1];
            }
        }
        else if ((int)RoomInfo.CustomProperties["MBPlayer"] == 1)
        {
            MBImages[0].sprite = NetworkManager.Instance.MBSprites[0];
            MBImages[1].sprite = NetworkManager.Instance.MBSprites[1];
        }
        else
        {
            foreach (Image image in MBImages)
            {
                image.sprite = NetworkManager.Instance.MBSprites[0];
            }
        }

        if ((int)RoomInfo.CustomProperties["FPSPlayer"] == 0)
        {
            foreach (Image image in FPSImages)
            {
                image.sprite = NetworkManager.Instance.FPSSprites[1];
            }
        }
        else if ((int)RoomInfo.CustomProperties["FPSPlayer"] == 1)
        {
            FPSImages[0].sprite = NetworkManager.Instance.FPSSprites[0];
            FPSImages[1].sprite = NetworkManager.Instance.FPSSprites[1];
        }
        else
        {
            foreach (Image image in FPSImages)
            {
                image.sprite = NetworkManager.Instance.FPSSprites[0];
            }
        }

        int roomPing = (int)RoomInfo.CustomProperties["RoomPing"];

        if (roomPing <= 25)
        {
            pingImage.sprite = NetworkManager.Instance.pingSprites[0];
        }
        else if (roomPing > 25 && roomPing <= 50)
        {
            pingImage.sprite = NetworkManager.Instance.pingSprites[1];
        }
        else if (roomPing > 50 && roomPing <= 75)
        {
            pingImage.sprite = NetworkManager.Instance.pingSprites[2];
        }
        else
        {
            pingImage.sprite = NetworkManager.Instance.pingSprites[3];
        }
    }
}
