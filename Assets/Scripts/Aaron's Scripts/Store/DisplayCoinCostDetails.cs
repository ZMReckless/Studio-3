using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// displays the purchase details option
public class DisplayCoinCostDetails : MonoBehaviour
{
    public CoinCostItem coinCost;
    public TextMeshProUGUI coinAmount;
    public TextMeshProUGUI coinCostAmount;

    public void Start()
    {
        coinAmount.text = coinCost.coinAmount.ToString(); // displays how many coins will be added
        coinCostAmount.text = "$" + coinCost.coinDollarCost.ToString() + ".00"; // displays how much the coins will cost
    }
}
