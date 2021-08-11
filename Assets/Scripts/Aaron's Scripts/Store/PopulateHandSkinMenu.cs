//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// populates the hand skin menu
//public class PopulateHandSkinMenu : MonoBehaviour
//{
//    [Header("Scripts")]
//    public SkinDatabase skinDatabase; // references the skin database

//    [Header("GameObjects")]
//    public GameObject itemSkinPrefab;
//    public Transform contentGameObject;

//    void Start()
//    {
//        for (int i = 0; i < skinDatabase.handSkins.Length; i++)
//        {
//            GameObject thisShopItem;
//            thisShopItem = Instantiate(itemSkinPrefab, contentGameObject);
//            thisShopItem.GetComponent<ShopItemAllocator>().gameItem = skinDatabase.handSkins[i];
//        }
//    }
//}
