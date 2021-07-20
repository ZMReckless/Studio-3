using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Camera_Movement : MonoBehaviour
{

    public Camera mainCamera;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.Rotate(0, 1 * rotationSpeed, 0, Space.World);
    }
}
