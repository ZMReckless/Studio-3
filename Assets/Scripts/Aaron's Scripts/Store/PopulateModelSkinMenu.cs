using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// populates the model skin menu
public class PopulateModelSkinMenu : MonoBehaviour
{
    [Header("Scripts")]
    public SkinDatabase skinDatabase; // references the skin database

    [Header("GameObjects")]
    public GameObject itemSkinPrefab;
    public Transform contentGameObject;

    void Start()
    {
        for (int i = 0; i < skinDatabase.modelSkins.Length; i++)
        {
            GameObject thisShopItem;
            thisShopItem = Instantiate(itemSkinPrefab, contentGameObject);
            thisShopItem.GetComponent<ShopItemAllocator>().gameItem = skinDatabase.modelSkins[i];
        }
    }
}
