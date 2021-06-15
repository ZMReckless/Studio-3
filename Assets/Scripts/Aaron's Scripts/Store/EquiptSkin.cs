using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to test the equiptment of materials
public class EquiptSkin : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    public GameObject cylider;
     
    public void EquiptItemSkin()
    {
        DisplaySkinDetails displaySkinDetails = transform.GetComponentInParent<DisplaySkinDetails>();
        if (displaySkinDetails.skinItem.skinType == SkinType.Gun)
        {
            cube.GetComponent<Renderer>().material = displaySkinDetails.skinItem.skinMaterial;
        }
        else if (displaySkinDetails.skinItem.skinType == SkinType.Model)
        {
            sphere.GetComponent<Renderer>().material = displaySkinDetails.skinItem.skinMaterial;
        }
        else if (displaySkinDetails.skinItem.skinType == SkinType.Hands)
        {
            cylider.GetComponent<Renderer>().material = displaySkinDetails.skinItem.skinMaterial;
        }
    }
}
