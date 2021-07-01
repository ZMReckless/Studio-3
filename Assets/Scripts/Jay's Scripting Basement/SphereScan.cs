using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScan : MonoBehaviour
{
    public Vector3 growthRate = new Vector3 (10f, 10f, 10f);

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
}
