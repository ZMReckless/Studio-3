using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Layer_Change : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Team1") || other.CompareTag("Team2"))
        {
            this.gameObject.layer = 0; //def
        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.layer = 8; //hide
    }

    


}
