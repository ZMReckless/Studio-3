using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : PowerUp
{
    public override void PowerUpEffects()
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().playerHealth += 50f;
    }
}
