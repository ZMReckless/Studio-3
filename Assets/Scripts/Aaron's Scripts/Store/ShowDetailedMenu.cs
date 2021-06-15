using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// opens and calls method to fill item details
public class ShowDetailedMenu : MonoBehaviour
{
    private DisplaySkinDetails displaySkinDetails;
    private Button itemButton;

    private void Start()
    {
        displaySkinDetails = GameObject.Find("DetailedSkinMenu").transform.GetChild(0).GetComponent<DisplaySkinDetails>();
        itemButton = this.gameObject.GetComponent<Button>();

        itemButton.onClick.AddListener(ButtonClick); // adds event to button clicks
    }

    public void ButtonClick()
    {
        displaySkinDetails.DisplayDetails(); // calls method that displays details
    }
}
