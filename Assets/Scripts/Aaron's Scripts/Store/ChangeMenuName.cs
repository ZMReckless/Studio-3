using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// changes the store title based on the skin section chosen
public class ChangeMenuName : MonoBehaviour
{
    public TextMeshProUGUI storeMenuTitle; // references the store title that changes text
    private Button storeButton;

    public void ChangeStoreTitle()
    {
        storeButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>(); // references the button that is pressed
        storeMenuTitle.text = storeButton.GetComponentInChildren<TextMeshProUGUI>().text; // changes the store title to the referenced buttons text
    }
}
