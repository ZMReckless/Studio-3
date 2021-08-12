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
    public TextMeshProUGUI killsText, deathsText, kdrText, shotsFiredText, gunAccuracyText, winsText, lossesText, wlrText, shotsHitText;
    public GameObject statsPage, loading, menuCanv, statCanv;
    bool runOnce;
    private void Awake() {
        StopAllCoroutines();
        SendDataInGame.PullData();
        StartCoroutine(Load());
        runOnce = true;
    }
    void Update() {
        if (gameObject.activeSelf) {
            if (!runOnce) {
                StopAllCoroutines();
                SendDataInGame.PullData();
                StartCoroutine(Load());
                runOnce = true;
            }
        }
    }
    IEnumerator Load() {
        yield return new WaitForSeconds(0.25f);
        killsText.text = SendDataInGame.kills.ToString();
        deathsText.text = SendDataInGame.deaths.ToString();
        shotsFiredText.text = SendDataInGame.shotsFired.ToString();
        winsText.text = SendDataInGame.wins.ToString();
        lossesText.text = SendDataInGame.losses.ToString();
        shotsHitText.text = SendDataInGame.kills.ToString();
        #region winLossStat
        if (SendDataInGame.wins == 0 && SendDataInGame.losses == 0) {
            wlrText.text = "N/A";
        }
        else if (SendDataInGame.wins == 0) {
            wlrText.text = (((float)SendDataInGame.wins + 1 / (float)SendDataInGame.losses)).ToString("F2");
        }
        else if (SendDataInGame.losses == 0) {
            wlrText.text = (((float)SendDataInGame.wins/ ((float)SendDataInGame.losses + 1))).ToString("F2");
        }
        else {
            wlrText.text = (((float)SendDataInGame.wins / (float)SendDataInGame.losses)).ToString("F2");
        }
        #endregion
        #region accuracyStat
        if (SendDataInGame.shotsFired == 0) {
            gunAccuracyText.text = "N/A";
        }
        else if (SendDataInGame.kills == 0) {
            gunAccuracyText.text = "0%";
        }
        else {
            float result;
            result = ((float)SendDataInGame.kills / (float)SendDataInGame.shotsFired); ;
            gunAccuracyText.text = ((int)((result) * 100)).ToString() + "%";
        }
        #endregion
        #region kdr
        if (SendDataInGame.kills == 0 && SendDataInGame.deaths == 0) {
            kdrText.text = "N/A";
        }
        else if (SendDataInGame.kills == 0) {
            float result = ((float)SendDataInGame.kills + 1 / (float)SendDataInGame.deaths);
            kdrText.text = result.ToString("F2");
        }
        else if (SendDataInGame.deaths == 0) {
            float result = ((float)SendDataInGame.kills / (float)SendDataInGame.deaths + 1);
            kdrText.text = result.ToString("F2");
        }
        else {
            float result = ((float)SendDataInGame.kills / (float)SendDataInGame.deaths);
            kdrText.text = result.ToString("F2");
            Debug.Log(result);
        }
        #endregion

        statsPage.SetActive(true);
        loading.SetActive(false);
    }
    public void ReturnToMenu() {
        menuCanv.SetActive(true);
        loading.SetActive(false);
        statsPage.SetActive(true);
        runOnce = false;
        statCanv.SetActive(false);
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