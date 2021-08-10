using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// script to store the current power up and activate it's effects
// should be attached to the mobile player
public class PlayerPowerUp : MonoBehaviour
{
    public PowerUp powerUp; // reference the current power up

    // method called when powerup button is pressed
    // should be on the button to activate the powerup
    public void ActivatePowerUp()
    {
        if (powerUp != null)
        {
            powerUp.PowerUpEffects(); // calls the powerups effects
            powerUp = null; // removes the powerup from availability

            Debug.Log("Activated power up");
        }
        else
        {
            Debug.Log("No power up");
        }
    }
}
