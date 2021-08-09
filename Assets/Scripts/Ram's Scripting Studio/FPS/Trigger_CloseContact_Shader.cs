using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Trigger_CloseContact_Shader : MonoBehaviourPunCallbacks
{

    public Material hiddenMat;
    public Material seenMat;

    private void Start()
    {
        GetComponent<Renderer>().material = hiddenMat;
    }
    //private float thresholdValue = 1f;
    //private float deTriggerThresholdValue = 0f;
    //private float thresholdChangeAmount = 0.025f;

    [PunRPC]
    public void ChangeMat()
    {
        GetComponent<Renderer>().material = seenMat;
    }


    public void ChangeMatTest()
    {
        GetComponent<Renderer>().material = seenMat;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if(photonView.IsMine)
            {
                photonView.RPC("ChangeMat", RpcTarget.All);
                photonView.RPC("RPC_BackToInvisible", RpcTarget.All);
            }
        }
    }

    public IEnumerator BackToInvisible()
    {
        yield return new WaitForSeconds(2);

        GetComponent<Renderer>().material = hiddenMat;

    }

    [PunRPC]
    public void RPC_BackToInvisible()
    {
        StartCoroutine(BackToInvisible());
    }
    //IEnumerator TriggerCloseContact()
    //{
    //    while (thresholdValue > 0)
    //    {
    //        yield return new WaitForSeconds(0);

    //        thresholdValue -= thresholdChangeAmount;
    //        mat.SetFloat("Threshold", thresholdValue);

    //        if (thresholdValue <= 0)
    //        {
    //            thresholdValue = 0;
    //            if (thresholdValue == 0)
    //            {
    //                StopAllCoroutines();
    //            }
    //        }
    //    }
    //}

    //IEnumerator DeTriggerCloseContact()
    //{
    //    while (deTriggerThresholdValue < 1)
    //    {
    //        yield return new WaitForSeconds(0);

    //        thresholdValue += thresholdChangeAmount;
    //        mat.SetFloat("Threshold", thresholdValue);

    //        if (thresholdValue >= 1)
    //        {
    //            thresholdValue = 1;
    //            if (thresholdValue == 1)
    //            {
    //                StopAllCoroutines();
    //            }
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    StartCoroutine(TriggerCloseContact());
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    StartCoroutine(DeTriggerCloseContact());
        //}
    }
}
