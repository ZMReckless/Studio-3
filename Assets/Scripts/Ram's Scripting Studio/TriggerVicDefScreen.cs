using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class TriggerVicDefScreen : MonoBehaviourPunCallbacks
{
    public GameObject defeatScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
      
    }

    [PunRPC]
    void TriggerDefeatScreen()
    {
        defeatScreen.SetActive(true);
    }
}
