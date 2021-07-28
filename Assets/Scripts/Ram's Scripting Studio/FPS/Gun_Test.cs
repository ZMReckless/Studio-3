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


    public Material mat;
    private float thresholdValue = 1f;
    private float deTriggerThresholdValue = 0f;
    private float thresholdChangeAmount = 0.025f;


    //PhotonView PV;

    //public Transform bulletShellLocation; //moved to new script
    //public GameObject bulletShell;
    //public float bulletShellForce;

    // Start is called before the first frame update
    void Start()
    {
        

        ammoDisplay = GameObject.Find("AmmoDisplay").GetComponent<TextMeshProUGUI>();
        //PV = GetComponent<PhotonView>();
        mat.SetFloat("Threshold", 1);

    }

    // Update is called once per frame

    void Update()
    {
        

        ammoDisplay.text = currentAmmo.ToString() + slash + maxAmmo.ToString();
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0 && !isFiring && Time.time >= nextShot)
        {
            photonView.RPC("RPC_TriggerCloseContact", RpcTarget.All);


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
            //Vector3 forward = transform.TransformDirection(Vector3.forward * shotRange);
            //Debug.DrawRay(transform.position, forward, Color.red);

            Shootable shootable = hit.transform.GetComponent<Shootable>();

            if (shootable != null)
            {
                //Debug.LogWarning("shot someone");
                shootable.photonView.RPC("RPC_GetShot", RpcTarget.All);
                //shootable.EnableRagdoll(true);
                //shootable.photonView.RPC("RPC_EnableRagdoll", RpcTarget.All, true);

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

    #region shader

    [PunRPC]
    public void RPC_TriggerCloseContact()
    {
        StartCoroutine(TriggerCloseContact());
    }

    [PunRPC]
    public void RPC_DeTriggerCloseContact()
    {
        StartCoroutine(DeTriggerCloseContact());
    }


    IEnumerator TriggerCloseContact()
    {
        while (thresholdValue > 0)
        {
            yield return new WaitForSeconds(0);

            thresholdValue -= thresholdChangeAmount;
            mat.SetFloat("Threshold", thresholdValue);

            if (thresholdValue <= 0)
            {
                thresholdValue = 0;
                if (thresholdValue == 0)
                {
                    //StopAllCoroutines();
                    yield return new WaitForSeconds(3);
                    photonView.RPC("RPC_DeTriggerCloseContact", RpcTarget.All);
                }
            }
        }
    }

    IEnumerator DeTriggerCloseContact()
    {
        while (deTriggerThresholdValue < 1)
        {
            yield return new WaitForSeconds(0);

            thresholdValue += thresholdChangeAmount;
            mat.SetFloat("Threshold", thresholdValue);

            if (thresholdValue >= 1)
            {
                thresholdValue = 1;
                if (thresholdValue == 1)
                {
                    StopAllCoroutines();
                }
            }
        }
    }

    #endregion


    //void BulletShellTrigger() //moved to new script
    //{
    //    var triggerBulletShell = Instantiate(bulletShell, bulletShellLocation.position, bulletShellLocation.rotation);
    //    triggerBulletShell.GetComponent<Rigidbody>().AddForce(0, bulletShellForce, 0);
    //    Destroy(triggerBulletShell, 3);

    //}
}
