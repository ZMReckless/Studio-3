using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public static class SendDataInGame
{
    public static int kills, deaths, shotsFired, wins, losses, pingsHit, pingsShot, avgRoundTime;
    static string userPlayFabID;
    public static void PullData() {
        GetAccountInfo();
        PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
            PlayFabId = userPlayFabID,
            Keys = null
        }, result => {
            Debug.Log("Got user Data");
            kills = System.Convert.ToInt32(result.Data["Kills"].Value);
            deaths = System.Convert.ToInt32(result.Data["Deaths"].Value);
            shotsFired = System.Convert.ToInt32(result.Data["ShotsFired"].Value);
            wins = System.Convert.ToInt32(result.Data["Wins"].Value);
            losses = System.Convert.ToInt32(result.Data["Losses"].Value);
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
                {"ShotsFired", shotsFired.ToString()},
                {"Wins", wins.ToString()},
                {"Losses", losses.ToString()},
                {"PingsHit", pingsHit.ToString()},
                {"PingsShot", pingsShot.ToString()},
                {"AvgRoundTime", avgRoundTime.ToString()}
            }
        }, result => Debug.Log("Successfully Update User Data"),
        error => {
            Debug.Log("Got Error Updating User Data");
            Debug.LogError(error.GenerateErrorReport());
        });
    }
    public static void UpdateKillsOrDeaths(int index, int team) {
        if (index == team) {
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
    public static void UpdateWinsOrLosses(int teamWon, int currentPlayer) {
        if (teamWon == 2) {
            if (currentPlayer == 1 || currentPlayer == 3) {
                wins++;
            }
            else {
                losses++;
            }
        }
        else {
            if (currentPlayer == 1 || currentPlayer == 3) {
                losses++;
            }
            else {
                wins++;
            }
        }
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