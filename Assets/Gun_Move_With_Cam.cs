using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Move_With_Cam : MonoBehaviour
{
   

    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private Transform player, playerArms, weaponPivot;

    private float xAxisClamp = 0f;

    void Update()
    {
       

        Checks();
        CameraMovement();
    }

    void Checks()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 rotPlayersArms = transform.rotation.eulerAngles;
        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

        rotPlayersArms.x -= rotAmountY;
        //rotPlayersArms.z = 0;
        rotPlayer.y += rotAmountX;

        if (xAxisClamp > 90f)
        {
            xAxisClamp = 90f;
            rotPlayersArms.x = 90f;
        }
        else if (xAxisClamp < -90f)
        {
            xAxisClamp = -90f;
            rotPlayersArms.x = 270f;
        }

        playerArms.rotation = Quaternion.Euler(rotPlayersArms);
        player.rotation = Quaternion.Euler(rotPlayer);
        weaponPivot.rotation = Quaternion.Euler(rotPlayersArms);
    }
}
