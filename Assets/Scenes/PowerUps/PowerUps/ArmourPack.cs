using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPack : PowerUp
{
    public override void PowerUpEffects()
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().playerArmour += 50f;
    }
}
