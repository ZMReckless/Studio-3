using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class SphereScan : MonoBehaviourPunCallbacks
{
    public Vector3 growthRate = new Vector3 (10f, 10f, 10f);

    //public Material mat1;
    //public Material mat2;



    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x <= 10 &&
            gameObject.transform.localScale.y <= 10 &&
            gameObject.transform.localScale.z <= 10)
        {
            gameObject.transform.localScale += (growthRate * Time.deltaTime);
        }
        if (gameObject.transform.localScale.x >= 10 &&
            gameObject.transform.localScale.y >= 10 &&
            gameObject.transform.localScale.z >= 10)
        {
            //Destroy(gameObject); // testing this
            if (photonView.IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Team1") || other.CompareTag("Team2"))
        {
            Trigger_CloseContact_Shader Trigger_CloseContact_Shader = other.GetComponentInChildren<Trigger_CloseContact_Shader>();
            
            //Trigger_CloseContact_Shader.ChangeMatTest();
            other.GetComponentInChildren<Renderer>().material = Trigger_CloseContact_Shader.seenMat;
            Trigger_CloseContact_Shader.StartCoroutine("BackToInvisible");
        }
    }
}
