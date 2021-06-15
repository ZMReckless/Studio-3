using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code that confirms the purchases
public class ConfirmPurchase : MonoBehaviour
{
    public DisplaySkinDetails displaySkinDetails; // reference the current selected skin details
    public CoinCostDisplayer coinCostDisplayer; // reference the current coin cost details
    public CoinManager coinManager; // references the coin manager

    public GameObject displaySkinDetailsObject; // reference to the parent object that has the detailed skin display
    public GameObject purchaseCoinMenuObject; // references to the object that has the coin cost
    public GameObject purchaseVerificationObject; // references to the parent object of the purchase verification object
    public GameObject noCoinText; // references the text that displays the player has not enough coins
    public GameObject purchaseButton; // references the purchase button on the purchase verification
    public GameObject equiptButton; // references the equipt button on the displayed details UI

    // on button that confirms the final purchase
    public void AttemptPurchase()
    {
        if (displaySkinDetailsObject.activeSelf) // when displaying the skin details UI
        {
            // determines if the player has enough coins to purchase skin
            if (displaySkinDetails.skinItem.skinCost <= coinManager.coinAmount) // player has enough coin
            {
                coinManager.coinAmount = coinManager.coinAmount - displaySkinDetails.skinItem.skinCost; // deducts player coins from wallet
                displaySkinDetails.skinItem.unlocked = true; // unlocks the skin for allowing equiptment
                purchaseButton.SetActive(false);
                equiptButton.SetActive(true);
                purchaseVerificationObject.SetActive(false);
                Debug.Log("Bought Skin");
            }
            else if (displaySkinDetails.skinItem.skinCost > coinManager.coinAmount) // player doesn't have enough coin
            {
                noCoinText.SetActive(true);
            }
        }
        else if (purchaseCoinMenuObject.activeSelf) // when displaying the purchase coin UI
        {
            coinManager.coinAmount = coinManager.coinAmount + coinCostDisplayer.coinCost.coinAmount; // adds coins to player wallet
            purchaseVerificationObject.SetActive(false);
            Debug.Log("Coin Purchased");
        }
    }

    public void DisableWarning()
    {
        noCoinText.SetActive(false);
    }
}
