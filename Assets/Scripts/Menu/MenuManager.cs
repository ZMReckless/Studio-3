using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds all the menus in the scene
// opens and closes menus based on the string parameter
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] Menu[] menus; // array to add all the menus

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            // opens the menu from the string parameter
            if (menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            // closes the menus pther than the string parameter
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
