using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float playerArmour;

    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerArmourText;

    private void Start()
    {
        if (playerHealth == 0) playerHealth = 100f;
        if (playerArmour == 0) playerArmour = 100f;
    }

    private void Update()
    {
        playerHealthText.text = "Health: " + playerHealth.ToString();
        playerArmourText.text = "Armour: " + playerArmour.ToString();
    }
}
