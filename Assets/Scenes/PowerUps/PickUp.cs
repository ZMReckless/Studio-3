using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// script for the in world pickup
// chooses a random powerup from the powerup database
// populates the powerup information to the pickup

// variables may be added/removed/changed due to needs
public class PickUp : MonoBehaviour
{
    private PowerUpDatabase powerUpDatabase; // reference the gameobject with the powerup array
    public PowerUp powerUp; // references the randomly chosen powerup

    private void Start()
    {
        powerUpDatabase = PowerUpDatabase.Instance;
        powerUp = powerUpDatabase.powerUps[Random.Range(0, powerUpDatabase.powerUps.Length)]; // chooses a random powerup

        GameObject pickUp = Instantiate(powerUp.powerUpObject, transform.position, Quaternion.identity);
        pickUp.transform.SetParent(gameObject.transform);
    }
}
