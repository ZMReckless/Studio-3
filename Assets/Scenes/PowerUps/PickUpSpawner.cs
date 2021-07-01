using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public PowerUpDatabase powerUpDatabase;

    public List<GameObject> pickUpBases = new List<GameObject>();
    public GameObject pickUpPrefab;

    public float hoverDistance = 0.2f;
    public int pickUpSpawns = 2;

    void Start()
    {
        List<int> baseIndex = new List<int>();
        baseIndex.Clear();
        for (int i = 0; i < pickUpBases.Count; i++)
        {
            baseIndex.Add(i);
        }

        for (int i = 0; i < pickUpSpawns; i++)
        {
            int randomIndex = Random.Range(0, baseIndex.Count);
            Transform pickUpTransform = pickUpBases[baseIndex[randomIndex]].transform;

            Vector3 pickUpLocation = new Vector3(pickUpTransform.position.x, pickUpTransform.position.y + hoverDistance, pickUpTransform.position.z);

            GameObject newPickUp =  Instantiate(pickUpPrefab, pickUpLocation, Quaternion.identity);
            newPickUp.transform.SetParent(pickUpTransform);
            newPickUp.name = "Pick Up " + (i + 1);
            baseIndex.RemoveAt(randomIndex);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject pickUpBase in pickUpBases)
            {
                if (pickUpBase.transform.childCount != 0)
                {
                    Destroy(pickUpBase.transform.GetChild(0).gameObject);
                }
            }

            Start();
        }
    }
}
