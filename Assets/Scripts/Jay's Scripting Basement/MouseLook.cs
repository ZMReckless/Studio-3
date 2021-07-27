using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviour
{
    public float mouseSens;

    public Transform playerBody;
    

    float xRot = 0f;
    public float minClamp = -90;
    public float maxClamp = 90;

    [SerializeField] PhotonView photonView;

    private void Awake()
    {
        if (photonView == null)
        {
            photonView = GetComponentInParent<PhotonView>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            Destroy(gameObject);
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * (mouseSens * 100) * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSens * 100) * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, minClamp, maxClamp);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        

    }
}
