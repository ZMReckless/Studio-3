using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// displays the cost on the confirm purchase UI
public class DisplayCost : MonoBehaviour
{
    public DisplaySkinDetails displaySkinDetails; // references current skin details
    public CoinCostDisplayer coinCostDisplayer; // references current coin purchase details

    public GameObject purchaseCoinMenu;
    public GameObject detailedSkinAreaObject;
    public TextMeshProUGUI coinCostText;
    // on buttons that activates the confirm purchase UI from skin items
    public void DisplaySkinCost()
    {
        coinCostText.text = displaySkinDetails.skinItem.skinCost.ToString();
    }
    // on buttons that activates the confirm purchase UI from coin purchases
    public void DisplayCoinCost()
    {
        coinCostText.text = coinCostDisplayer.coinCost.coinAmount.ToString();
    }
}
