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
        var bulletShellForce_X = Random.Range(30, 50);
        var triggerBulletShell = Instantiate(bulletShell, bulletShellLocation.position, bulletShellLocation.rotation);
        triggerBulletShell.GetComponent<Rigidbody>().AddForce(bulletShellForce_X, bulletShellForce_Y, 0);
        Destroy(triggerBulletShell, 8);

    }
}
