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
    public Animator playerAnim;



    // Start is called before the first frame update
    void Start()
    {
        ammoDisplay = GameObject.Find("AmmoDisplay").GetComponent<TextMeshProUGUI>();


    }

    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString() + slash + maxAmmo.ToString();
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0 && !isFiring && Time.time >= nextShot)
        {
            SendDataInGame.UpdateShotsFired();
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
        //gunAnim.SetTrigger("Shoot");
        photonView.RPC("GunAnimSetTrigger", RpcTarget.All);
        //muzzleFlash.Play();
        photonView.RPC("PlayMuzzleFlash", RpcTarget.All);
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, shotRange))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward * shotRange);
            Debug.DrawRay(transform.position, forward, Color.red);

            Shootable shootable = hit.transform.GetComponent<Shootable>();

            if (shootable != null)
            {
                shootable.photonView.RPC("RPC_GetShot", RpcTarget.All);
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

    [PunRPC]
    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    [PunRPC]
    void GunAnimSetTrigger()
    {
        gunAnim.SetTrigger("Shoot");
    }
}
