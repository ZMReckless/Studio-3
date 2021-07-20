using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScan : MonoBehaviour
{
    public Vector3 growthRate = new Vector3 (10f, 10f, 10f);

    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x <= 10 &&
            gameObject.transform.localScale.y <= 10 &&
            gameObject.transform.localScale.z <= 10)
        {
            gameObject.transform.localScale += (growthRate * Time.deltaTime);
        }
        if (gameObject.transform.localScale.x >= 10 &&
            gameObject.transform.localScale.y >= 10 &&
            gameObject.transform.localScale.z >= 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {

        }
    }
}
