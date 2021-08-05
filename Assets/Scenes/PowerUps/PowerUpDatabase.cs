using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDatabase : MonoBehaviour
{
    [HideInInspector]
    public static PowerUpDatabase Instance;

    public PowerUp[] powerUps;

    private void Awake()
    {
        Instance = this;
    }
}
