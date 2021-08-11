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
                if (GameManager.Instance.team1MBPlayer != null)
                {
                    PhotonNetwork.Destroy(GameManager.Instance.team1MBPlayer);
                    PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                }
                else if (GameManager.Instance.team1MBPlayer == null)
                {
                    PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                }
                break;
            case 1:
                if (GameManager.Instance.team2MBPlayer != null)
                {
                    PhotonNetwork.Destroy(GameManager.Instance.team2MBPlayer);

                    PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                }
                else if (GameManager.Instance.team2MBPlayer == null)
                {
                    PhotonNetwork.Instantiate("MobilePlayer", mobileSpawnpoint.position, Quaternion.identity);
                }
                break;
            case 2:
                if (GameManager.Instance.team1PCPlayer != null)
                {
                    PhotonNetwork.Destroy(GameManager.Instance.team1PCPlayer);

                    PhotonNetwork.Instantiate("Player(Latest)", team1PCSpawnpoint.position, Quaternion.identity);
                }
                else if (GameManager.Instance.team1PCPlayer == null)
                {
                    PhotonNetwork.Instantiate("Player(Latest)", team1PCSpawnpoint.position, Quaternion.identity);
                }
                break;
            case 3:
                if (GameManager.Instance.team2PCPlayer != null)
                {
                    PhotonNetwork.Destroy(GameManager.Instance.team2PCPlayer);

                    PhotonNetwork.Instantiate("Player(Latest)", team2PCSpawnpoint.position, Quaternion.identity);
                }
                else if (GameManager.Instance.team2PCPlayer == null)
                {
                    PhotonNetwork.Instantiate("Player(Latest)", team2PCSpawnpoint.position, Quaternion.identity);
                }
                break;
        }
    }
}
