using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// spawns players
public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public Transform mobileSpawnpoint;
    public Transform team1PCSpawnpoint;
    public Transform team2PCSpawnpoint;

    public void Start()
    {
        int playerIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerPlatform"];

        switch (playerIndex)
        {
            case 0:
                PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                break;
            case 1:
                PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                break;
            case 2:
                PhotonNetwork.Instantiate("Player(Latest)", team1PCSpawnpoint.position, Quaternion.identity);
                break;
            case 3:
                PhotonNetwork.Instantiate("Player(Latest)", team2PCSpawnpoint.position, Quaternion.identity);
                break;
        }
    }
}
