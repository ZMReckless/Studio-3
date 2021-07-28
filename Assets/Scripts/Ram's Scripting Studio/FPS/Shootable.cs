using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class Shootable : MonoBehaviourPunCallbacks
{
    public ParticleSystem shotAtEffect; //blood
    //public Rigidbody[] rootRB;
                        //public Collider primaryCollider; //ragdoll
                        //public Collider[] allColliders; //ragdoll

    //public Camera mainCam; //killcam
    ////public Camera killCam; //killcam
    //public GameObject canvases; //killcam

   

    //PhotonView PV;

    private void Start()
    {
        Rigidbody[] rb = Rigidbody.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        //PhotonView = GetComponent<PhotonView>();
        //shotAtEffect.Pause();
        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void Awake() //ragdoll
    {
                        //primaryCollider = GetComponent<Collider>(); 
                        //allColliders = GetComponentsInChildren<Collider>(true);

        //RPC_GetShot(false);
        //shotAtEffect.Pause();
        
    }

    void start()
    {
        //defScreen.SetActive(false);
        
    }

    //public void EnableRagdoll(bool ragDollEnabled) //ragdoll
    //{

    //    foreach (var col in allColliders)
    //        col.enabled = ragDollEnabled;
    //    primaryCollider.enabled = !ragDollEnabled;
    //    GetComponent<Rigidbody>().useGravity = !ragDollEnabled;
    //    GetComponent<Animator>().enabled = !ragDollEnabled;
       
    //    if(ragDollEnabled)
    //    {
    //        Debug.LogWarning("Ragdoll Enabled");
    //    }
    //}

    public void Update()
    {
        
    }



    public void GetShot() //blood //killcam  //DONT NEED THIS I THINK
    {
        photonView.RPC("RPC_GetShot", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_GetShot()
    {
        shotAtEffect.Play();
        GetComponent<Animator>().enabled = false;



        //if compare tag = say red (because red just died here)
        //find GameObjectWithCompareTag in scene (blue opposite of who died ^) and add 1 to score
        //whoever's score pluses = they run GameManager.Instance.CompleteRound(0);
        //and if GameManager.Instance.CompleteRound(0) runs automatically the other person runs the opposite
        if (transform.root.gameObject.CompareTag("Team1"))
        {
            GameManager.Instance.CompleteRound(1);
            
            //photonView.RPC("ReloadScene", RpcTarget.All);
        }
        else
        {
            GameManager.Instance.CompleteRound(0);
            //photonView.RPC("ReloadScene", RpcTarget.All);
        }

        Rigidbody[] rb = Rigidbody.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = false;
        }

        



        //foreach (var col in allColliders)
        //    col.enabled = ragDollEnabled;
        //primaryCollider.enabled = !ragDollEnabled;
        //GetComponent<Rigidbody>().useGravity = !ragDollEnabled;
        //GetComponent<Animator>().enabled = !ragDollEnabled;



        //EnableKillCam();
    }

    //[PunRPC]
    //void ReloadScene() {
    //    SceneManager.LoadScene("TheGame");
    //}

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
