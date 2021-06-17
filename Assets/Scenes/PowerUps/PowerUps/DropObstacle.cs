using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObstacle : PowerUp
{
    public GameObject obstacle;
    private GameObject player;

    private Vector3 droppedObstacleLocation;

    private float dropRadius = 5f;

    public override void PowerUpEffects()
    {
        player = GameObject.Find("Player");

        float x, y, z;

        x = Random.Range(player.transform.position.x - dropRadius, player.transform.position.x + dropRadius);
        y = Random.Range(player.transform.position.y, player.transform.position.y + dropRadius);
        z = Random.Range(player.transform.position.z - dropRadius, player.transform.position.z + dropRadius);

        droppedObstacleLocation = new Vector3(x, y, z);

        Instantiate(obstacle, droppedObstacleLocation, Quaternion.identity);
    }
}
