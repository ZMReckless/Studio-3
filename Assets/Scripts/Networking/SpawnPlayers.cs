using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// spawns players
public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public Transform mobileSpawnpoint;
    public Transform team1PCSpawnpoint;
    public Transform team2PCSpawnpoint;

    void Start()
    {
        int playerIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerPlatform"];

        photonView.RPC("SpawnAssignPlayers", RpcTarget.All, playerIndex);
    }

    [PunRPC]
    public void SpawnAssignPlayers(int playerIndex)
    {
        switch (playerIndex)
        {
            case 0:
                GameManager.Instance.team1MBPlayer =
                PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                GameManager.Instance.team1MBPlayer.tag = "Team1";
                break;
            case 1:
                GameManager.Instance.team2MBPlayer =
                PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                GameManager.Instance.team2MBPlayer.tag = "Team2";
                break;
            case 2:
                GameManager.Instance.team1PCPlayer =
                PhotonNetwork.Instantiate("Player(Latest)", team1PCSpawnpoint.position, Quaternion.identity);
                GameManager.Instance.team1PCPlayer.tag = "Team1";
                break;
            case 3:
                GameManager.Instance.team2PCPlayer =
                PhotonNetwork.Instantiate("Player(Latest)", team2PCSpawnpoint.position, Quaternion.identity);
                GameManager.Instance.team2PCPlayer.tag = "Team2";
                break;
        }
    }
}
