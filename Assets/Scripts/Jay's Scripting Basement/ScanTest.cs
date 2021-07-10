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
        _mousePos = Input.mousePosition;

        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity)){
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
