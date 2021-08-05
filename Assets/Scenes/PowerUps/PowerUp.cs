using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for powerups

// variables may be added/removed/changed due to needs
public class PowerUp : MonoBehaviour
{
    public GameObject powerUpObject;

    // this method will be overridden by the inherited classes
    public virtual void PowerUpEffects()
    {

    }
}
