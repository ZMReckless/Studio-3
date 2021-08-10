using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// script to collect pick up
public class CollectPickUp : MonoBehaviourPunCallbacks
{
    public PlayerPowerUp playerPowerUp;
    public GameObject pickUpItem;

    // when player collides with the pick up
    private void OnTriggerEnter(Collider other)
    {
        photonView.RPC("Collection", RpcTarget.AllViaServer, other);
    }

    public void Collection(GameObject player)
    {
        if (player.gameObject.tag == "Team1") // if team 1 collected the pick up
        {
            playerPowerUp = GameManager.Instance.team1MBPlayer.GetComponent<PlayerPowerUp>();
            playerPowerUp.powerUp = GetComponent<PickUp>().powerUp;
        }
        else if (player.gameObject.tag == "Team2") // if team 2 collected the pick up
        {
            playerPowerUp = GameManager.Instance.team2MBPlayer.GetComponent<PlayerPowerUp>();
            playerPowerUp.powerUp = GetComponent<PickUp>().powerUp;
        }

        PhotonNetwork.Destroy(gameObject.transform.parent.gameObject); // destroys the pick up after collection
    }
}
