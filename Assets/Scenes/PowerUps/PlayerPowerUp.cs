using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// script to store the current power up and activate it's effects
// should be attached to the VR player
public class PlayerPowerUp : MonoBehaviour
{
    public PowerUp powerUp; // reference the current power up

    private void Update()
    {
        if (powerUp != null)
        {
            if (Input.GetMouseButton(0))
            {
                powerUp.PowerUpEffects(); // calls the powerups effects
                powerUp = null; // removes the powerup from availability
            }
        }

        // for testing to reload the scene
        //if (Input.GetMouseButtonDown(1))
        //{
        //    SceneManager.LoadScene("PowerUp");
        //}
    }
}
