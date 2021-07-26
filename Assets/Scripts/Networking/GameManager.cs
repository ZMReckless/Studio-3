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

    //[HideInInspector]
    public GameObject team1MBPlayer;
    //[HideInInspector]
    public GameObject team2MBPlayer;
    //[HideInInspector]
    public GameObject team1PCPlayer;
    //[HideInInspector]
    public GameObject team2PCPlayer;

    private void Awake()
    {
        Instance = this;

        roundIndex = 1;
        redWins = 0;
        blueWins = 0;
    }

    public void CompleteRound(int scoreIndex)
    {
        photonView.RPC("AddScore", RpcTarget.All, scoreIndex);

        if (redWins != 3 || blueWins != 3)
        {
            photonView.RPC("ResetPlayerPositions", RpcTarget.All);
            // reset powerups
        }
        else
        {
            // code for winning conditions
        }
    }

    [PunRPC]
    public void ResetPlayerPositions()
    {
        team1MBPlayer.transform.position = spawnPlayers.mobileSpawnpoint.position;
        team2MBPlayer.transform.position = spawnPlayers.mobileSpawnpoint.position;
        team1PCPlayer.transform.position = spawnPlayers.team1PCSpawnpoint.position;
        team2PCPlayer.transform.position = spawnPlayers.team2PCSpawnpoint.position;
    }

    [PunRPC]
    public void AddScore(int scoreIndex)
    {
        roundIndex++;

        switch (scoreIndex)
        {
            case 0:
                redWins++;
                break;
            case 1:
                blueWins++;
                break;
        }
    }
}
