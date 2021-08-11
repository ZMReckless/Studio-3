using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class Shootable : MonoBehaviourPunCallbacks
{
    public ParticleSystem shotAtEffect; 
    public Collider rollWhenDead;
   

    private void Start()
    {
        Rigidbody[] rb = Rigidbody.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];

        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = true;
        }
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
        rollWhenDead.isTrigger = false;

        if (transform.root.gameObject.CompareTag("Team1"))
        {
            GameManager.Instance.CompleteRound(1);
        }
        else
        {
            GameManager.Instance.CompleteRound(0);
        }

        Rigidbody[] rb = Rigidbody.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = false;
        }
    }
}
