using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayFabLogin : MonoBehaviour {
    public InputField username;
    public InputField loginUsername;
    public InputField password;
    public InputField loginPassword;
    public InputField email;
    public InputField display;
    public Text messageText;
    public void Start() {
        
    }
    public void RegisterButton() {
        if (password.text.Length < 6) {
            messageText.text = "Password has to be at least 6 characters long";
            StartCoroutine(TurnOffError());
            return;
        }
        //creates var with correct fields
        var request = new RegisterPlayFabUserRequest {
            Username = username.text,
            Password = password.text,
            Email = email.text,
            DisplayName = display.text,
            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    public void LoginButton() {
        var request = new LoginWithPlayFabRequest {
            Username = loginUsername.text,
            Password = loginPassword.text
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result) {
        messageText.text = "Logged In!";
        Debug.Log("Successful login");
    }
    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in!";
    }
    IEnumerator TurnOffError() {
        yield return new WaitForSeconds(3f);
        messageText.text = "";
    }
}