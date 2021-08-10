using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class StatsPage : MonoBehaviour
{
    //public int r1, r2, r3, r4, r5;
    int[] rounds;
    string matchRoundVal, playFabId;
    Dictionary<string, UserDataRecord> playerDataPulled;
    public TextMeshProUGUI killsText, deathsText;
    public GameObject statsPage, loading;
    void Awake()
    {
        SendDataInGame.PullData();
        StartCoroutine(Load());
    }
    IEnumerator Load() {
        yield return new WaitForSeconds(2f);
        killsText.text = SendDataInGame.kills.ToString();
        deathsText.text = SendDataInGame.deaths.ToString();
        statsPage.SetActive(true);
        loading.SetActive(false);
    }
    //public void SendMatchData() {
    //    PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest() {
    //        PlayFabId = playFabId
    //    },
    //    result => Debug.Log("Success"),
    //    error => Debug.Log(error.GenerateErrorReport())
    //    );
    //    PullData(playFabId);
    //    rounds = new int[5] { r1, r2, r3, r4, r5 };
    //    for (int ii = 0; ii < 5; ii++) {
    //        matchRoundVal += rounds[ii] + "-";
    //    }
    //    #region OutputDataConditions
    //    if (!playerDataPulled.ContainsKey("Match1")) {
    //        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
    //            Data = new Dictionary<string, string>() {
    //                {"Match1", matchRoundVal}
    //            }
    //        },
    //        result => Debug.Log("Success"),
    //        error => { Debug.Log(error.GenerateErrorReport()); });
    //    }
    //    else if (!playerDataPulled.ContainsKey("Match2")) {
    //        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
    //            Data = new Dictionary<string, string>() {
    //                {"Match2", (playerDataPulled.TryGetValue("Match1", out UserDataRecord value21).ToString()) },
    //                {"Match1", matchRoundVal}
    //            }
    //        },
    //        result => Debug.Log("Success"),
    //        error => { Debug.Log(error.GenerateErrorReport()); });
    //    }
    //    else if (!playerDataPulled.ContainsKey("Match3")) {
    //        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
    //            Data = new Dictionary<string, string>() {
    //                {"Match3", (playerDataPulled.TryGetValue("Match2", out UserDataRecord value31).ToString()) },
    //                {"Match2", (playerDataPulled.TryGetValue("Match1", out UserDataRecord value32).ToString()) },
    //                {"Match1", matchRoundVal}
    //            }
    //        },
    //        result => Debug.Log("Success"),
    //        error => { Debug.Log(error.GenerateErrorReport()); });
    //    }
    //    else if (!playerDataPulled.ContainsKey("Match4")) {
    //        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
    //            Data = new Dictionary<string, string>() {
    //                {"Match4", (playerDataPulled.TryGetValue("Match3", out UserDataRecord value41).ToString()) },
    //                {"Match3", (playerDataPulled.TryGetValue("Match2", out UserDataRecord value42).ToString()) },
    //                {"Match2", (playerDataPulled.TryGetValue("Match1", out UserDataRecord value43).ToString()) },
    //                {"Match1", matchRoundVal}
    //            }
    //        },
    //        result => Debug.Log("Success"),
    //        error => { Debug.Log(error.GenerateErrorReport()); });
    //    }
    //    else if (!playerDataPulled.ContainsKey("Match5")) {
    //        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
    //            Data = new Dictionary<string, string>() {
    //                {"Match5", (playerDataPulled.TryGetValue("Match4", out UserDataRecord value51).ToString()) },
    //                {"Match4", (playerDataPulled.TryGetValue("Match3", out UserDataRecord value52).ToString()) },
    //                {"Match3", (playerDataPulled.TryGetValue("Match2", out UserDataRecord value53).ToString()) },
    //                {"Match2", (playerDataPulled.TryGetValue("Match1", out UserDataRecord value54).ToString()) },
    //                {"Match1", matchRoundVal}
    //            }
    //        },
    //        result => Debug.Log("Success"),
    //        error => { Debug.Log(error.GenerateErrorReport()); });
    //    }
    //    #endregion
    //}
    //public void PullData(string playFabId) {
    //    PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
    //        PlayFabId = playFabId,
    //        Keys = null
    //    },
    //    result => { Debug.Log("Got User Data");
    //        playerDataPulled = result.Data;
    //        },
    //    error => { Debug.Log("Got Error Retrieving Data:");
    //        Debug.Log(error.GenerateErrorReport());
    //    }); ;
    //}
}