using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// gets the current selected skin scriptable object and displays it on the detailed skin UI
public class DisplaySkinDetails : MonoBehaviour
{
    public ItemSkin skinItem;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemCost;

    public Image itemImage;

    public GameObject purchaseButton;
    public GameObject equiptButton;
    // displays item details
    public void DisplayDetails()
    {
        gameObject.SetActive(true);
        skinItem = EventSystem.current.currentSelectedGameObject.GetComponentInParent<ShopItemAllocator>().gameItem; // references the current skin selected
        // allocates details to the displays
        itemName.text = skinItem.skinName;
        itemType.text = skinItem.skinType.ToString();
        itemDescription.text = skinItem.skinDescription;
        itemCost.text = skinItem.skinCost.ToString();

        itemImage.sprite = skinItem.skinImage;
        // changes the purchase/equipt button depending if the item is unlocked/purchased
        if (skinItem.unlocked == true)
        {
            purchaseButton.SetActive(false);
            equiptButton.SetActive(true);
        }
        else if(skinItem.unlocked == false)
        {
            purchaseButton.SetActive(true);
            equiptButton.SetActive(false);
        }
    }
}
