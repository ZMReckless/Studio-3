using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Shootable : MonoBehaviourPunCallbacks
{
    public ParticleSystem shotAtEffect; //blood
    public Collider primaryCollider; //ragdoll
    public Collider[] allColliders; //ragdoll

    public Camera mainCam; //killcam
    //public Camera killCam; //killcam
    public GameObject canvases; //killcam
    public GameObject defeatScreen;

    //PhotonView PV;

    private void Start()
    {
        //PhotonView = GetComponent<PhotonView>();
    }

    private void Awake() //ragdoll
    {
        primaryCollider = GetComponent<Collider>(); 
        allColliders = GetComponentsInChildren<Collider>(true);

        RPC_GetShot(false);
        shotAtEffect.Pause();
        defeatScreen.SetActive(false);
    }

    public void EnableRagdoll(bool ragDollEnabled) //ragdoll
    {

        foreach (var col in allColliders)
            col.enabled = ragDollEnabled;
        primaryCollider.enabled = !ragDollEnabled;
        GetComponent<Rigidbody>().useGravity = !ragDollEnabled;
        GetComponent<Animator>().enabled = !ragDollEnabled;
       
        if(ragDollEnabled)
        {
            Debug.LogWarning("Ragdoll Enabled");
        }
    }

    public void Update()
    {
        
    }



    public void GetShot() //blood //killcam  //DONT NEED THIS I THINK
    {
        photonView.RPC("RPC_GetShot", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_GetShot(bool ragDollEnabled)
    {
        shotAtEffect.Play();

        foreach (var col in allColliders)
            col.enabled = ragDollEnabled;
        primaryCollider.enabled = !ragDollEnabled;
        GetComponent<Rigidbody>().useGravity = !ragDollEnabled;
        GetComponent<Animator>().enabled = !ragDollEnabled;

        defeatScreen.SetActive(true);

        //EnableKillCam();
    }

    //[PunRPC]
    //public void RPC_EnableRagdoll(bool ragDollEnabled)
    //{
    //    foreach (var col in allColliders)
    //        col.enabled = ragDollEnabled;
    //    primaryCollider.enabled = !ragDollEnabled;
    //    GetComponent<Rigidbody>().useGravity = !ragDollEnabled;
    //    GetComponent<Animator>().enabled = !ragDollEnabled;
    //}


    //public void EnableKillCam() //killcam
    //{
    //    mainCam.enabled = false;
    //    killCam.enabled = true;
    //    Time.timeScale = 0.5f;
    //    Time.fixedDeltaTime = 0.02f * Time.timeScale;
    //    canvases.SetActive(false);
    //}

    
}
