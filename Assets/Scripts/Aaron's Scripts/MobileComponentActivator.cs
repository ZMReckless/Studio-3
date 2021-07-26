using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// script to activate controls for the specific mobile player
public class MobileComponentActivator : MonoBehaviourPunCallbacks
{
    public GameObject[] activateComponents;

    void Start()
    {
        if (photonView.IsMine)
        {
            foreach (GameObject component in activateComponents)
            {
                component.SetActive(true);
            }
        }
    }
}
