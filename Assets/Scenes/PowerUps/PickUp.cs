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

    public Image image;
    private Sprite sprite; // reference to the pickup material

    private void Start()
    {
        powerUpDatabase = transform.parent.GetComponentInParent<PickUpSpawner>().powerUpDatabase;
        powerUp = powerUpDatabase.powerUps[Random.Range(0, powerUpDatabase.powerUps.Length)]; // chooses a random powerup
        sprite = powerUp.sprite; // retrieves the sprite information
        image.sprite = sprite; // sets the pickup material to the pickup
    }

    private void Update()
    {
        //image.transform.LookAt(GameObject.Find("PlayerCam").transform);
    }
}
