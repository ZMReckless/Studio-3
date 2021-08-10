using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MineBehaviour : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Team1" || other.gameObject.tag == "Team2")
        {
            photonView.RPC("Explosion", RpcTarget.All, other);
        }
    }

    public void Explosion(GameObject player)
    {
        PhotonNetwork.InstantiateRoomObject("ExplosionParticles", gameObject.transform.position, Quaternion.identity);

        Vector3 headLocation = new Vector3(
                    player.transform.position.x,
                    player.transform.position.y + (player.GetComponent<CharacterController>().height / 2),
                    player.transform.position.z);

        GameObject smokeObject =
        PhotonNetwork.InstantiateRoomObject("SmokeParticles", headLocation, Quaternion.identity);

        smokeObject.transform.parent = player.transform;

        print("Explosion");

        PhotonNetwork.Destroy(gameObject);
    }
}
