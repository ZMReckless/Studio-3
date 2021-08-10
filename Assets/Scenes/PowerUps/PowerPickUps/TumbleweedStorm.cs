using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedStorm : PowerUp
{
    public override void PowerUpEffects()
    {
        GameManager.Instance.ActivateStorm();
    }
}
