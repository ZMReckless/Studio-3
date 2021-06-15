using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// populates the gun skin menu
public class PopulateGunSkinsMenu : MonoBehaviour
{
    [Header("Scripts")]
    public SkinDatabase skinDatabase; // references the skin database

    [Header("GameObjects")]
    public GameObject itemSkinPrefab;
    public Transform contentGameObject;

    void Start()
    {
        for (int i = 0; i < skinDatabase.gunSkins.Length; i++)
        {
            GameObject thisShopItem;
            thisShopItem =  Instantiate(itemSkinPrefab, contentGameObject);
            thisShopItem.GetComponent<ShopItemAllocator>().gameItem = skinDatabase.gunSkins[i];
        }
    }
}
