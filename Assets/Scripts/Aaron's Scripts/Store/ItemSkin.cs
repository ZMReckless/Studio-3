using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// scriptable object for creating item skins
public enum SkinType { Gun, Model, Hands }
public enum RarityLevel { Common, Uncommon, Rare, Legendary }

[CreateAssetMenu(fileName = "New Item Skin", menuName = "Store/Skin")]
public class ItemSkin : ScriptableObject
{
    [Header("Variables")]
    public string skinName;
    [TextArea(2, 4)]
    public string skinDescription;
    public SkinType skinType;
    public RarityLevel skinRarity;
    public float skinCost;

    public bool unlocked = false;

    [Header("Object")]
    public GameObject item;

    [Header("Texture/Material")]
    public Material skinMaterial;

    [Header("Images")]
    public Sprite skinRarityBackground;
    public Sprite skinImage;
}
