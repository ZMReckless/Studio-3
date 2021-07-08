using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTest : MonoBehaviour
{
    public Camera mainCam;

    public GameObject scanSphere;

    private bool hasScanned;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) &&
            hasScanned == false)
        {
            hasScanned = true;
            ScanTimer();
            Scan();
        }
    }

    void ScanTimer()
    {
        StartCoroutine("timer");

    }

    void Scan()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit)){
            var scan = Instantiate(scanSphere, hit.transform.position, Quaternion.identity);
            scan.AddComponent<SphereScan>();
        }

    }

    IEnumerator timer()
    {
        Debug.Log("coroutine entered");
        yield return new WaitForSeconds(3f);
        Debug.Log("timer finished");
        hasScanned = false;
    }
}
