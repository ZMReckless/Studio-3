using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

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
    public float roundRestartTime = 2.5f;
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

    [Header("Game UI")]
    public Text roundText;
    public GameObject victoryScreen;
    public GameObject defeatScreen;
    public GameObject lobbyButton;

    int playerPlatform;

    private void Awake()
    {
        SendDataInGame.PullData();
        Instance = this;

        roundIndex = 1;
        maxRound = 5;
        finalRound = maxRound - 2;
        redWins = 0;
        blueWins = 0;
        roundEnded = false;

        roundText.transform.parent.gameObject.SetActive(true);
        ChangeRoundText(roundIndex);

        lobbyButton.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            // test for red win
            CompleteRound(0);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            // test for blue win
            CompleteRound(1);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            BackToLobby();
        }
    }

    public void CompleteRound(int scoreIndex)
    {
        if (photonView.IsMine)
        {
            photonView.RPC("AddScore", RpcTarget.All, scoreIndex);
        }
    }

    [PunRPC] //testing
    IEnumerator EnableVictoryScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        victoryScreen.SetActive(true);
    }

    [PunRPC] //testing
    IEnumerator EnableDefeatScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        defeatScreen.SetActive(true);
    }

    [PunRPC]
    public void AddScore(int scoreIndex)
    {
        playerPlatform = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerPlatform"];

        if (scoreIndex == 0)
        {
            if (playerPlatform == 0 || playerPlatform == 2)
            {
                StartCoroutine(EnableVictoryScreen(2.5f));
                if (playerPlatform == 2) {
                    SendDataInGame.UpdateKillsOrDeaths(scoreIndex, 0);
                }
                Debug.Log("You Won");
            }
            else if (playerPlatform == 1 || playerPlatform == 3)
            {
                StartCoroutine(EnableDefeatScreen(2.5f));
                if (playerPlatform == 2) {
                    SendDataInGame.UpdateKillsOrDeaths(scoreIndex, 1);
                }
                Debug.Log("You Lost");
            }
        }
        else if (scoreIndex == 1)
        {
            if (playerPlatform == 0 || playerPlatform == 2)
            {
                StartCoroutine(EnableDefeatScreen(2.5f));
                if (playerPlatform == 2) {
                    SendDataInGame.UpdateKillsOrDeaths(scoreIndex, 0);
                }
                Debug.Log("You Lost");
            }
            else if (playerPlatform == 1 || playerPlatform == 3)
            {
                StartCoroutine(EnableVictoryScreen(2.5f));
                if (playerPlatform == 2) {
                    SendDataInGame.UpdateKillsOrDeaths(scoreIndex, 1);
                }
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
                EndScreen();
                SendDataInGame.UpdateWinsOrLosses(1, playerPlatform);
                Debug.Log("Red team wins");
            }
            else if (blueWins == finalRound)
            {
                EndScreen();
                SendDataInGame.UpdateWinsOrLosses(2, playerPlatform);
                Debug.Log("Blue team wins");
            }
        }
        else
        {
            victoryScreen.SetActive(false);
            defeatScreen.SetActive(false);

            if (photonView.IsMine)
            {
                photonView.RPC("ResetPlayerPositions", RpcTarget.All);
            }

            Debug.Log("Resetting round");
        }
    }

    [PunRPC]
    public void ResetPlayerPositions()
    {
        spawnPlayers.Start();

        ChangeRoundText(roundIndex);
    }

    public void BackToLobby()
    {
        StartCoroutine(BackToMain());
    }

    IEnumerator BackToMain()
    {
        Debug.Log("Going back to main");

        PhotonNetwork.LeaveRoom();

        while (PhotonNetwork.InRoom)
        {
            Debug.Log("Still in room");

            yield return null;
        }

        Time.timeScale = 1;
        Debug.Log("Leaving room");
        SceneManager.LoadScene(0);
    }

    public void EndScreen()
    {
        Time.timeScale = 0;

        roundText.transform.parent.gameObject.SetActive(false);

        lobbyButton.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ChangeRoundText(int roundIndex)
    {
        roundText.text = $"Round {roundIndex}";
    }
}
