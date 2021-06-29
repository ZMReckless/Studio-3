using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR;

public class ServerListItem : MonoBehaviour
{
    [SerializeField] TMP_Text serverNameText;
    [SerializeField] TMP_Text mapNameText;
    [SerializeField] TMP_Text playerCountText;

    public int playerCount;

    public RoomInfo info;

    public int playersVR;
    public int playersMK;

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
        if (XRSettings.isDeviceActive)
        {
            if (playersVR < 2)
            {
                Launcher.Instance.JoinRoom(info);
                playersVR++;

                Debug.Log("Joined as VR player");
            }
        }
        else if (!XRSettings.isDeviceActive)
        {
            if (playersMK < 2)
            {
                Launcher.Instance.JoinRoom(info);
                playersMK++;

                Debug.Log("Joined as MK player");
            }
        }
        else
        {
            Debug.Log("Failed to join room");
        }
    }
}
