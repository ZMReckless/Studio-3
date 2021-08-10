using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Mine : PowerUp
{
    public override void PowerUpEffects()
    {
        Ray castPoint = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            PhotonNetwork.InstantiateRoomObject("Mine",
                (new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z)), Quaternion.identity);
        }
    }
}
