using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("Condition Screens")]
    public GameObject victoryScreen;
    public GameObject defeatScreen;

    private void Awake()
    {
        Instance = this;

        roundIndex = 1;
        maxRound = 2;
        finalRound = maxRound;
        redWins = 0;
        blueWins = 0;
        roundEnded = false;
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
        photonView.RPC("AddScore", RpcTarget.All, scoreIndex);
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
    public void ResetPlayerPositions()
    {
        spawnPlayers.Start();
    }

    [PunRPC]
    public void AddScore(int scoreIndex)
    {
        int playerPlatform = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerPlatform"];

        if (scoreIndex == 0)
        {
            if (playerPlatform == 0 || playerPlatform == 2)
            {
                StartCoroutine(EnableVictoryScreen(2.5f));
                Debug.Log("You Won");
            }
            else if (playerPlatform == 1 || playerPlatform == 3)
            {
                StartCoroutine(EnableDefeatScreen(2.5f));
                Debug.Log("You Lost");
            }
        }
        else if (scoreIndex == 1)
        {
            if (playerPlatform == 0 || playerPlatform == 2)
            {
                StartCoroutine(EnableDefeatScreen(2.5f));
                Debug.Log("You Lost");
            }
            else if (playerPlatform == 1 || playerPlatform == 3)
            {
                StartCoroutine(EnableVictoryScreen(2.5f));
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
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (blueWins == finalRound)
            {
                Debug.Log("Blue team wins");
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            // code for winning conditions
        }
        else
        {
            victoryScreen.SetActive(false);
            defeatScreen.SetActive(false);

            Debug.Log("Resetting round");
        }
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
}
