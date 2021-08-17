using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class SphereScan : MonoBehaviourPunCallbacks
{
    public Vector3 growthRate = new Vector3 (15f, 15f, 15f);

    //public Material mat1;
    //public Material mat2;



    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x <= 15 &&
            gameObject.transform.localScale.y <= 15 &&
            gameObject.transform.localScale.z <= 15)
        {
            gameObject.transform.localScale += (growthRate * Time.deltaTime);
        }
        if (gameObject.transform.localScale.x >= 15 &&
            gameObject.transform.localScale.y >= 15 &&
            gameObject.transform.localScale.z >= 15)
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
        if (other.CompareTag("Team1") || other.CompareTag("Team2") || other.CompareTag("Gun"))
        {
            Trigger_CloseContact_Shader Trigger_CloseContact_Shader = other.GetComponent<Trigger_CloseContact_Shader>();
            SendDataInGame.UpdatePingsHit();
            //Trigger_CloseContact_Shader.ChangeMatTest();
            other.GetComponent<Renderer>().material = Trigger_CloseContact_Shader.seenMat;
            Trigger_CloseContact_Shader.StartCoroutine("BackToInvisible");
            //test
        }
    }
}
