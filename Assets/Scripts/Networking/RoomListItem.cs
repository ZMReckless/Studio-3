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
    private TMP_Text playerCount;
    [SerializeField]
    public int maxVRPlayers, maxMKPlayers = 2;

    [SerializeField]
    private List<Image> VRImages;
    [SerializeField]
    private List<Image> MKImages;

    public RoomInfo RoomInfo { get; private set; }

    private void Update()
    {
        if ((int)RoomInfo.CustomProperties["VRPlayer"] == 0)
        {
            foreach (Image image in VRImages)
            {
                image.sprite = NetworkManager.Instance.VRSprites[1];
            }
        }
        else if ((int)RoomInfo.CustomProperties["VRPlayer"] == 1)
        {
            VRImages[0].sprite = NetworkManager.Instance.VRSprites[0];
            VRImages[1].sprite = NetworkManager.Instance.VRSprites[1];
        }
        else
        {
            foreach (Image image in VRImages)
            {
                image.sprite = NetworkManager.Instance.VRSprites[0];
            }
        }

        if ((int)RoomInfo.CustomProperties["MKPlayer"] == 0)
        {
            foreach (Image image in MKImages)
            {
                image.sprite = NetworkManager.Instance.MKSprites[1];
            }
        }
        else if ((int)RoomInfo.CustomProperties["MKPlayer"] == 1)
        {
            MKImages[0].sprite = NetworkManager.Instance.MKSprites[0];
            MKImages[1].sprite = NetworkManager.Instance.MKSprites[1];
        }
        else
        {
            foreach (Image image in MKImages)
            {
                image.sprite = NetworkManager.Instance.MKSprites[0];
            }
        }
    }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;

        roomName.text = roomInfo.Name;
        playerCount.text = roomInfo.PlayerCount.ToString() + "/" + roomInfo.MaxPlayers;
    }

    public void OnClick()
    {
        if (XRSettings.isDeviceActive)
        {
            if ((int)RoomInfo.CustomProperties["VRPlayer"] < maxVRPlayers)
            {
                NetworkManager.Instance.JoinRoom(RoomInfo);

                Debug.Log("Joining room as VR player");
            }
            else
            {
                Debug.Log("VR player slots full");
            }
        }
        else
        {
            if ((int)RoomInfo.CustomProperties["MKPlayer"] < maxMKPlayers)
            {
                NetworkManager.Instance.JoinRoom(RoomInfo);

                Debug.Log("Joining room as MK player");
            }
            else
            {
                Debug.Log((int)RoomInfo.CustomProperties["MKPlayer"]);
                Debug.Log("MK player slots full");
            }
        }
    }
}
