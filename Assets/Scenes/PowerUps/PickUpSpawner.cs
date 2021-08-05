using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PickUpSpawner : MonoBehaviourPunCallbacks
{
    public PowerUpDatabase powerUpDatabase;

    public List<GameObject> pickUpLocations = new List<GameObject>();

    public int pickUpSpawns = 2;

    void Start()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        List<int> locationIndex = new List<int>();
        locationIndex.Clear();

        for (int i = 0; i < pickUpLocations.Count; i++)
        {
            locationIndex.Add(i);
        }

        for (int i = 0; i < pickUpSpawns; i++)
        {
            int randomIndex = Random.Range(0, locationIndex.Count);
            Transform pickUpTransform = pickUpLocations[locationIndex[randomIndex]].transform;

            GameObject newPickUp = PhotonNetwork.InstantiateRoomObject("PickUp", pickUpTransform.transform.position, Quaternion.identity);
            newPickUp.transform.SetParent(pickUpTransform);
            newPickUp.name = "Pick Up " + (i + 1);
            locationIndex.RemoveAt(randomIndex);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject pickUpBase in pickUpLocations)
            {
                if (pickUpBase.transform.childCount != 0)
                {
                    PhotonNetwork.Destroy(pickUpBase.transform.GetChild(0).gameObject);
                }
            }

            Start();
        }
    }
}
