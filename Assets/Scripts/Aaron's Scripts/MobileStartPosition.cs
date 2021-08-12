using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class MobileStartPosition : MonoBehaviourPunCallbacks
{
    private CinemachineVirtualCamera cinemachineVirtual;

    void Start()
    {
        cinemachineVirtual = GetComponent<CinemachineVirtualCamera>();

        int playerIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerPlatform"];

        switch (playerIndex)
        {
            case 0:
                cinemachineVirtual.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 5f;
                break;
            case 1:
                cinemachineVirtual.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 1f;
                break;
        }
    }
}
