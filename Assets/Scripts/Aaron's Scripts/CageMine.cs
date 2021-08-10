using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CageMine : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Team1" || other.gameObject.tag == "Team2")
        {
            photonView.RPC("ActivateCage", RpcTarget.All, other);
        }
    }

    public void ActivateCage(GameObject player)
    {
        Vector3 cageSpawnPosition = new Vector3(
            player.transform.position.x,
            player.transform.position.y + 0.5f,
            player.transform.position.z
            );

        PhotonNetwork.InstantiateRoomObject("Cage", cageSpawnPosition, Quaternion.identity);
        PhotonNetwork.Destroy(gameObject);
    }
}
