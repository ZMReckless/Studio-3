using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun_Test : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public float shotRange = 100f;
    private float fireRate = 1f;
    private float nextShot = 1.25f;
    public Camera mainCam;
    public float pushBackForce;

    public int currentAmmo;
    public int maxAmmo;
    private string slash = "/";
    public bool isFiring;
    public TextMeshProUGUI ammoDisplay;

    public Animator gunAnim; //attached to pivot

    //public Transform bulletShellLocation; //moved to new script
    //public GameObject bulletShell;
    //public float bulletShellForce;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString() + slash + maxAmmo.ToString();
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0 && !isFiring && Time.time >= nextShot)
        {
            nextShot = Time.time + 1 / fireRate;
            Shoot();
            isFiring = true;
            currentAmmo --;
            isFiring = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
       
    }

    public void Shoot()
    {
        gunAnim.SetTrigger("Shoot");
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, shotRange))
        {
            Shootable shootable = hit.transform.GetComponent<Shootable>();
            if (shootable != null)
            {
                shootable.GetShot();
                shootable.EnableRagdoll(true);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * pushBackForce);
                
            }
        }
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
    }

    //void BulletShellTrigger() //moved to new script
    //{
    //    var triggerBulletShell = Instantiate(bulletShell, bulletShellLocation.position, bulletShellLocation.rotation);
    //    triggerBulletShell.GetComponent<Rigidbody>().AddForce(0, bulletShellForce, 0);
    //    Destroy(triggerBulletShell, 3);

    //}
}
