using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// this script manages the game rounds
// references the individual players
// reset/next round code
// adds round scores
public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;

    [Header("Components")]
    public SpawnPlayers spawnPlayers;

    [Header("Scores")]
    public int roundIndex;
    public int redWins;
    public int blueWins;

    [Header("Round Variables")]
    public float roundRestartTime = 5;
    public int maxRound = 5;
    public int finalRound;
    [HideInInspector]
    public bool roundEnded = false;

    [HideInInspector]
    public GameObject team1MBPlayer;
    [HideInInspector]
    public GameObject team2MBPlayer;
    [HideInInspector]
    public GameObject team1PCPlayer;
    [HideInInspector]
    public GameObject team2PCPlayer;

    [Header("Condition Screens")]
    public GameObject victoryScreen;
    public GameObject defeatScreen;

    private void Awake()
    {
        Instance = this;

        roundIndex = 1;
        maxRound = 5;
        finalRound = maxRound - 2;
        redWins = 0;
        blueWins = 0;
        roundEnded = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            // test for red win
            CompleteRound(0);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            // test for blue win
            CompleteRound(1);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Application.Quit();
        }
    }

    public void CompleteRound(int scoreIndex)
    {
        photonView.RPC("AddScore", RpcTarget.All, scoreIndex);
    }

    [PunRPC]
    public void ResetPlayerPositions()
    {
        //team1MBPlayer.transform.position = spawnPlayers.mobileSpawnpoint.position;
        //team2MBPlayer.transform.position = spawnPlayers.mobileSpawnpoint.position;
        //team1PCPlayer.transform.position = spawnPlayers.team1PCSpawnpoint.position;
        //team2PCPlayer.transform.position = spawnPlayers.team2PCSpawnpoint.position;
    }

    [PunRPC]
    public void AddScore(int scoreIndex)
    {
        int playerPlatform = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerPlatform"];

        if (scoreIndex == 0)
        {
            if (playerPlatform == 0 || playerPlatform == 2)
            {
                victoryScreen.SetActive(true);
                Debug.Log("You Won");
            }
            else if (playerPlatform == 1 || playerPlatform == 3)
            {
                defeatScreen.SetActive(true);
                Debug.Log("You Lost");
            }
        }
        else if (scoreIndex == 1)
        {
            if (playerPlatform == 0 || playerPlatform == 2)
            {
                defeatScreen.SetActive(true);
                Debug.Log("You Lost");
            }
            else if (playerPlatform == 1 || playerPlatform == 3)
            {
                victoryScreen.SetActive(true);
                Debug.Log("You Won");
            }
        }

        if (roundIndex < maxRound)
        {
            roundIndex++;
        }

        switch (scoreIndex)
        {
            case 0:
                redWins++;
                break;
            case 1:
                blueWins++;
                break;
        }

        Debug.Log($"Red Wins: {redWins}");
        Debug.Log($"Blue WIns: {blueWins}");

        StartCoroutine(CompleteRoundCoroutine());
    }

    IEnumerator CompleteRoundCoroutine()
    {
        yield return new WaitForSeconds(roundRestartTime);

        if (redWins == finalRound || blueWins == finalRound)
        {
            if (redWins == finalRound)
            {
                Debug.Log("Red team wins");
            }
            else if (blueWins == finalRound)
            {
                Debug.Log("Blue team wins");
            }
            // code for winning conditions
        }
        else
        {
            victoryScreen.SetActive(false);
            defeatScreen.SetActive(false);

            // reset reset
            Debug.Log("Resetting round");
        }
    }
}
