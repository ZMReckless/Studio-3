using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlayFabLogin : MonoBehaviour {
    public TMP_InputField username;
    public TMP_InputField loginUsername;
    public TMP_InputField password;
    public TMP_InputField loginPassword;
    public InputField email;
    public InputField display;
    public Text messageText;
    public GameObject loadingDialogue;
    public NetworkManager netManage;
    public GameObject playFabLogin;
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
        StartCoroutine(FinishPlayfabLogin());
    }
    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        //if (error.ErrorMessage == "Invalid input parameters") {
        //    messageText.text = "Username or Password does not exist";
        //}
        Debug.Log(error.GenerateErrorReport());
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in!";
        StartCoroutine(FinishPlayfabLogin());
    }
    IEnumerator FinishPlayfabLogin() {
        yield return new WaitForSeconds(1f);
        playFabLogin.SetActive(false);
        loadingDialogue.SetActive(true);
        netManage.PhotonLogin();
    }
    IEnumerator TurnOffError() {
        yield return new WaitForSeconds(3f);
        messageText.text = "";
    }
}