using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class Gun_Test : MonoBehaviourPunCallbacks
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

    //PhotonView PV;

    //public Transform bulletShellLocation; //moved to new script
    //public GameObject bulletShell;
    //public float bulletShellForce;


    // Start is called before the first frame update
    void Start()
    {
        ammoDisplay = GameObject.Find("AmmoDisplay").GetComponent<TextMeshProUGUI>();
        //PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame

    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString() + slash + maxAmmo.ToString();
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0 && !isFiring && Time.time >= nextShot)
        {
            nextShot = Time.time + 1 / fireRate;

            RPC_Shoot();
            isFiring = true;
            currentAmmo--;
            isFiring = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

    }


    public void Shoot()
    {
        photonView.RPC("RPC_Shoot", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_Shoot()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        gunAnim.SetTrigger("Shoot");
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, shotRange))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward * shotRange);
            Debug.DrawRay(transform.position, forward, Color.red);

            Shootable shootable = hit.transform.GetComponent<Shootable>();
            if (shootable != null)
            {
                Debug.Log("shot someone");
                shootable.RPC_GetShot();
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
