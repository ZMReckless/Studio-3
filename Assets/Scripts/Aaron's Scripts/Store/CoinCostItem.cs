using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates the scriptable object
[CreateAssetMenu(fileName = "New Coin Purchase Item", menuName = "Store/Coin Purchase Item")]
public class CoinCostItem : ScriptableObject
{
    public float coinAmount; // amount of how many coins will be added
    public float coinDollarCost; // cost of the coin cost
}
