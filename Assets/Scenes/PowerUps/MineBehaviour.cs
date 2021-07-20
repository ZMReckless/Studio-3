using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject explosionObject;
    public GameObject smokeObject;

    [Header("Variables")]
    [SerializeField]
    private float explosionDistance = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Explosion();

            print("PLayer collision");
        }
    }

    public void Explosion()
    {
        Instantiate(explosionObject, gameObject.transform.position, Quaternion.identity);

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, explosionDistance);

        foreach (var gameObject in hitColliders)
        {
            if (gameObject.CompareTag("Player"))
            {
                Vector3 headLocation = new Vector3(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y + (gameObject.GetComponent<CharacterController>().height / 2),
                    gameObject.transform.position.z);

                Instantiate(smokeObject, headLocation, Quaternion.identity, gameObject.transform);
            }
        }

        Destroy(gameObject);

        print("Explosion");
    }
}
