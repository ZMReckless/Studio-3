using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTest : MonoBehaviour
{
    public Camera mainCam;

    public GameObject scanSphere;

    private bool hasScanned;

    [SerializeField]
    private Vector3 _mousePos;

    // Update is called once per frame
    void Update()
    {
        //use this for touch input
        //if (Input.GetKeyDown(KeyCode.Mouse0) &&
        //    hasScanned == false)
        //{
        //    hasScanned = true;
        //    ScanTimer();
        //    Scan();
        //}
    }

    public void fire()
    {
        if (hasScanned == false)
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

    public void Scan()
    {
        //Use this for touch input
        //_mousePos = Input.mousePosition;
        //RaycastHit hit;
        //Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        //{
        //    var scan = Instantiate(scanSphere, (new Vector3(hit.point.x, hit.point.y, hit.point.z)), Quaternion.identity);
        //    scan.AddComponent<SphereScan>();
        //}


            //Use this for button press

        Ray castPoint = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
                var scan = Instantiate(scanSphere, (new Vector3(hit.point.x, hit.point.y, hit.point.z)), Quaternion.identity);
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
