using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class JoystickController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float deltaX;

    //Dolly Movement 
    public CinemachineVirtualCamera dolly;

    public float speed = 0.1f;

    bool incrementUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            touchPos.z = 924f;
            Vector3 vec = Camera.main.ScreenToWorldPoint(touchPos);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = vec.x - transform.position.x;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(Mathf.Clamp(vec.x - deltaX, 60, 200), this.gameObject.transform.position.y));
                   
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }

            if (this.gameObject.transform.position.x  < 140)
            {
                Debug.Log("Left");
                incrementUp = false;
                //dolly.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition -= speed;
            }
            if (this.gameObject.transform.position.x > 140)
            {
                Debug.Log("Right");
                incrementUp = true;
                //dolly.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += speed;
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
}
