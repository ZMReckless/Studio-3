using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Rotate : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 10 * rotationSpeed * Time.deltaTime, 0);
    }
}
