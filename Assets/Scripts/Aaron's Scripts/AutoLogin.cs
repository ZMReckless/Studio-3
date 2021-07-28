using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoLogin : MonoBehaviour
{
    [Header("Login Details")]
    public string username;
    public string password;

    [Header("Components")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
   

    public void InputDetails()
    {
        usernameInput.text = username;
        passwordInput.text = password;
        
    }
}
