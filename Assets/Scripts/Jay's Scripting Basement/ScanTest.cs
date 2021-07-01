using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTest : MonoBehaviour
{
    public Camera mainCam;
    public GameObject scanSphere;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Scan();
        }
    }

    void Scan()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit)){
            var scan = Instantiate(scanSphere, hit.transform.position, Quaternion.identity);
            scan.AddComponent<SphereScan>();
        }

    }
}
