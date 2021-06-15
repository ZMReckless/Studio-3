using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// manages the coin/currency system
// need to combine this with the serialization sytem to store the players coinAmount
public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinAmountText; // reference the coin amount text in the shop
    
    public float coinAmount; // the amount of coin the individual player has

    void Update()
    {
        coinAmountText.text = coinAmount.ToString();
    }
}
