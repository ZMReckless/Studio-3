using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

// finds and references the selected coin purchase information
public class CoinCostDisplayer : MonoBehaviour
{
    public CoinCostItem coinCost;
    // add this method to the button that activates the confirm purchase UI
    public void DisplayDetails()
    {
        coinCost = EventSystem.current.currentSelectedGameObject.GetComponentInParent<DisplayCoinCostDetails>().coinCost; // references the selected coin purchase from a button pressed
    }
}
