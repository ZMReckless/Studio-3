using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (photonView.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Debug.Log("Instantiated Player Controller");
        GameObject spawnPosition = GameObject.Find("SpawnPoint");
        PhotonNetwork.Instantiate("Player", spawnPosition.transform.position, spawnPosition.transform.rotation);
    }
}
