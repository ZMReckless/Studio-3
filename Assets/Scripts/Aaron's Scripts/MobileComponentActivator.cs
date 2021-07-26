using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// script to activate controls for the specific mobile player
public class MobileComponentActivator : MonoBehaviourPunCallbacks
{
    public GameObject mobileCamera;

    void Start()
    {
        if (photonView.IsMine)
        {
            mobileCamera.SetActive(true);
        }
    }
}
