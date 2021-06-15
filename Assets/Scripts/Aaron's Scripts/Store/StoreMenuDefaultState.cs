using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script that resets the state of the store
// this is for when the scene gets reloaded/loaded so hat it has a default state
public class StoreMenuDefaultState : MonoBehaviour
{
    public TextMeshProUGUI storeMenuTitle;
    public GameObject[] startActiveObjects;
    public GameObject[] startInactiveObjects;

    void Start()
    {
        ResetStoreCanvas();
    }

    void ResetStoreCanvas()
    {
        storeMenuTitle.text = "Store Home";
        foreach (GameObject gameObject in startActiveObjects)
        {
            gameObject.SetActive(true);
        }
        foreach (GameObject gameObject in startInactiveObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
