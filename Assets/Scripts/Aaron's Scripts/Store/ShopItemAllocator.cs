using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// fills the details of the instantiated store skin item
public class ShopItemAllocator : MonoBehaviour
{
    public ItemSkin gameItem;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemCost;

    public Image itemBackground;
    public Image itemImage;

    public void Start()
    {
        itemName.text = gameItem.skinName;
        itemType.text = gameItem.skinType.ToString();

        if (gameItem.unlocked == true)
        {
            itemCost.text = "Unlocked";
        }
        else if (gameItem.unlocked == false)
        {
            itemCost.text = gameItem.skinCost.ToString();
        }

        itemBackground.sprite = gameItem.skinRarityBackground;
        itemImage.sprite = gameItem.skinImage;
    }
}
