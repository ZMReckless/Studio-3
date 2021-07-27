using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shell_Test : MonoBehaviour
{
    public Transform bulletShellLocation;
    public GameObject bulletShell;
    

    void BulletShellTrigger()
    {
        var bulletShellForce_Y = Random.Range(90, 110);
        var bulletShellForce_Z = Random.Range(30, 50);
        var triggerBulletShell = Instantiate(bulletShell, bulletShellLocation.position, bulletShellLocation.rotation);
        triggerBulletShell.GetComponent<Rigidbody>().AddForce(0, bulletShellForce_Y, -bulletShellForce_Z);
        Destroy(triggerBulletShell, 8);

    }
}
