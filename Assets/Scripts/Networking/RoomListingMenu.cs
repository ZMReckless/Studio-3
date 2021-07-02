using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject roomListingPrefab;
    [SerializeField]
    private Transform roomListingContent;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform transfrom in roomListingContent)
        {
            Destroy(transfrom.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;

            GameObject roomListItem;

            roomListItem =  Instantiate(roomListingPrefab, roomListingContent);
            roomListItem.GetComponent<RoomListItem>().SetRoomInfo(roomList[i]);
            roomListItem.GetComponent<RoomListItem>().ChangeRoomIcons();
        }

        Debug.Log("List updated");
    }
}
