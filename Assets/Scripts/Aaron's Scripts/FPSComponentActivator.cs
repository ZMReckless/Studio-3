using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// script to activate controls for the specific fps player
public class FPSComponentActivator : MonoBehaviourPunCallbacks
{
    public FPSMovement fPSMovement;
    public GameObject playerCamera;

    void Start()
    {
        if (photonView.IsMine)
        {
            fPSMovement.enabled = true;
            playerCamera.SetActive(true);
        }
    }
}
