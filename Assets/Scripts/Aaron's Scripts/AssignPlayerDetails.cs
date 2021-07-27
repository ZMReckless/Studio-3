using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AssignPlayerDetails : MonoBehaviourPunCallbacks
{
    void Start()
    {
        photonView.RPC("AssignPlayer", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void AssignPlayer()
    {
        int playerPlatform = (int)photonView.Owner.CustomProperties["PlayerPlatform"];

        if (playerPlatform == 0)
        {
            GameManager.Instance.team1MBPlayer = gameObject.transform.root.gameObject;
            GameManager.Instance.team1MBPlayer.name = "Team1MBPlayer";
            GameManager.Instance.team1MBPlayer.tag = "Team1";
        }
        else if (playerPlatform == 1)
        {
            GameManager.Instance.team2MBPlayer = gameObject.transform.root.gameObject;
            GameManager.Instance.team2MBPlayer.name = "Team2MBPlayer";
            GameManager.Instance.team2MBPlayer.tag = "Team2";
        }
        else if (playerPlatform == 2)
        {
            GameManager.Instance.team1PCPlayer = gameObject.transform.root.gameObject;
            GameManager.Instance.team1PCPlayer.name = "Team1PCPlayer";
            GameManager.Instance.team1PCPlayer.tag = "Team1";
        }
        else if (playerPlatform == 3)
        {
            GameManager.Instance.team2PCPlayer = gameObject.transform.root.gameObject;
            GameManager.Instance.team2PCPlayer.name = "Team2PCPlayer";
            GameManager.Instance.team2PCPlayer.tag = "Team2";
        }
    }
}
