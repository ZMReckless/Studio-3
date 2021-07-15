using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class mobileCameraControl : MonoBehaviour
{
    private bool movingLeft;
    private bool movingRight;
   
    public CinemachineVirtualCamera dolly;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (movingLeft == true)
        //{
        //    dolly.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition -= speed;
        //}
        //if (movingRight == true)
        //{
        //    dolly.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += speed;
        //}
    }

    public void moveLeft()
    {
        movingLeft = true;
        Debug.Log("Moving Left");
    }

    public void moveRight()
    {
        movingRight = true;
        Debug.Log("Moving Right");
    }

    public void release()
    {
        movingLeft = false;
        movingRight = false;
    }
}
