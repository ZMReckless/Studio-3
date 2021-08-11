using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Victory_Defeat_Screen : MonoBehaviour
{
    public Image victory_defeat_Panel;
    public TextMeshProUGUI victory_defeat_Text;
    //public Canvas crosshair_canvas; //to disbale when active
    //public Canvas HUD_canvas; //to disable when active

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(victory_defeat_Panel.isActiveAndEnabled) //if the victory panel is enabled
        {
            //crosshair_canvas.enabled = false; //disable other canvases
            //HUD_canvas.enabled = false;

            //PANEL
            victory_defeat_Panel = GetComponent<Image>(); //increase the alpha of the panel progressively
            var colorChange = victory_defeat_Panel.color;
            colorChange.a += 0.02f;
            if (colorChange.a >= 0.8f)
            {
                colorChange.a = 0.8f;
            }
            victory_defeat_Panel.color = colorChange;

            //TEXT
            victory_defeat_Text = victory_defeat_Text.GetComponent<TextMeshProUGUI>(); //increase the alpha of the text progressively
            var textColorChange = victory_defeat_Text.color;
            textColorChange.a += 0.02f;
            victory_defeat_Text.color = textColorChange;

        }
        else
        {
            crosshair_canvas.enabled = true;
            HUD_canvas.enabled = true;
        }
        
    }

}
