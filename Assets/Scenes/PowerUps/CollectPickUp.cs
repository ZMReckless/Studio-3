using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to collect pick up
public class CollectPickUp : MonoBehaviour
{
    public PlayerPowerUp playerPowerUp;
    public GameObject pickUpItem;

    // when player collides with the pick up
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Team1"))
        {
            //playerPowerUp = other.gameObject.GetComponent<PlayerPowerUp>();

            //if (playerPowerUp.powerUp == null)
            //{
            //    playerPowerUp.powerUp = transform.GetComponentInParent<PickUp>().powerUp; // sets the available powerup
            //    Debug.Log("Collected PickUp");
            //    Destroy(pickUpItem);
            //}
            //else
            //{
            //    Debug.Log("Player already has a powerup");
            //}
        }
    }
}
