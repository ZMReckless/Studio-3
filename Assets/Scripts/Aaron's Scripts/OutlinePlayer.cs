using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OutlinePlayer : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Team1" || other.gameObject.tag == "Team2")
        {
            photonView.RPC("AddOutline", RpcTarget.All, other);
        }
    }

    public void AddOutline(GameObject player)
    {
        if (player.GetComponent<Outline>() == null)
        {
            Outline outline = player.gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.red;
            outline.OutlineWidth = 10f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Team1" || other.gameObject.tag == "Team2")
        {
            photonView.RPC("RemoveOutline", RpcTarget.All, other);
        }
    }

    public void RemoveOutline(GameObject player)
    {
        if (player.GetComponent<Outline>() != null)
        {
            Destroy(player.gameObject.GetComponent<Outline>());
        }
    }
}
