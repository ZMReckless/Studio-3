using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

// manages the coin/currency system
// need to combine this with the serialization sytem to store the players coinAmount
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public TextMeshProUGUI coinAmountText; // reference the coin amount text in the shop

    [Header("Coin Variables")]
    public float coinAmount; // the amount of coin the individual player has
    public float startingCoinAmount = 1000f;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        coinAmountText.text = coinAmount.ToString();
    }

    public void GetCurrencyAmount()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved user data!");

        if (result.Data != null && result.Data.ContainsKey("Currency"))
        {
            coinAmount = float.Parse(result.Data["Currency"].Value);
        }
        else
        {
            StartingCurrency();
            Debug.Log("Player has no currency");
        }
    }

    public void SaveCurrencyAmount()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Currency", coinAmount.ToString() }
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void StartingCurrency()
    {
        coinAmount = startingCoinAmount;

        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Currency", coinAmount.ToString() }
            }
        };

        Debug.Log("Giving player starting currency");

        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

        GetCurrencyAmount();
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successful user data sent!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
}
