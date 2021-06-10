using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Font_Increase_MouseOver : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float highlightedFontSize;
    public float normalFontSize;



    // Start is called before the first frame update
    void Start()
    {
        text = text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFontSize()
    {
        text.fontSize = highlightedFontSize;
    }

    public void UnsetFontSize()
    {
        text.fontSize = normalFontSize;
    }


}
