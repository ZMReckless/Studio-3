using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyMoveScript : MonoBehaviour
{

    public CinemachineVirtualCamera dolly;

    public float speed = 0.1f;

    bool incrementUp;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            incrementUp = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            incrementUp = true;
        }
        
        if (incrementUp)
        {
            dolly.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += speed;
        }
        else
        {
            dolly.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition -= speed;
        }
    }
}
