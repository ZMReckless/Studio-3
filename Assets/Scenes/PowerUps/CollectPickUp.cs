using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to collect pick up
public class CollectPickUp : MonoBehaviour
{
    public PlayerPowerUp playerPowerUp;

    // when player collides with the pick up
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == ("Player"))
        {
            Debug.Log("Collected PickUp");
            playerPowerUp = hit.gameObject.GetComponent<PlayerPowerUp>();
            playerPowerUp.GetComponent<PlayerPowerUp>().powerUp = gameObject.GetComponent<PickUp>().powerUp; // sets the available powerup
            Destroy(gameObject); // later this should teleport the object to the VR player
        }
    }
}
