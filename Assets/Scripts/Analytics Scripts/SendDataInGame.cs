using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public static class SendDataInGame
{
    public static int kills, deaths, shotsFired;
    static string userPlayFabID;
    public static void PullData() {
        GetAccountInfo();
        PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
            PlayFabId = userPlayFabID,
            Keys = null
        }, result => {
            Debug.Log("Got user Data");
            if (result.Data == null || !result.Data.ContainsKey("Kills") || !result.Data.ContainsKey("Deaths") || !result.Data.ContainsKey("ShotsFired")) {

            }
            else {
                kills = System.Convert.ToInt32(result.Data["Kills"].Value);
                deaths = System.Convert.ToInt32(result.Data["Deaths"].Value);
                shotsFired = System.Convert.ToInt32(result.Data["ShotsFired"].Value);
            }
        }, error => {
            Debug.Log("Got Error Retrieving User Data:");
            Debug.Log(error.GenerateErrorReport());
        });
    }
    public static void SendData() {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
            Data = new Dictionary<string, string>(){
                {"Kills", kills.ToString()},
                {"Deaths", deaths.ToString()},
                {"ShotsFired", shotsFired.ToString()}
            }
        }, result => Debug.Log("Successfully Update User Data"),
        error => {
            Debug.Log("Got Error Updating User Data");
            Debug.LogError(error.GenerateErrorReport());
        });
    }
    public static void UpdateKillsOrDeaths(int winLose) {
        if (winLose == 1) {
            kills++;
        }
        else {
            deaths++;
        }
        SendData();
    }
    public static void UpdateShotsFired() {
        shotsFired++;
        SendData();
    }
    #region GetUserID
    static void GetAccountInfo() {
        GetAccountInfoRequest request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, Success, Fail);
    }
    static void Success(GetAccountInfoResult result) {
        userPlayFabID = result.AccountInfo.PlayFabId;
    }
    static void Fail(PlayFabError error) {
        Debug.LogError(error.GenerateErrorReport());
    }
    #endregion
}
