using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enables and disables the menus
// this script should be attached to menu game objects
public class Menu : MonoBehaviour
{
    public string menuName;
    public bool open;
    
    // when method is called opens the chosen menu
    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }

    // when method is called closes the chosen menu
    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }
}
