using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Increase_MouseOver : MonoBehaviour
{
    public Button button;
    public float currentSize_X;
    public float currentSize_Y;
    public float highlightSize_X;
    public float highlightSize_Y;

    // Start is called before the first frame update
    void Start()
    {
        button = button.GetComponent<Button>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseButtonSize()
    {
        button.image.rectTransform.sizeDelta = new Vector2(highlightSize_X, highlightSize_Y);
    }

    public void DecreaseButtonSize()
    {
        button.image.rectTransform.sizeDelta = new Vector2(currentSize_X, currentSize_Y);
    }
}
